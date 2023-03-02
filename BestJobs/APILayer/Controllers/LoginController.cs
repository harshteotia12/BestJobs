using APILayer.Models;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //Readonly Property
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<LoginController> _logger;
        /// <summary>
        /// Constructor to initialize the properties
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="signInManager"></param>
        /// <param name="roleManager"></param>
        /// <param name="configuration"></param>
        /// <param name="logger"></param>
        public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, ILogger<LoginController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _logger = logger;
        }
        /// <summary>
        /// To Logout from the Application
        /// </summary>
        /// <returns></returns>
        [HttpGet("Logout")]
        public async Task<ActionResult<string>> Logout()
        {
            try
            {
                _logger.LogInformation("From api user has signed out");
                await _signInManager.SignOutAsync();
                return "logged out";
            }
            catch (Exception ex)
            {
                _logger.LogError($"error => {ex.Message}");
                return null;
            }
        }
        /// <summary>
        /// For Registering the user throguh API in database
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        [HttpPost("Register")]
        public async Task<ActionResult<string>> PostCategory(SignUp register)
        {
            try
            {
                Dictionary<string, string> requestHeaders = new Dictionary<string, string>();
                foreach (var header in Request.Headers)
                {
                    requestHeaders.Add(header.Key, header.Value);
                }
                register.Password = requestHeaders["header"];
                register.ConfirmPassword = requestHeaders["header"];
                if (ModelState.IsValid)
                {
                    var user = new IdentityUser()
                    {
                        UserName = register.Email,
                        Email = register.Email
                    };
                    // To create and validate whether the new user is having unique EmailId or not
                    try
                    {
                        var result = await _userManager.CreateAsync(user, register.Password);
                        bool adminRoleExists = await _roleManager.RoleExistsAsync(register.RoleName);
                        if (!adminRoleExists)
                        {
                            await _roleManager.CreateAsync(new IdentityRole(register.RoleName));
                        }
                        if (!await _userManager.IsInRoleAsync(user, register.RoleName))
                        {
                            await _userManager.AddToRoleAsync(user, register.RoleName);
                        }
                        if (result.Succeeded)
                        {
                            await _signInManager.SignInAsync(user, false);
                            _logger.LogInformation($"API, user {register.Email} is registered as role=> {register.RoleName} successfully");
                            return "Registration Successfull";

                        }
                        else
                        {
                            _logger.LogError($"API, user {register.Email} was not registered");
                        }
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"error => {ex.Message}");
                        return null;
                    }
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                _logger.LogError($"error => {ex.Message}");
                return null;
            }
        }
        /// <summary>
        /// To Login the user into the application by returning JWT Token if the user is desired user
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public async Task<ActionResult<string>> LoginUser(Login login)
        {
            try
            {
                Dictionary<string, string> requestHeaders = new Dictionary<string, string>();
                foreach (var header in Request.Headers)
                {
                    requestHeaders.Add(header.Key, header.Value);
                }
                login.Password = requestHeaders["header"];

                var user = await _userManager.FindByNameAsync(login.Username);
                if (user != null && await _userManager.CheckPasswordAsync(user, login.Password))
                {
                    var userRoles = await _userManager.GetRolesAsync(user);
                    var authClaims = new List<Claim>
                {
                new Claim(ClaimTypes.NameIdentifier, login.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }
                    var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                    var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(5),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
                    );


                    _logger.LogInformation($"API, {login.Username} was logged in");
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    });
                }
                _logger.LogInformation($"API, {login.Username} login was not successfull");
                return Unauthorized();
            }
            catch (Exception ex)
            {
                _logger.LogError($"error => {ex.Message}");
                return null;
            }
        }
    }
}

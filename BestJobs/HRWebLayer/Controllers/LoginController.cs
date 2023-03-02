using HRWebLayer.Helper;
using HRWebLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Net.Http.Headers;

namespace HRWebLayer.Controllers
{
    public class LoginController : Controller
    {
        IAPI _APIUrl;
        private readonly IConfiguration _configuration;
        private readonly ILogger<LoginController> _logger;
        private readonly IHttpContextAccessor Accessor;

        public LoginController(ILogger<LoginController> logger, IConfiguration configuration, IHttpContextAccessor _accessor,IAPI APIUrl)
        {
            Accessor = _accessor;
            _logger = logger;
            _configuration = configuration;
            _APIUrl= APIUrl;

        }


        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Password()
        {
            return View("Password");
        }


        public ActionResult Login()
        {
            return View();
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Password(PasswordModel passwordModel)
        //{
        //    var user = await _userManager.FindByEmailAsync(passwordModel.Username);
        //    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        //    var reset = await _userManager.ResetPasswordAsync(user, token.ToString(), passwordModel.Password);
        //    if (reset.Succeeded)
        //    {
        //        return RedirectToAction("Logout");
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}


        public async Task<IActionResult> LoginUser(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpClient client = _APIUrl.Initial();
                    client.DefaultRequestHeaders.Add("header", login.Password);
                    login.Password = "Pseudo_Pass@123";
                    var insert = await client.PostAsync("api/login/login", new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json"));
                    if (insert.IsSuccessStatusCode)
                    {

                        var response = insert.Content.ReadAsStringAsync().Result;
                        var userToken = JsonConvert.DeserializeObject<TokenModel>(response);
                        if (userToken != null)
                        {
                            _logger.LogInformation($"user => {login.Username} successfully signed in");
                        }
                        var jwtToken = userToken.Token.ToString();

                        HttpContext.Session.SetString("JwtToken", jwtToken);

                        var stream = jwtToken;
                        var handler = new JwtSecurityTokenHandler();
                        var jsonToken = handler.ReadToken(stream);
                        var tokenS = jsonToken as JwtSecurityToken;

                        var list = new List<object>();
                        var values = tokenS.Claims.GetEnumerator();
                        foreach (var claim in tokenS.Claims)
                        {
                            list.Add(claim.Value);
                        }
                        var userName = list[0];
                        HttpContext.Session.SetString("UserName", userName.ToString());
                        var role = list[2];
                        HttpContext.Session.SetString("RoleName", role.ToString());
                        return RedirectToAction("Index", "HR");
                    }
                }
                _logger.LogError($"some unidentified user with email {login.Username} tried logging in access was DENIED");
                return View("login");
            }
            catch (Exception ex)
            {
                _logger.LogError($"error => {ex.Message}");
                return null;
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> RegisterUser(SignUp register)
        {
            try
            {
                HttpClient client = _APIUrl.Initial();
                client.DefaultRequestHeaders.Add("header", register.Password);
                register.Password = "Pseudo_Pass@123";
                register.ConfirmPassword = "Pseudo_Pass@123";
                register.RoleName = "OrgNHr";
                try
                {
                    var insert = await client.PostAsync("api/Login/Register", new StringContent(JsonConvert.SerializeObject(register), Encoding.UTF8, "application/json"));
                    if (insert.IsSuccessStatusCode)
                    {
                        _logger.LogInformation($"new user {register.Email} is registered as {register.RoleName}");
                        return RedirectToAction("Login", "Login");
                        //return View("Login");
                    }
                    _logger.LogError($"new user {register.Email} tried to register as {register.RoleName} but failed");
                    ModelState.AddModelError("", "Username or Password Incorrect");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return View("Register");
            }
            catch (Exception ex)
            {
                _logger.LogError($"error => {ex.Message}");
                return null;
            }


        }
        public async Task<ActionResult> Logout()
        {
            try
            {
                HttpClient client = _APIUrl.Initial();

                HttpResponseMessage response2 = await client.GetAsync("api/login/logout");
                
                if (response2.IsSuccessStatusCode)
                {
                    HttpContext.Session.Remove("JwtToken");
                    HttpContext.Session.Remove("UserName");
                    HttpContext.Session.Remove("RoleName");
                    HttpContext.Session.Remove("YourName");
                    _logger.LogInformation("user has logged out");
                    return RedirectToAction("Login");
                }
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError($"error => {ex.Message}");
                return null;
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

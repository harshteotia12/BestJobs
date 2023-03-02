using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Net;

namespace CandidateWebLayer.Helper
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CustomAuthorizationAttribute : Attribute, Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter
    {


        /// <summary>  
        /// This will Authorize User  
        /// </summary>  
        /// <returns></returns>  
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            if (context != null)
            {
                Microsoft.Extensions.Primitives.StringValues authTokens;
                authTokens = context.HttpContext.Session.GetString("JwtToken");

                var _token = authTokens.FirstOrDefault();
                if (_token == null || _token.Equals("null"))
                {
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.ExpectationFailed;
                    context.HttpContext.Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "Please Provide authToken";
                    context.Result = new JsonResult("Please Provide authToken.")
                    {
                        Value = new
                        {
                            Status = "Error",
                            Message = "Please Provide authToken"
                        },
                    };
                }
                else
                {
                    string authToken = _token;
                    if (IsValidToken(authToken))
                    {
                        context.HttpContext.Response.Headers.Add("authToken", authToken);
                        context.HttpContext.Response.Headers.Add("AuthStatus", "Authorized");

                        context.HttpContext.Response.Headers.Add("storeAccessiblity", "Authorized");

                    }
                    //signature
                    else
                    {
                        context.HttpContext.Response.Headers.Add("authToken", authToken);
                        context.HttpContext.Response.Headers.Add("AuthStatus", "NotAuthorized");
                      
                        context.HttpContext.Session.GetString("JwtToken");
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                        context.HttpContext.Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "Not Authorized";
                        context.Result = new JsonResult("NotAuthorized")
                        {
                            Value = new
                            {
                                Status = "Error",
                                Message = "Invalid Token"
                            },
                        };
                    }

                }
            }
        }

        public bool IsValidToken(string authToken)
        {
            //validate Token here  
            return true;
        }
    }
}
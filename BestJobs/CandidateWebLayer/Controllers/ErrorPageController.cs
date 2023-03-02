using Microsoft.AspNetCore.Mvc;

namespace CandidateWebLayer.Controllers
{
    [Route("ErrorPage/{statuscode}")]
    public class ErrorPageController : Controller
    {
        public static int statuscode { get; set; } =  404;
        public IActionResult ErrorPage()
        {
            switch (statuscode)
            {
                case 404:
                    ViewData["Error"] = "Page Not Found";
                    break;
                case 401:
                    ViewData["Error"] = "You are not the authorized User";
                    break;
                case 403:
                    ViewData["Error"] = "Forbidden";
                    break;
                case 400:
                    ViewData["Error"] = "Bad Request";
                    break;
                case 500:
                    ViewData["Error"] = "Internal Server Error";
                    break;
                case 502:
                    ViewData["Error"] = "Bad Gateway.";
                    break;
                case 503:
                    ViewData["Error"] = "Gateway Timeout";
                    break;
                default:
                    break;
            }
            statuscode = 404;
            return View("ErrorPage");
        }
    }
}

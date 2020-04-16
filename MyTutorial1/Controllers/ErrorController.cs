using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyTutorial1.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }

        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var StatusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry the resource you requested could not be found";
                    //ViewBag.Path = StatusCodeResult.OriginalPath;
                    //ViewBag.QS = StatusCodeResult.OriginalQueryString;
                    logger.LogWarning($"404 Error Occured. Path = {StatusCodeResult.OriginalPath}" +
                        $"and Query String = {StatusCodeResult.OriginalQueryString}");
                    break;
            }


            return View("NotFound");
        }
        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var ExceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            logger.LogError($"The path {ExceptionDetails.Path} threw an exception {ExceptionDetails.Error}");

            //ViewBag.ExceptionPath = ExceptionDetails.Path;
            //ViewBag.ExceptionMessage = ExceptionDetails.Error.Message;
            //ViewBag.StackTrace = ExceptionDetails.Error.StackTrace;

            return View("Error");
        }

    }
}

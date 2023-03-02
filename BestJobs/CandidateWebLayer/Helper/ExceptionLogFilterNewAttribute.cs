using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;
using System.Net.Http;

namespace CandidateWebLayer.Helper
{
    public class ExceptionLogFilterNewAttribute : ExceptionFilterAttribute, IExceptionFilter
    {
        private readonly string _path;
        public ExceptionLogFilterNewAttribute()
        {

        }
        public ExceptionLogFilterNewAttribute(string path)
        {
            _path = path;
        }
        public override void OnException(ExceptionContext context)
        {

            var exceptionMessage = context.Exception.Message;
            var stackTrace = context.Exception.StackTrace;
            var controllerName = context.RouteData.Values["controller"].ToString();
            var actionName = context.RouteData.Values["action"].ToString();
            var Message = "Date :" + DateTime.Now.ToString("dd-MM-yyyy hh:mm tt") + "Error Message:" + exceptionMessage + Environment.NewLine + "Stack Trace:" + stackTrace;
            //Save in a Log File
            StreamWriter log;
            FileStream fileStream = null;
            DirectoryInfo logDirInfo = null;
            FileInfo logFileInfo;

            string logFilePath = _path;
            logFilePath = logFilePath + "Log-" + System.DateTime.Today.ToString("dd-MM-yyyy") + ".txt";
            logFileInfo = new FileInfo(logFilePath);
            logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists)
                logDirInfo.Create();
            if (!logFileInfo.Exists)
            {
                fileStream = logFileInfo.Create();
            }
            else
            {
                fileStream = new FileStream(logFilePath, FileMode.Append);
            }
            log = new StreamWriter(fileStream);
            log.WriteLine("====================================================START=========================================================");

            log.WriteLine("Log Created At-" + DateTime.Now.ToString("dd-MM-yyyy hh:mm tt") + "Controller :" + controllerName + ", Action :" + actionName + ", Message :-" + Message);
            log.WriteLine("====================================================END=========================================================");
            log.Close();
            ErrorClass errorClass = new ErrorClass { Message = context.Exception.GetType().Name };
            context.Result = new RedirectToActionResult("Error", "Candidate", errorClass);
            base.OnException(context);
        }

        public class ErrorClass
        {
            public string Message { get; set; }
        }
    }
}
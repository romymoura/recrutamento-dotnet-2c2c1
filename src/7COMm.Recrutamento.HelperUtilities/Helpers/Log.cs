using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using log4net.Repository;

namespace _7COMm.Recrutamento.HelperUtilities
{
    public class Log
    {
        private static readonly ILoggerRepository _logRepository;
        private static readonly ILog _log;
        private const string HideWith = "***";

        static Log()
        {
            _logRepository = LogManager.GetRepository(GetAssembly());
            XmlConfigurator.Configure(_logRepository);
            //logger names are mentioned in <log4net> section of config file
            _log = GetLogger("logInfo"); //DEFAULT
        }

        private static ILog GetLogger(string logName)
        {
            ILog log = LogManager.GetLogger(GetAssembly(), logName);
            return log;
        }

        private static Assembly GetAssembly()
        {
            return Assembly.GetEntryAssembly();
        }


        /// <summary>
        /// This method will format the Action Log messages
        /// </summary>
        /// <param name="context"></param>
        public static string FormatActionMessage(ActionExecutingContext context)
        {
            string formatLog4Net = "{" +
                                    String.Format("\"Controller\":{0}, \"Action\":{1}",
                                    "\"" + context.ActionDescriptor.AttributeRouteInfo.GetType().FullName + "\"",
                                    "\"" + context.ActionDescriptor.AttributeRouteInfo.Name+ "\"") +
                                   "}";

            return formatLog4Net;
        }

        /// <summary>
        /// This method will format the Exception Log messages
        /// </summary>
        /// <param name="context"></param>
        //public static string FormatExceptionMessage(HttpActionExecutedContext context)
        //{
        //    string uri = context.ActionContext.RequestContext.Url.Request.RequestUri.ToString();
        //    string action = context.ActionContext.ActionDescriptor.ActionName;
        //    string controller = context.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
        //    string exception = context.Exception.Message;

        //    string formatLog4Net = "{" +
        //                            String.Format("\"Controller\":{0}, \"Action\":{1}, \"Exception\":{2}",
        //                            "\"" + controller + "\"",
        //                            "\"" + action + "\"",
        //                            "\"" + exception + "\"") +
        //                           "}";

        //    return formatLog4Net;
        //}

        /// <summary>
        /// This method will write DEBUG log according to the configuration setting (web.config)
        /// </summary>
        /// <param name="message"></param>
        public static void WriteDebugLog(string message, Exception ex)
        {
            if (ex == null)
                _log.DebugFormat(message);
            else
                _log.DebugFormat(message, ex);
        }

        /// <summary>
        /// This method will write INFO log according to the configuration setting (web.config)
        /// </summary>
        /// <param name="message"></param>
        public static void WriteInfoLog(string message)
        {
            _log.Info(message);
        }

        /// <summary>
        /// This method will write ERROR log according to the configuration setting (web.config)
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void WriteErrorLog(string message, Exception ex)
        {
            ILog log = GetLogger("logError");
            log.Error(message, ex);
        }

        public static string HideSensitiveData(string jsonSerialized)
        {
            var ret = "";

            try
            {
                if (!string.IsNullOrEmpty(jsonSerialized))
                {
                    var jsonParsed = JObject.Parse(jsonSerialized);

                    //FindTokens(jsonParsed, CardNumber);
                    //FindTokens(jsonParsed, Username);
                    //FindTokens(jsonParsed, Password);
                    //FindTokens(jsonParsed, PinBlock);
                    //FindTokens(jsonParsed, Track1);
                    //FindTokens(jsonParsed, Track2);
                    //FindTokens(jsonParsed, CVV);
                    //FindTokens(jsonParsed, CVV2);
                    //FindTokens(jsonParsed, CVV1AND2);
                    //FindTokens(jsonParsed, PAN);
                    //FindTokens(jsonParsed, Pin);
                    //FindTokens(jsonParsed, Validaty);
                    //FindTokens(jsonParsed, CVVCase);
                    //FindTokens(jsonParsed, CVV2Case);
                    //FindTokens(jsonParsed, CVV1_CVV2);
                    //FindTokens(jsonParsed, PAN2);
                    //FindTokens(jsonParsed, Card_Due_Date);
                    //FindTokens(jsonParsed, CardDueDate);
                    //FindTokens(jsonParsed, CardDueDateCase);
                    //FindTokens(jsonParsed, NewPassword);
                    //FindTokens(jsonParsed, ConfirmPassword);
                    ret = JsonConvert.SerializeObject(jsonParsed);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return ret;
        }

        private static void FindTokens(JToken containerToken, string name)
        {
            if (containerToken.Type == JTokenType.Object)
            {
                foreach (JProperty child in containerToken.Children<JProperty>())
                {
                    if (child.Name == name)
                    {
                        child.Value = HideWith;
                    }
                    else
                    {
                        if (child.Value.ToString() == name)
                        {
                            ((JProperty)child.Next).Value = HideWith;
                        }
                    }
                    FindTokens(child.Value, name);
                }
            }
            else if (containerToken.Type == JTokenType.Array)
            {
                foreach (JToken child in containerToken.Children())
                {
                    FindTokens(child, name);
                }
            }
        }
    }
}

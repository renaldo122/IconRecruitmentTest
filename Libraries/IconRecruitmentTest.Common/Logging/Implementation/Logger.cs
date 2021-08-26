using IconRecruitmentTest.Common.Common;
using log4net;
using System;

namespace IconRecruitmentTest.Common.Logging.Implementation
{
    public class Logger : ILogger
    {
        #region Fields

        private readonly ILog _loggingInstance;

        #endregion

        #region Ctx
        protected Logger()
        {
        }
        public Logger(ILog logger)
        {
            _loggingInstance = logger;
        }
        #endregion


        #region Methods
        /// <inheritdoc />
        public void Error(string message, string method, Exception exception = null, params string[] parameters)
        {
            message = (string)FormatLogMessage(LogLevel.Error, message, method, exception, parameters);
            _loggingInstance.Error(message, null);
        }

        /// <inheritdoc />
        public void Info(string message, string method, Exception exception = null)
        {
            message = (string)FormatLogMessage(LogLevel.Information, message, method, exception);
            _loggingInstance.Info(message, null);
        }


        /// <summary>
        /// Format message to store on log files
        /// </summary>
        /// <param name="level"></param>
        /// <param name="message"></param>
        /// <param name="method"></param>
        /// <param name="exception"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public object FormatLogMessage(LogLevel level, string message, string method, Exception exception = null, params string[] parameters)
        {
            try
            {
                var fullMessage = exception?.ToString() ?? string.Empty;
                string[] methodParameters = new string[] { "Empty" };
                if (!string.IsNullOrEmpty(string.Join(",", parameters))) methodParameters = parameters;
                string messageformat = Guid.NewGuid() + "||" + DateTime.Now + "||" + level + "||" + message + "||" + method + "||" + string.Join(",", methodParameters) + "||" + fullMessage + "||****";
                return messageformat;
            }
            catch (Exception ex)
            {
                //Ignore ex
                return "";
            }

        }

        #endregion

    }
}

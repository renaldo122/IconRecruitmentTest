using System;

namespace IconRecruitmentTest.Common.Logging
{
    public interface ILogger
    {
        /// <summary>
        /// Error
        /// </summary>
        /// <param name="message"></param>
        /// <param name="method"></param>
        /// <param name="exception"></param>
        /// <param name="parameters"></param>
        void Error(string message, string method, Exception exception = null, params string[] parameters);

        /// <summary>
        /// Info
        /// </summary>
        /// <param name="message"></param>
        /// <param name="method"></param>
        /// <param name="exception"></param>
        void Info(string message, string method, Exception exception = null);
    }
}

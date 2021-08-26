using System;
using System.Collections.Generic;
using System.Text;

namespace IconRecruitmentTest.Common.Logging.Implementation
{
    public class NullLogger : ILogger
    {

        /// <inheritdoc />
        public void Error(string message, string method, Exception exception = null, params string[] parameters)
        {
        }

        /// <inheritdoc />
        public void Info( string message, string method, Exception exception = null)
        {
        }
    }
}

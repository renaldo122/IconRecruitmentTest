using System;
using System.Collections.Generic;
using System.Text;

namespace IconRecruitmentTest.Common.Message
{  
    /// <inheritdoc />
    public class ResponseMessage : IResponseMessage
    {
        public ResponseMessage(string message) : this()
        {
            Message = message;
        }
        public ResponseMessage()
        {
            CustomAction = new Dictionary<object, object>();
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { private get; set; }
        public Dictionary<object, object> CustomAction { get; set; }
    }
}

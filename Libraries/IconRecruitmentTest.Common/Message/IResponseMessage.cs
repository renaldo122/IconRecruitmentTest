using System;
using System.Collections.Generic;
using System.Text;

namespace IconRecruitmentTest.Common.Message
{
    /// <summary>
    /// Create a custom message for json response 
    /// </summary>
    public interface IResponseMessage
    {
        bool Success { get; set; }
        string Message { get; set; }
        object Data { set; }
        Dictionary<object, object> CustomAction { get; set; }
    }
}

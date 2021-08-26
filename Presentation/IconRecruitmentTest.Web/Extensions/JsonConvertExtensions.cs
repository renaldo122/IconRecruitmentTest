using IconRecruitmentTest.Common.Message;
using Newtonsoft.Json;
using System;

namespace IconRecruitmentTest.Web.Extensions
{
    public class JsonConvertExtensions
    {
        public static string GetJsonConvert(IResponseMessage response)
        {
            try
            {
                var jsonResponse = JsonConvert.SerializeObject(response, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return jsonResponse;
            }
            catch (Exception)
            {
                var responseError = new ResponseMessage {
                    Success = true,
                    Message = Services.Translate.Resources.GetString("AnErrorOccurredPleaseTryAgain")
                };
                var jsonResponse = JsonConvert.SerializeObject(responseError, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return jsonResponse;
            }
        }
    }
}

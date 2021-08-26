using IconRecruitmentTest.Web.ViewModel;
using IconRecruitmentTest.Services.LogisticsCompany;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Threading;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using IconRecruitmentTest.Common.Message;
using IconRecruitmentTest.Services.Translate;
using IconRecruitmentTest.Web.Extensions;
using Newtonsoft.Json;
using IconRecruitmentTest.Services.Shipping;
using IconRecruitmentTest.Common.Models.DbModels;
using System.Threading.Tasks;

namespace IconRecruitmentTest.Web.Controllers
{
    public class HomeController : BaseController
    {
        #region Fields
        private readonly ILogisticsCompanyService _logisticsCompanyService;
        private readonly IShippingServices _shippingServices;
        
        private readonly ConfigData _configData;

        #endregion

        #region Ctx

        public HomeController(ILogisticsCompanyService logisticsCompanyService, IShippingServices shippingServices, ConfigData configData)
        {
            _logisticsCompanyService = logisticsCompanyService;
            _shippingServices = shippingServices;
            _configData = configData;
        }
        #endregion

        #region ActionResult

        public IActionResult Index()
        {
            var model = new LogisticsCompanyViewModel();
            try
            {
                model.companyData = _logisticsCompanyService.GetCompanyData();
                model.language = _logisticsCompanyService.GetLanguages();
                model.configData = _configData;
            }
            catch (Exception ex)
            {
                Logger.Error("Index", "HomeController.Index", ex);
            }
            return View(model);
        }

        public ActionResult GetLogisticsCompanyInfo(string inputData)
        {
            var model = new LogisticsCompanyViewModel();
            try
            {
                model.inputData = GetModelFromJson(inputData);
                model.configData = _configData;
            }
            catch (Exception ex)
            {
                Logger.Error("Get logistics company info", "HomeController.GetLogisticsCompanyInfo", ex);
            }
            return View("~/Views/Shared/LogisticsCompany/Index.cshtml", model);
        }

        [HttpPost]
        public ActionResult SetCulture(string lang)
        {
            var response = new ResponseMessage { Success = true };
            try
            {

                Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(lang)),
                    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );

                var currentUICulture = CultureInfo.CreateSpecificCulture(lang);
                currentUICulture.NumberFormat.NumberDecimalSeparator = ".";

                var currentCulture = CultureInfo.CreateSpecificCulture("en");

                Thread.CurrentThread.CurrentCulture = currentCulture;
                Thread.CurrentThread.CurrentUICulture = currentUICulture;

                response.CustomAction["ResourceObject"] = Resources.GetJsonResources().ToString();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = Resources.GetString("AnErrorOccurredPleaseTryAgain");
                Logger.Error("Set Culture", "HomeController.SetCulture", ex);
            }

            return Json(new
            {
                data = JsonConvertExtensions.GetJsonConvert(response)
            });
        }

        public async Task<ActionResult> SaveShipping(string inputData)
        {
            var response = new ResponseMessage { Success = true };
            var model = new InputData(); ;
            try {

                model = GetModelFromJson(inputData);

                // (TODO change) We can use automapper in this case
                var shippingData = new ShippingData {
                    companyType = model.logisticsCompany,
                    width = model.width, height=model.height,
                    depth = model.depth, weight = model.weight,
                    totaVolume=model.totaVolume, totalPrice =model.totalPrice,
                    CreationTime = DateTime.Now, LastModificationTime = DateTime.Now
                };
                response = (ResponseMessage) await  _shippingServices.SaveShippingData(shippingData);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = Resources.GetString("AnErrorOccurredPleaseTryAgain");
                Logger.Error("Save Shipping", "HomeController.SaveShipping", ex);
            }
            return Json(new
            {
                data = JsonConvertExtensions.GetJsonConvert(response)
            });
        }


        public InputData  GetModelFromJson(string jsonData)
        {
            var model = new InputData();
            try {
                if (!string.IsNullOrEmpty(jsonData)) model = JsonConvert.DeserializeObject<InputData>(jsonData);
            }
            catch (Exception ex)
            {
                Logger.Error("Get model from json", "HomeController.GetModelFromJson", ex);
            }
            return model;
        }
        #endregion
    }
}

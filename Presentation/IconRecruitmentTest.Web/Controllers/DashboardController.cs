using IconRecruitmentTest.Common.Common;
using IconRecruitmentTest.Common.Extensions;
using IconRecruitmentTest.Services.LogisticsCompany;
using IconRecruitmentTest.Services.Shipping;
using IconRecruitmentTest.Web.ViewModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace IconRecruitmentTest.Web.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class DashboardController : BaseController
    {
        #region Fields
        private readonly ILogisticsCompanyService _logisticsCompanyService;
        private readonly IShippingServices _shippingServices;

        #endregion


        #region Ctx

        public DashboardController(ILogisticsCompanyService logisticsCompanyService, IShippingServices shippingServices)
        {
            _logisticsCompanyService = logisticsCompanyService;
            _shippingServices = shippingServices;
        }
        #endregion

        #region ActionResult
        public IActionResult Index()
        {
            var model = new DashboardViewModel();
            try
            {
                var shippingData = _shippingServices.GetShippingData();

                var shippingDataGroupedByCompnay = shippingData.GroupBy(x => x.companyType);

                model.companyOrderData = shippingData.GroupBy(t => t.companyType)
                           .Select(t => new CompanyOrderData{
                               companyName = ((EnumLogisticsCompany)t.Key).Description(),
                               numberOfOrders = t.Count(),
                               totalPrice = t.Sum(ta => ta.totalPrice),
                           }).ToList();

               model.language = _logisticsCompanyService.GetLanguages();
            }
            catch (Exception ex)
            {
                Logger.Error("Index", "DashboardController.Index", ex);
            }
            return View(model);
        }

        #endregion

    }
}

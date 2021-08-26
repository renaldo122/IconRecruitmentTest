using IconRecruitmentTest.Common.Models.DbModels;
using IconRecruitmentTest.Services.Authentication;
using IconRecruitmentTest.Services.LogisticsCompany;
using IconRecruitmentTest.Web.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using IconRecruitmentTest.Services.Translate;

namespace IconRecruitmentTest.Web.Controllers
{
    public class AccountController : BaseController
    {
        #region Fields
        private readonly ILogisticsCompanyService _logisticsCompanyService;
        private readonly IAuthenticationServices _authenticationServices;
        
        #endregion


        #region Ctx

        public AccountController(ILogisticsCompanyService logisticsCompanyService, IAuthenticationServices authenticationServices)
        {
            _logisticsCompanyService = logisticsCompanyService;
            _authenticationServices = authenticationServices;
        }
        #endregion

        #region ActionResult
        public IActionResult LogIn()
        {
            var model = new AccountViewModel();
            try
            {
                model.language = _logisticsCompanyService.GetLanguages();

            }
            catch (Exception ex)
            {
                Logger.Error("Index", "AccountController.LogIn", ex);
            }
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> LogIn(AccountViewModel model)
        {
            try
            {
                model.language = _logisticsCompanyService.GetLanguages();
                if (ModelState.IsValid) {
                    var user = await _authenticationServices.GetUserByUserName(model.loginModel.Username);
                    if (user != null) {
                        PasswordHasher<Users> passwordHasher = new PasswordHasher<Users>();
                        var verified = passwordHasher.VerifyHashedPassword(user, user.Password, model.loginModel.Password);
                       if (verified.ToString() == "Success") { 
                            await SignInUser(model.loginModel.Username);
                            return RedirectToAction("Index", "Home");
                        }else {
                            ModelState.AddModelError("", Resources.GetString("UsernameOrPasswordIsIncorrect"));
                        }
                    }else {
                        ModelState.AddModelError("", Resources.GetString("UsernameOrPasswordIsIncorrect"));
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("LogIn", "AccountController.LogIn", ex);
            }
            return View(model);
        }
        private async Task SignInUser(string username)
        {
            var claims = new List<Claim>();
            try
            {
                claims.Add(new Claim(ClaimTypes.Name, username));
                var claimIdenties = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimPrincipal = new ClaimsPrincipal(claimIdenties);
                var authenticationManager = Request.HttpContext;
                await authenticationManager.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, new AuthenticationProperties() { IsPersistent = true });
            }
            catch (Exception ex) {
                Logger.Error("Sign In User", "AccountController.SignInUser", ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            try
            {
                var authenticationManager = Request.HttpContext;
 
                await authenticationManager.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch (Exception ex){
                Logger.Error("LogOff", "AccountController.LogOff", ex);
            }
            return RedirectToAction("Index", "Home");
        }
        #endregion

    }
}

using IconRecruitmentTest.Common.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IconRecruitmentTest.Services.Translate;
namespace IconRecruitmentTest.Web.ViewModel
{
    public class AccountViewModel
    {
        public AccountViewModel() {
            loginModel = new LogInViewModel();
            language = new List<Language>();
        }

        public LogInViewModel loginModel { get; set; }
        public List<Language> language { get; set; }

    }

    public class LogInViewModel
      {

        [Required(ErrorMessage = "Username is required")]
        [Display(Name = "Username")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}

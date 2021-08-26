using IconRecruitmentTest.Common.Models.DbModels;
using IconRecruitmentTest.Data.IconDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IconRecruitmentTest.Services.Authentication
{
    public class AuthenticationServices : BaseService, IAuthenticationServices
    {
        private ApplicationDbContext _applicationDbContext;

        public AuthenticationServices(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Users> GetUserByUserName(string userName)
        {
            try
            {
                var user= await _applicationDbContext.Users.Where(x=>x.Username.Equals(userName) && x.IsEnabled).FirstOrDefaultAsync();
                return user;

            }
            catch (Exception ex){
                Logger.Error("Get user by usename", "GetUserByUserName", ex);
            }
            return null;
        }

    }
}

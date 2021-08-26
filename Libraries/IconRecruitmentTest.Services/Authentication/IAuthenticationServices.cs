using IconRecruitmentTest.Common.Models.DbModels;
using System.Threading.Tasks;

namespace IconRecruitmentTest.Services.Authentication
{
    public interface IAuthenticationServices
    {

        /// <summary>
        /// GetUserByUserName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<Users> GetUserByUserName(string userName);
    }
}

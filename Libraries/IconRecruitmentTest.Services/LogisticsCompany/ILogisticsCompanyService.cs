using IconRecruitmentTest.Common.Models;
using System.Collections.Generic;

namespace IconRecruitmentTest.Services.LogisticsCompany
{
    public interface ILogisticsCompanyService
    {
        /// <summary>
        /// GetCompanyData
        /// </summary>
        /// <returns></returns>
        List<Company> GetCompanyData();


        /// <summary>
        /// GetLanguages
        /// </summary>
        /// <returns></returns>
        List<Language> GetLanguages();
    }
}

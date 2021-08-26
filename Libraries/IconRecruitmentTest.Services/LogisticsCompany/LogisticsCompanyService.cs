using IconRecruitmentTest.Common.Models;
using System;
using System.Collections.Generic;
using IconRecruitmentTest.Common.Common;
using IconRecruitmentTest.Common.Extensions;

namespace IconRecruitmentTest.Services.LogisticsCompany
{
    public class LogisticsCompanyService : BaseService, ILogisticsCompanyService
    {
       
        /// <inheritdoc />
        public List<Company> GetCompanyData()
        {
            var data = new List<Company>();
            try   {
                data.Add(new Company { Value = (int)EnumLogisticsCompany.Cargo4You, Text = EnumLogisticsCompany.Cargo4You.Description() });
                data.Add(new Company { Value = (int)EnumLogisticsCompany.ShipFaster, Text = EnumLogisticsCompany.ShipFaster.Description() });
                data.Add(new Company { Value = (int)EnumLogisticsCompany.MaltaShip, Text = EnumLogisticsCompany.MaltaShip.Description() });
            }
            catch(Exception ex)  {
                Logger.Error("Get company data", "GetCompanyData", ex);
            }
            return data;
        }


        /// <inheritdoc />
        public List<Language> GetLanguages()
        {
            var language = new List<Language>();
            try
            {
                language.Add(new Language { Value = LanguageType.English.Description(), Text = LanguageType.English.ToString() });
                language.Add(new Language { Value = LanguageType.Italian.Description(), Text = LanguageType.Italian.ToString() });
            }
            catch (Exception ex) {
                Logger.Error("get languages", "GetLanguages", ex);
            }
            return language;
        }
    }
}

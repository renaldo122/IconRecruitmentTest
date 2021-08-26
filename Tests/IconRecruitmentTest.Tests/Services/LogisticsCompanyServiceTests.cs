using IconRecruitmentTest.Tests.Base;
using IconRecruitmentTest.Tests.Extensions;
using IconRecruitmentTest.Tests.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace IconRecruitmentTest.Tests.Services
{
    [TestClass]
    public class LogisticsCompanyServiceTests : BaseTestInitalizer
    {
        [TestInitialize]
        public override void SetupTest()
        {
            ConfigurationHelper.BuildConfiguration();
        }


        [TestMethod]
        public void GetCompanyDataTest()
        {
            var listOfCompany = _logisticsCompanyService.GetCompanyData();
            listOfCompany.Count().ShouldEqual(Convert.ToInt32(ConfigurationHelper.NumberOfCompany));
        }


        [TestMethod]
        public void GetLanguagesTest()
        {
            var listOfFiles = _logisticsCompanyService.GetLanguages();
            listOfFiles.Count().ShouldEqual(Convert.ToInt32(ConfigurationHelper.NumberOfSupportedLanguages));
        }
    }
}

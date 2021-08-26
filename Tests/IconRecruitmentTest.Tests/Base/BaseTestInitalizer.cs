using IconRecruitmentTest.Data.IconDbContext;
using IconRecruitmentTest.Services.LogisticsCompany;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IconRecruitmentTest.Tests.Base
{
    [TestClass]
    public abstract class BaseTestInitalizer
    {
        #region Services

        public ILogisticsCompanyService _logisticsCompanyService;

        #endregion


        #region Initialize
        [TestInitialize]
        public virtual void Initialize(){
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "TestDatabaseToBeAdded").Options;
            var context = new ApplicationDbContext(options);
            _logisticsCompanyService = new LogisticsCompanyService();
        }

        #endregion


        #region Cleanup

        [TestCleanup]
        public void Cleanup()
        {
        }

        #endregion

        #region SetupTest

        public abstract void SetupTest();

        #endregion
    }
}

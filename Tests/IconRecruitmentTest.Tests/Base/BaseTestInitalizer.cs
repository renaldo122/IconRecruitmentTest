using IconRecruitmentTest.Data.IconDbContext;
using IconRecruitmentTest.Services.LogisticsCompany;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IconRecruitmentTest.Common.Models.DbModels;
using System;
using IconRecruitmentTest.Services.Authentication;
using System.Linq;
using System.Collections.Generic;
using IconRecruitmentTest.Services.Shipping;

namespace IconRecruitmentTest.Tests.Base
{
    [TestClass]
    public abstract class BaseTestInitalizer
    {
        #region Services

        public ILogisticsCompanyService _logisticsCompanyService;
        public IAuthenticationServices _authenticationServices;
        public IShippingServices _shippingServices;
        
        protected  ApplicationDbContext context;
        #endregion


        #region Initialize
        [TestInitialize]
        public virtual void Initialize(){
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
              .UseInMemoryDatabase(databaseName: "TestDatabase")
              .Options;

              using ( context = new ApplicationDbContext(options))  {
                if (!context.Users.Any())  {
                    context.Users.AddRange(GetFakeListOfUsers());
                    context.SaveChanges();
                }
                if (!context.ShippingData.Any()) {
                    context.ShippingData.AddRange(GetFakeListOfShippingData());
                    context.SaveChanges();
                }
            }
            context = new ApplicationDbContext(options);
            _authenticationServices = new AuthenticationServices(context);
            _shippingServices = new ShippingServices(context);
            _logisticsCompanyService = new LogisticsCompanyService();
        }

        #endregion
        
        private IEnumerable<Users> GetFakeListOfUsers()
        {
           var users = new List<Users> {
                new Users { Id = 1, Username = "Admin", Email = "admin@gmail.com", IsEnabled = true, CreationTime = DateTime.Now, LastModificationTime = DateTime.Now, Password = "" },
                new Users { Id = 2, Username = "Admin2", Email = "admin2@gmail.com", IsEnabled = true, CreationTime = DateTime.Now, LastModificationTime = DateTime.Now, Password = "" }
            };
            return users;
        }

        public IEnumerable<ShippingData> GetFakeListOfShippingData()
        {
            var shippingData = new List<ShippingData> {
                new ShippingData { Id = 1, companyType = 1,  depth=10, height=10,width =10 ,weight =10,totalPrice=16,totaVolume=1000,CreationTime = DateTime.Now, LastModificationTime = DateTime.Now },
                new ShippingData { Id = 2, companyType = 2,  depth=10, height=20,width =10 ,weight =10,totalPrice=16,totaVolume=2000,CreationTime = DateTime.Now, LastModificationTime = DateTime.Now },
                new ShippingData { Id = 3, companyType = 3,  depth=10, height=20,width =20 ,weight =10,totalPrice=16,totaVolume=4000,CreationTime = DateTime.Now, LastModificationTime = DateTime.Now },
             };
            return shippingData;
        }

        public ShippingData GetShippingDataToSave()
        {
            var shippingData = new ShippingData { Id = 4, companyType = 1, depth = 10, height = 10, width = 10, weight = 10, totalPrice = 16, totaVolume = 1000, CreationTime = DateTime.Now, LastModificationTime = DateTime.Now };
            return shippingData;
        }

         
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

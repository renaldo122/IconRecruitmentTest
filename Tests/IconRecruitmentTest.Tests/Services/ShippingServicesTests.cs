using IconRecruitmentTest.Tests.Base;
using IconRecruitmentTest.Tests.Extensions;
using IconRecruitmentTest.Tests.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace IconRecruitmentTest.Tests.Services
{
    [TestClass]
    public class ShippingServicesTests : BaseTestInitalizer
    {
        [TestInitialize]
        public override void SetupTest()
        {
            ConfigurationHelper.BuildConfiguration();
        }

        [TestMethod]
        public async Task SaveShippingDataTest()
        {

            var shippingData = GetShippingDataToSave();
            var result = await _shippingServices.SaveShippingData(shippingData);
            result.Success.ShouldBeTrue();

        }
        [TestMethod]
        public async Task SaveShippingNotSuccessTest()
        {

            var shippingData = GetShippingDataToSave();
            shippingData.Id = GetFakeListOfShippingData().ToList().FirstOrDefault().Id;
            var result = await _shippingServices.SaveShippingData(shippingData);
            result.Success.ShouldBeFalse();

        }
        [TestMethod]
        public void GetShippingDataTest()
        {
            var shipingData = _shippingServices.GetShippingData();
            shipingData.Count.ShouldNotEqual(0);

        }
    }
    
}

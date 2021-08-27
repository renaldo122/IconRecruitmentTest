using IconRecruitmentTest.Tests.Base;
using IconRecruitmentTest.Tests.Extensions;
using IconRecruitmentTest.Tests.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace IconRecruitmentTest.Tests.Services
{
    [TestClass]
    public class AuthenticationServicesTests : BaseTestInitalizer
    {
        [TestInitialize]
        public override void SetupTest()
        {
            ConfigurationHelper.BuildConfiguration();
        }


        [TestMethod]
        public async Task GetUserByUserNameTest()
        {
            var user = await _authenticationServices.GetUserByUserName(ConfigurationHelper.UserNameData);
            user.Username.ShouldEqual(ConfigurationHelper.UserNameData);

        }

        [TestMethod]
        public async Task UserNotFoundTest()
        {
            var user = await _authenticationServices.GetUserByUserName(ConfigurationHelper.UserNameDataNotFound);
            user.ShouldNull();
        }
    }
}

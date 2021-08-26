using Autofac;
using IconRecruitmentTest.Services.Authentication;
using IconRecruitmentTest.Services.LogisticsCompany;
using IconRecruitmentTest.Services.Shipping;

namespace IconRecruitmentTest.Web.Infrastructure
{
    public class DependencyRegisterServices : Module
    {

        /// <summary>
        /// Inject services and call on startup
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LogisticsCompanyService>().As<ILogisticsCompanyService>();
            builder.RegisterType<ShippingServices>().As<IShippingServices>();
            builder.RegisterType<AuthenticationServices>().As<IAuthenticationServices>();
            
        }
    }
}

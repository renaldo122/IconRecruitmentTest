using IconRecruitmentTest.Common.Common;
using IconRecruitmentTest.Common.Logging;
using IconRecruitmentTest.Common.Logging.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace IconRecruitmentTest.Web.Controllers
{
    public abstract class BaseController : Controller
    {

        #region Fields
        protected ILogger Logger { get; set; }
        #endregion

        #region Ctx
        protected BaseController()
        {
            Logger = LoggerFactory.Instance.GetLogger(ProjectsEnum.Web);
        }
        #endregion

    }
}

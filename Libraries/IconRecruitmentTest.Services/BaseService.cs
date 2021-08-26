using IconRecruitmentTest.Common.Common;
using IconRecruitmentTest.Common.Logging;
using IconRecruitmentTest.Common.Logging.Implementation;

namespace IconRecruitmentTest.Services
{
    public abstract class BaseService
    {
        #region Fields
        protected ILogger Logger { get; set; }

        #endregion

        #region Ctx
        protected BaseService()
        {
            Logger = LoggerFactory.Instance.GetLogger(ProjectsEnum.Services);
        }
        #endregion

    }
}

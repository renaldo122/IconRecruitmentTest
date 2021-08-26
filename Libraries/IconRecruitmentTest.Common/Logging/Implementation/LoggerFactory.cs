using IconRecruitmentTest.Common.Common;
using log4net;

namespace IconRecruitmentTest.Common.Logging.Implementation
{
    public class LoggerFactory
    {
        #region Fields
        public static readonly LoggerFactory Instance;
        #endregion

        #region Ctx
        static LoggerFactory()
        {
            Instance = new LoggerFactory();
        }
        #endregion

        #region Methods
        /// <summary>
        ///Log Error based on project 
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public ILogger GetLogger(ProjectsEnum project)
        {
            switch (project)
            {
                case ProjectsEnum.Web:
                    return new Logger(LogManager.GetLogger(ProjectsEnum.Web.ToString()));
                case ProjectsEnum.Services:
                    return new Logger(LogManager.GetLogger(ProjectsEnum.Services.ToString()));
            }
            return new NullLogger();
        }

        #endregion

    }
}

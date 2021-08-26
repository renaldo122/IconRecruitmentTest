using System.Collections;
using System.Resources;
using System.Text;
using System.Threading;
using IconRecruitmentTest.Common.Resources;

namespace IconRecruitmentTest.Services.Translate
{
    public class Resources
    {

        #region Fields
        private static Resources _instance;
        #endregion

        #region Ctx

        protected Resources()
        {
        }

        /// <summary>
        /// Create an singleton instance 
        /// </summary>
        public static Resources Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Resources();
                }

                return _instance;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// GetResourceManager
        /// </summary>
        /// <returns></returns>
        public ResourceManager GetResourceManager()
        {
            return GlobalStrings.ResourceManager;
        }

        /// <summary>
        /// GetString
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetString(string key)
        {
            ResourceManager rm = Instance.GetResourceManager();
            return rm.GetString(key);
        }

        /// <summary>
        /// Get all resources to convert on json object to access in javascript
        /// </summary>
        /// <returns></returns>
        public static StringBuilder GetJsonResources()
        {
            ResourceManager rm = GlobalStrings.ResourceManager;
            ResourceSet resourceSet = rm.GetResourceSet(Thread.CurrentThread.CurrentUICulture, true, true);

            var sbInitial = "{";
            var sb = new StringBuilder(sbInitial);

            foreach (DictionaryEntry resEnum in resourceSet)
            {
                if (sb.ToString() != sbInitial)
                {
                    sb.Append(",");
                }
                sb.Append("\"" + resEnum.Key + "\":\"" + resEnum.Value.ToString().Replace("\r\n", "").Replace("\"", "\\\"") + "\"");
            }
            sb.Append("}");
            return sb;
        }
        #endregion
    }
}

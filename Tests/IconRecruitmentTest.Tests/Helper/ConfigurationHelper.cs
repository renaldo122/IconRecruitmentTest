using Microsoft.Extensions.Configuration;
using System.IO;

namespace IconRecruitmentTest.Tests.Helper
{
    public class ConfigurationHelper
    {
        #region Fields
        public static string NumberOfCompany => ConfigurationRoot[nameof(NumberOfCompany)];
        public static string NumberOfSupportedLanguages => ConfigurationRoot[nameof(NumberOfSupportedLanguages)];
        public static string UserNameData => ConfigurationRoot[nameof(UserNameData)];
        public static string UserNameDataNotFound => ConfigurationRoot[nameof(UserNameDataNotFound)];
        
        #endregion

        #region Interface

        public static IConfigurationRoot ConfigurationRoot { get; private set; }

        #endregion

        #region Methods
        /// <summary>
        /// Build Configuration
        /// Get json file configuration 
        /// </summary>
        public static void BuildConfiguration()
        {
            if (ConfigurationRoot != null)
            {
                return;
            }
            var folder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName.Replace("\\bin", string.Empty)
                + "\\" + "Configuration";


            IConfigurationBuilder builder = new ConfigurationBuilder().
                SetBasePath(folder).
                AddJsonFile("config.json", false).AddEnvironmentVariables();

            ConfigurationRoot = builder.Build();
        }


        #endregion

    }
}

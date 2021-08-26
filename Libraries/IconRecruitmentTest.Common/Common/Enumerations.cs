using System.ComponentModel;

namespace IconRecruitmentTest.Common.Common
{
    public enum EnumLogisticsCompany
    {
        [Description("Cargo4You")]
        Cargo4You = 1,
        [Description("ShipFaster")]
        ShipFaster = 2,
        [Description("MaltaShip")]
        MaltaShip = 3
    }

    public enum ParcelType
    {
        [Description("Dimensions")]
        Dimensions = 1,
        [Description("Weight")]
        Weight = 2
    }
    public enum CompanyInfo
    {
        [Description("ParcelInfo")]
        ParcelInfo = 1,
        [Description("ParcelValidation")]
        ParcelValidation = 2
    }
    public enum MinMaxType
    {
        [Description("Min")]
        Min = 1,
        [Description("Max")]
        Max = 2
    }

    public enum ProjectsEnum
    {
        Services,
        Web
    }

    public enum LogLevel
    {
        [Description("Information")]
        Information = 20,
        [Description("Error")]
        Error = 40,
    }

    public enum LanguageType
    {
        [Description("en-US")]
        English,
        [Description("it")]
        Italian,       
    }
}

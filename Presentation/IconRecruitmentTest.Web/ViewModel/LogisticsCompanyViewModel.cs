using IconRecruitmentTest.Common.Common;
using IconRecruitmentTest.Common.Models;
using System.Collections.Generic;

namespace IconRecruitmentTest.Web.ViewModel
{
    public class LogisticsCompanyViewModel
    {
        public LogisticsCompanyViewModel() {
            companyData = new List<Company>();
            language = new List<Language>();
            configData = new ConfigData();
            inputData = new InputData();
        }
    
        public List<Company> companyData { get; set; }
        public List<Language> language { get; set; }
        public ConfigData configData { get; set; }
        public InputData inputData { get; set; }
        
    }

    /// <summary>
    /// ConfigData class for all configuration in test
    /// </summary>
    public class ConfigData
    {
        public Cargo4You cargo4You { get; set; }
        public ShipFaster shipFaster { get; set; }
        public MaltaShip maltaShip { get; set; }
    }
    public class InputData
    {
        public int logisticsCompany { get; set; } = (int)EnumLogisticsCompany.Cargo4You;
        public float width { get; set; }
        public float height { get; set; }
        public float depth { get; set; }
        public float weight { get; set; }
        public float totaVolume { get; set; }
        public float totalPrice { get; set; }
        
    }
    public class Cargo4You
    {
        public Cargo4YouValidation cargo4YouValidation { get; set; }
        public Cargo4YouPrices cargo4YouPrices { get; set; }
    }
    public class Cargo4YouValidation
    {
        public int DimensionsMin { get; set; }
        public float DimensionsMax { get; set; }
        public int WeightMin { get; set; }
        public float WeightMax { get; set; } 
    }
    public class Cargo4YouPrices
    {
        public float Dimensions_Less_Than_1000cm { get; set; } 
        public float Dimensions_Between_1000cm_and_2000cm { get; set; }
        public float Weight_Less_Than_2kg { get; set; } 
        public float Weight_Between_2kg_and_15kg { get; set; }
        public float Weight_Between_Than_15kg_and_20kg { get; set; } 
    }
    public class ShipFaster
    {
        public ShipFasterValidation shipFasterValidation { get; set; }
        public ShipFasterPrices shipFasterPrices { get; set; }
    }
    public class ShipFasterValidation
    {
        public int DimensionsMin { get; set; } 
        public float DimensionsMax { get; set; } 
        public int WeightMin { get; set; }
        public float WeightMax { get; set; }
       
    }
    public class ShipFasterPrices
    {
        public float Dimensions_Less_Than_1000cm { get; set; } 
        public float Dimensions_Between_1000cm_and_1700cm { get; set; } 
        public float Weight_Between_10kg_and_15kg { get; set; }
        public float Weight_Between_15kg_and_25kg { get; set; } 
        public float Weight_Over_25kg { get; set; }
        public float Weight_Extra_1Kg_Over_25 { get; set; } 
    }
    public class MaltaShip
    {
        public MaltaShipValidation maltaShipValidation { get; set; }
        public MaltaShipPrices maltaShipPrices { get; set; }
    }
    public class MaltaShipValidation
    {
        public int DimensionsMin { get; set; } 
        public float DimensionsMax { get; set; } 
        public int WeightMin { get; set; } 
        public float WeightMax { get; set; }
    }
    public class MaltaShipPrices
    {
        public float Dimensions_Less_Than_1000cm { get; set; }
        public float Dimensions_Between_1000cm_and_2000cm { get; set; }
        public float Dimensions_Between_2000cm_and_5000cm { get; set; } 
        public float Dimensions_Over_5000cm { get; set; }
        public float Weight_Between_10kg_and_20kg { get; set; }
        public float Weight_Between_20kg_and_30kg { get; set; }
        public float Weight_Over_30kg{ get; set; }
        public float Weight_Extra_1Kg_Over_30Kg { get; set; }  //Any parcel > 30Kg costs €43.99 plus €0.41 for every  Kg over 25Kg (Belive is price for 1 kg over 30 Kg)
    }
}

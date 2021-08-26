using IconRecruitmentTest.Common.Common;
using IconRecruitmentTest.Web.ViewModel;
using System;
using IconRecruitmentTest.Services.Translate;

namespace IconRecruitmentTest.Web.Common
{
    public static class LogisticsCompanyCalculationData
    {
        /// <summary>
        /// GetContectInfo
        /// </summary>
        /// <param name="logisticsCompany"></param>
        /// <param name="parcelType"></param>
        /// <returns></returns>
        public static string GetContentInfo(int logisticsCompany, int parcelType, int companyInfo)
        {
            var dataContent =Resources.GetString("NoInfo");
            try
            {
                switch (logisticsCompany)
                {
                    case (int)EnumLogisticsCompany.Cargo4You:
                        if (companyInfo == (int)CompanyInfo.ParcelInfo)
                        {
                            if (parcelType == (int)ParcelType.Dimensions)
                                dataContent = "<div>"+Resources.GetString("BasedOnDimensions") +"<ul><li>" + Resources.GetString("Dimensions_Less_Than_1000cm")+"</li> <li>" + Resources.GetString("Dimensions_Between_1000cm_and_2000cm") + " </li></ul></div>";
                            else
                                dataContent = "<div>" + Resources.GetString("BasedOnWeight") + "<ul><li>" + Resources.GetString("Weight_Less_Than_2kg") + "</li> <li>" + Resources.GetString("Weight_Between_2kg_and_15kg") + "</li><li>" + Resources.GetString("Weight_Between_Than_15kg_and_20kg") + "</li></ul></div>";
                        }
                        else {
                            if (parcelType == (int)ParcelType.Dimensions)  dataContent = "<div>" + Resources.GetString("Cargo4YouValidationDimension") + "<div>";
                            else dataContent = Resources.GetString("Cargo4YouValidationWeight");
                        }
                        break;
                    case (int)EnumLogisticsCompany.ShipFaster:
                        if (companyInfo == (int)CompanyInfo.ParcelInfo)
                        {
                            if (parcelType == (int)ParcelType.Dimensions)
                            dataContent = "<div>" + Resources.GetString("BasedOnDimensions") + " <ul><li>" + Resources.GetString("SHF_Dimensions_Less_Than_1000cm") + " </li> <li>" + Resources.GetString("Dimensions_Between_1000cm_and_1700cm") + " </li></ul></div>";
                        else
                            dataContent = "<div>" + Resources.GetString("BasedOnWeight") + " <ul><li>" + Resources.GetString("Weight_Between_10kg_and_15kg") + " </li> <li>" + Resources.GetString("Weight_Between_15kg_and_25kg") + "</li><li>" + Resources.GetString("Weight_Over_25kg") + "</li></ul></div>";
                        }
                        else
                        {
                            if (parcelType == (int)ParcelType.Dimensions) dataContent = "<div>"+ Resources.GetString("ShipFasterValidationDimension")+ "<div>";
                            else dataContent = Resources.GetString("ShipFasterValidationWeight");
                        }
                        break;
                    case (int)EnumLogisticsCompany.MaltaShip:
                        if (companyInfo == (int)CompanyInfo.ParcelInfo)
                        {
                            if (parcelType == (int)ParcelType.Dimensions)
                                dataContent = "<div>" + Resources.GetString("BasedOnDimensions") + "<ul><li>" + Resources.GetString("MSHDimensions_Less_Than_1000cm") + "</li> <li>" + Resources.GetString("MSHDimensions_Between_1000cm_and_2000cm") + " </li> <li>" + Resources.GetString("Dimensions_Between_2000cm_and_5000cm") + "</li><li>" + Resources.GetString("Dimensions_Over_5000cm") + "</li></ul></div>";
                            else
                                dataContent = "<div>" + Resources.GetString("BasedOnWeight") + " <ul><li>" + Resources.GetString("MSHWeight_Between_10kg_and_20kg") + " </li> <li>" + Resources.GetString("Weight_Between_20kg_and_30kg") + "</li><li>"+ Resources.GetString("Weight_Over_30kg") + "</li></ul></div>";
                            break;
                        }
                        else{
                            if (parcelType == (int)ParcelType.Dimensions) dataContent = "<div>" + Resources.GetString("MaltaShipValidationDimension") + "<div>";
                            else dataContent = Resources.GetString("MaltaShipValidationWeight"); 
                        }
                        break;
                }
                return dataContent;
            }
            catch (Exception ex)
            {
                //Log error
                return dataContent;
            }
          
        }


        /// <summary>
        /// GetMinValueBasedOnLogisticCompany
        /// </summary>
        /// <param name="model"></param>
        /// <param name="minMaxType"></param>
        /// <returns></returns>
        public static float GetMinValueBasedOnLogisticCompany(LogisticsCompanyViewModel model, int minMaxType)
        {
            float minValue = 0;
            try
            {
                switch (model.inputData.logisticsCompany)  {
                    case (int)EnumLogisticsCompany.Cargo4You:
                            minValue = minMaxType == (int)MinMaxType.Min ? model.configData.cargo4You.cargo4YouValidation.WeightMin :
                                   model.configData.cargo4You.cargo4YouValidation.WeightMax;
                        break;
                    case (int)EnumLogisticsCompany.ShipFaster:
                            minValue = minMaxType == (int)MinMaxType.Min ? model.configData.shipFaster.shipFasterValidation.WeightMin :
                            model.configData.shipFaster.shipFasterValidation.WeightMax;
                        break;
                    case (int)EnumLogisticsCompany.MaltaShip:
                            minValue = minMaxType == (int)MinMaxType.Min ? model.configData.maltaShip.maltaShipValidation.WeightMin :
                            model.configData.shipFaster.shipFasterValidation.WeightMax;
                        break;
                }
                return minValue;
            }
            catch (Exception ex) {
                //Log error
                return minValue;
            }
            
        }
    }
}

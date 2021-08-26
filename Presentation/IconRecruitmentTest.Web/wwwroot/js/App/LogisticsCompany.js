
$(function () {
    var LogisticsCompany = {};

    LogisticsCompany.State = {
        logisticsCompany: enums.EnumLogisticsCompany.Cargo4You,
        width: 0,
        height: 0,
        depth: 0,
        weight: 0,
        totalVolume: 0,
        totalPriceDim: 0,
        totalPriceWeight: 0,
        isValid: false,
        ResourceObject: {}
    };

    LogisticsCompany.OnChangeLogisticsCompany = function (value) {
        try {
            if (Helper.StringIsNullOrEmpty(value)) value = 0;
            LogisticsCompany.State.logisticsCompany = Helper.ParseToInt(String(value));
            var inputData = LogisticsCompany.GetJsonData();
            $.ajax({
                type: "POST",
                url: "/Home/GetLogisticsCompanyInfo",
                dataType: 'html',
                data: {
                    inputData: inputData
                },
                success: function (content) {
                    if (LogisticsCompany.State.logisticsCompany > 0) {
                        $("#LogisticsCompanyInfo").css("display", "block");
                    } else {
                        $("#LogisticsCompanyInfo").css("display", "none");
                    }
                    $('#LogisticsCompanyInfoData div.company-data').html(content);
                    Helper.AddPopover();
                    LogisticsCompany.OnChangeInputElementNumber();
                },
                error: function (ex) {
                    Helper.log(ex);
                }
            });
        } catch (ex) {
            Helper.log(ex);
        }
    };

    LogisticsCompany.OnChangeInputElementNumber = function () {
        try {
            LogisticsCompany.FillStateData();
            var minValDimension = LogisticsCompany.GetValidationMinMaxOnCompany(enums.ParcelType.Dimensions, enums.MinMaxType.Min);
            var maxValDimension = LogisticsCompany.GetValidationMinMaxOnCompany(enums.ParcelType.Dimensions, enums.MinMaxType.Max);
            var isTotalVolumeValid = LogisticsCompany.State.totalVolume >= minValDimension && LogisticsCompany.State.totalVolume <= maxValDimension;
            if (maxValDimension === enums.ConditionNumber.CondMaxValue) isTotalVolumeValid = LogisticsCompany.State.totalVolume >= minValDimension

            var minValWeight = LogisticsCompany.GetValidationMinMaxOnCompany(enums.ParcelType.Weight, enums.MinMaxType.Min);
            var maxValWeight = LogisticsCompany.GetValidationMinMaxOnCompany(enums.ParcelType.Weight, enums.MinMaxType.Max);
            var isWeightValid = LogisticsCompany.State.weight >= minValWeight && LogisticsCompany.State.weight <= maxValWeight;
            if (maxValWeight === enums.ConditionNumber.CondMaxValue) isWeightValid = LogisticsCompany.State.weight >= minValWeight

            if (
                (LogisticsCompany.State.weight > 0 && LogisticsCompany.State.totalVolume > 0) && isTotalVolumeValid && isWeightValid) {
                LogisticsCompany.GetPriceBasedOnCompany(enums.ParcelType.Dimensions);
                LogisticsCompany.GetPriceBasedOnCompany(enums.ParcelType.Weight);

                Helper.SetLabelText("form_total_volume", LogisticsCompany.State.totalVolume);
                Helper.SetLabelText("form_total_weight", LogisticsCompany.State.weight);
                Helper.SetLabelText("form_total_cost", Helper.GetMaxNumber(LogisticsCompany.State.totalPriceDim, LogisticsCompany.State.totalPriceWeight));
                LogisticsCompany.State.isValid = true;

            } else {
                LogisticsCompany.State.isValid = false;
                LogisticsCompany.ResetLabelTotalInfo();
                Helper.EnableDisableById("BtnSendShipping", false);
            }
            Helper.SetDispalyButton("DimensionsValidation", !isTotalVolumeValid);
            Helper.SetDispalyButton("WeightValidation", !isWeightValid);
            Helper.EnableDisableById("BtnSendShipping", LogisticsCompany.State.isValid);
        } catch (ex) {
            Helper.log(ex);
        }
    }

    LogisticsCompany.FillStateData = function () {
        try {
            LogisticsCompany.State.width = Helper.ParseToFloat(Helper.GetValueById("form_width"));
            LogisticsCompany.State.height = Helper.ParseToFloat(Helper.GetValueById("form_height"));
            LogisticsCompany.State.depth = Helper.ParseToFloat(Helper.GetValueById("form_depth"));
            LogisticsCompany.State.weight = Helper.ParseToFloat(Helper.GetValueById("form_weight"));
            LogisticsCompany.State.totalVolume = Helper.CalculateVolume(LogisticsCompany.State.width, LogisticsCompany.State.height, LogisticsCompany.State.depth);
        } catch (ex) {
            Helper.log(ex);
        }
    }

    LogisticsCompany.ResetLabelTotalInfo = function () {
        try {
            Helper.SetLabelText("form_total_volume", 0);
            Helper.SetLabelText("form_total_cost", 0);
        } catch (ex) {
            Helper.log(ex);
        }
    }

    LogisticsCompany.GetValidationMinMaxOnCompany = function (parcelType, minMax) {
        var value = 0;
        try {
            switch (LogisticsCompany.State.logisticsCompany) {
                case enums.EnumLogisticsCompany.Cargo4You:
                    if (parcelType == enums.ParcelType.Dimensions) {
                        value = (minMax == enums.MinMaxType.Min) ? configData.cargo4You.cargo4YouValidation.dimensionsMin :
                            configData.cargo4You.cargo4YouValidation.dimensionsMax;
                    } else {
                        value = (minMax == enums.MinMaxType.Min) ? configData.cargo4You.cargo4YouValidation.weightMin :
                            configData.cargo4You.cargo4YouValidation.weightMax;
                    }
                    break;
                case enums.EnumLogisticsCompany.ShipFaster:
                    if (parcelType == enums.ParcelType.Dimensions) {
                        value = (minMax == enums.MinMaxType.Min) ? configData.shipFaster.shipFasterValidation.dimensionsMin :
                            configData.shipFaster.shipFasterValidation.dimensionsMax;
                    } else {
                        value = (minMax == enums.MinMaxType.Min) ? configData.shipFaster.shipFasterValidation.weightMin :
                            configData.shipFaster.shipFasterValidation.weightMax;
                    }
                    break;
                case enums.EnumLogisticsCompany.MaltaShip:
                    if (parcelType == enums.ParcelType.Dimensions) {
                        value = (minMax == enums.MinMaxType.Min) ? configData.maltaShip.maltaShipValidation.dimensionsMin :
                            configData.maltaShip.maltaShipValidation.dimensionsMax;
                    } else {
                        value = (minMax == enums.MinMaxType.Min) ? configData.maltaShip.maltaShipValidation.weightMin :
                            configData.maltaShip.maltaShipValidation.weightMax;
                    }
                    break;
            }
            return value;
        } catch (ex) {
            Helper.log(ex);
        }
    }

    LogisticsCompany.GetPriceBasedOnCompany = function (parcelType) {
        var totalPrice = 0;
        try {
            switch (LogisticsCompany.State.logisticsCompany) {
                case enums.EnumLogisticsCompany.Cargo4You:
                    if (parcelType == enums.ParcelType.Dimensions) {
                        if (LogisticsCompany.State.totalVolume <= enums.ConditionNumber.Cond1000) {
                            totalPrice = configData.cargo4You.cargo4YouPrices.dimensions_Less_Than_1000cm;
                        } else if (Helper.IsNumberBetween(LogisticsCompany.State.totalVolume, enums.ConditionNumber.Cond1000, enums.ConditionNumber.Cond2000)) {
                            totalPrice = configData.cargo4You.cargo4YouPrices.dimensions_Between_1000cm_and_2000cm;
                        }
                    } else {
                        if (LogisticsCompany.State.weight <= enums.ConditionNumber.Cond2) {
                            totalPrice = configData.cargo4You.cargo4YouPrices.weight_Less_Than_2kg;
                        } else if (Helper.IsNumberBetween(LogisticsCompany.State.weight, enums.ConditionNumber.Cond2, enums.ConditionNumber.Cond15)) {
                            totalPrice = configData.cargo4You.cargo4YouPrices.weight_Between_2kg_and_15kg;
                        } else if (Helper.IsNumberBetween(LogisticsCompany.State.weight, enums.ConditionNumber.Cond15, enums.ConditionNumber.Cond20)) {
                            totalPrice = configData.cargo4You.cargo4YouPrices.weight_Between_Than_15kg_and_20kg;
                        }
                    }
                    break;
                case enums.EnumLogisticsCompany.ShipFaster:
                    if (parcelType == enums.ParcelType.Dimensions) {
                        if (LogisticsCompany.State.totalVolume <= enums.ConditionNumber.Cond1000) {
                            totalPrice = configData.shipFaster.shipFasterPrices.dimensions_Less_Than_1000cm;
                        } else if (Helper.IsNumberBetween(LogisticsCompany.State.totalVolume, enums.ConditionNumber.Cond1000, enums.ConditionNumber.Cond1700)) {
                            totalPrice = configData.shipFaster.shipFasterPrices.dimensions_Between_1000cm_and_1700cm;
                        }
                    } else {
                        if (Helper.IsNumberBetween(LogisticsCompany.State.weight, enums.ConditionNumber.Cond10, enums.ConditionNumber.Cond15)) {
                            totalPrice = configData.shipFaster.shipFasterPrices.weight_Between_10kg_and_15kg;
                        } else if (Helper.IsNumberBetween(LogisticsCompany.State.weight, enums.ConditionNumber.Cond15, enums.ConditionNumber.Cond25)) {
                            totalPrice = configData.shipFaster.shipFasterPrices.weight_Between_15kg_and_25kg;
                        } else if (LogisticsCompany.State.weight > enums.ConditionNumber.Cond25) {
                            totalPrice = configData.shipFaster.shipFasterPrices.weight_Over_25kg
                                + LogisticsCompany.GetExtraPriceForExtraWeight(LogisticsCompany.State.weight, enums.ConditionNumber.Cond25,
                                    configData.shipFaster.shipFasterPrices.weight_Extra_1Kg_Over_25);  //add extra 1 kg                          
                        }
                    }
                    break;
                case enums.EnumLogisticsCompany.MaltaShip:
                    if (parcelType == enums.ParcelType.Dimensions) {
                        if (LogisticsCompany.State.totalVolume <= enums.ConditionNumber.Cond1000) {
                            totalPrice = configData.maltaShip.maltaShipPrices.dimensions_Less_Than_1000cm
                        } else if (Helper.IsNumberBetween(LogisticsCompany.State.totalVolume, enums.ConditionNumber.Cond1000, enums.ConditionNumber.Cond2000)) {
                            totalPrice = configData.maltaShip.maltaShipPrices.dimensions_Between_1000cm_and_2000cm;
                        }
                        else if (Helper.IsNumberBetween(LogisticsCompany.State.totalVolume, enums.ConditionNumber.Cond2000, enums.ConditionNumber.Cond5000)) {
                            totalPrice = configData.maltaShip.maltaShipPrices.dimensions_Between_2000cm_and_5000cm;
                        }
                        else if (enums.ConditionNumber.Cond5000 < LogisticsCompany.State.totalVolume) {
                            totalPrice = configData.maltaShip.maltaShipPrices.dimensions_Over_5000cm;
                        }
                    } else {
                        if (Helper.IsNumberBetween(LogisticsCompany.State.weight, enums.ConditionNumber.Cond10, enums.ConditionNumber.Cond20)) {
                            totalPrice = configData.maltaShip.maltaShipPrices.weight_Between_10kg_and_20kg
                        } else if (Helper.IsNumberBetween(LogisticsCompany.State.weight, enums.ConditionNumber.Cond20, enums.ConditionNumber.Cond30)) {
                            totalPrice = configData.maltaShip.maltaShipPrices.weight_Between_20kg_and_30kg;
                        }
                        else if (LogisticsCompany.State.weight > enums.ConditionNumber.Cond30) {
                            totalPrice = configData.maltaShip.maltaShipPrices.weight_Over_30kg +
                                LogisticsCompany.GetExtraPriceForExtraWeight(LogisticsCompany.State.weight, enums.ConditionNumber.Cond30,
                                    configData.shipFaster.shipFasterPrices.weight_Extra_1Kg_Over_25);  //add extra 1 kg
                        }
                    }
                    break;
            }

        } catch (ex) {
            Helper.log(ex);
        }
        totalPrice = Number(totalPrice.toFixed(3));
        if (parcelType == enums.ParcelType.Dimensions) LogisticsCompany.State.totalPriceDim = totalPrice;
        else LogisticsCompany.State.totalPriceWeight = totalPrice;
        return totalPrice;
    }

    LogisticsCompany.GetExtraPriceForExtraWeight = function (maxWeight, totalWeight, overPrice) {
        var extraPrice = 0;
        try {
            var extraWeight = Math.floor(maxWeight - (totalWeight))
            if (extraWeight > 0) extraPrice = extraWeight * overPrice
            if (extraPrice < 0) extraPrice = 0;
        } catch (ex) {
            Helper.log(ex);
        }
        return Helper.ParseToFloat(extraPrice);
    }

    LogisticsCompany.SaveShipping = function () {
        try {
            var inputData = LogisticsCompany.GetJsonData();
            $.ajax({
                type: "POST",
                url: "/Home/SaveShipping",
                dataType: "json",
                data: {
                    inputData: inputData
                },
                success: function (response) {
                    var res = JSON.parse(response.data);
                    if (res.Success) {
                        Helper.SetNotification(res.Message, 'success', 3500);
                    } else {
                        Helper.SetNotification(res.Message, 'error', 3500);
                    }
                },
                error: function (ex) {
                    Helper.log(ex);
                }
            });
        } catch (ex) {
            Helper.log(ex);
        }
    }

    LogisticsCompany.SetLanguage = function (lang) {
        try {
            $.ajax({
                type: "POST",
                url: "/Home/SetCulture",
                dataType: "json",
                data: {
                    lang: lang
                },
                success: function (response) {
                    var res = JSON.parse(response.data);
                    LogisticsCompany.State.ResourceObject = JSON.parse(res.CustomAction.ResourceObject);
                    if (res.Success) {
                        if (Helper.ContainString(window.location.pathname, "Dashboard")) {
                            LoadDashboardData();
                        } else {
                            if (LogisticsCompany.State.logisticsCompany > 0) {
                                LogisticsCompany.OnChangeLogisticsCompany(LogisticsCompany.State.logisticsCompany);
                            }
                        }
                        if (!jQuery.isEmptyObject(LogisticsCompany.State.ResourceObject)) {
                            Helper.SetLabelText("lblHome", LogisticsCompany.State.ResourceObject.Home);
                            Helper.SetLabelText("lblLogisticsCompany", LogisticsCompany.State.ResourceObject.LogisticsCompany);
                            Helper.SetLabelText("ddlSelectOptions", LogisticsCompany.State.ResourceObject.Select);
                            Helper.SetLabelText("lblDashboard", LogisticsCompany.State.ResourceObject.Dashboard);
                            Helper.SetLabelText("lblLogin", LogisticsCompany.State.ResourceObject.Login);
                            Helper.SetLabelText("lblLogout", LogisticsCompany.State.ResourceObject.Logout);
                            Helper.SetLabelText("lblLoginInfo", LogisticsCompany.State.ResourceObject.UseALocalAccountToLogIn);
                            Helper.SetLabelText("lblUsername", LogisticsCompany.State.ResourceObject.Username);
                            Helper.SetLabelText("lblPassword", LogisticsCompany.State.ResourceObject.Password);
                        }
                    } else {
                        Helper.SetNotification(res.Message, 'warning', 3500);
                    }
                },
                error: function (ex) {
                    Helper.log(ex);
                }
            });
        } catch (ex) {
            Helper.log(ex);
        }
    }

    LogisticsCompany.GetJsonData = function () {
        try {
            var inputData = {
                logisticsCompany: LogisticsCompany.State.logisticsCompany,
                width: LogisticsCompany.State.width,
                height: LogisticsCompany.State.height,
                depth: LogisticsCompany.State.depth,
                weight: LogisticsCompany.State.weight,
                totaVolume: LogisticsCompany.State.totalVolume,
                totalPrice: Helper.GetMaxNumber(LogisticsCompany.State.totalPriceDim, LogisticsCompany.State.totalPriceWeight),
            }
        } catch (ex) {
            Helper.log(ex);
        }
        return JSON.stringify(inputData);
    }

    window.LogisticsCompany = LogisticsCompany;
});

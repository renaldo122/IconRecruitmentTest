
var Helper = {

    log: function (message) {
        //log ex
        if (window.console) window.console.log(message);
    },
    StringIsNullOrEmpty: function (str) {
        try {
            return (!str || str.length === 0);
        } catch (ex) {
            Helper.log(ex);
            return true;
        }
    },
    ContainString: function (str,str1) {
        try {
           return str.toLowerCase().includes(str1.toLowerCase())
        } catch (ex) {
            Helper.log(ex);
            return false;
        }
    },
    ParseToInt: function (s) {
        try {
            s = s.replace(/[^\d,.-]/g, ''); // strip everything except numbers, dots, commas and negative sign
            if (navigator.language.substring(0, 2) !== "de" && /^-?(?:\d+|\d{1,3}(?:,\d{3})+)(?:\.\d+)?$/.test(s)) // if not in German locale and matches #,###.######
            {
                s = s.replace(/,/g, ''); // strip out commas
                return parseInt(s); // convert to number
            }
            else if (/^-?(?:\d+|\d{1,3}(?:\.\d{3})+)(?:,\d+)?$/.test(s)) // either in German locale or not match #,###.###### and now matches #.###,########
            {
                s = s.replace(/\./g, ''); // strip out dots
                s = s.replace(/,/g, '.'); // replace comma with dot
                return parseInt(s);
            }
            else // try #,###.###### anyway
            {
                s = s.replace(/,/g, ''); // strip out commas
                return parseInt(s); // convert to number
            }
        } catch (ex) {
            Helper.log(ex);
            return 0;
        }
    },
    ParseToFloat: function (s) {
        var value = 0;
        try {
            value = parseFloat(s);
            if (value == null || typeof value == "undefined" || isNaN(value)) value = 0;
            return value;
        } catch (ex) {
            Helper.log(ex);
            return value;
        }
    },
    AddPopover: function () {
        try {
            $('[data-toggle="popover"]').popover({
                placement: 'right',
                trigger: 'hover'
            });
        } catch (ex) {
            Helper.log(ex);
        }
    },

    GetValueById: function (id) {
        var value = "";
        try {
            value = $("#" + id).val();
            if (value == null || typeof value == "undefined" || isNaN(value)) value = "";
            return value;
        } catch (ex) {
            Helper.log(ex);
            return "";
        }
    },
    EnableDisableById: function (id, enable) {
        try {
            if (!enable) {
                $("#" + id).attr('disabled', 'disabled');
            } else {
                $("#" + id).removeAttr('disabled');
            }
        } catch (ex) {
            Helper.log(ex);
        }
    },
    SetLabelText: function (id, text) {
        try {
            $("#" + id).text(text);
        } catch (ex) {
            Helper.log(ex);
        }
    },
    SetDispalyButton: function (id, display) {
        try {
            if (display) {
                $("#" + id).css("display", "block");
            } else {
                $("#" + id).css("display", "none");
            }
        } catch (ex) {
            Helper.log(ex);
        }
    },
    GetMaxNumber: function (val1, val2) {
        var maxVal = 0;
        try {
            return Math.max(val1, val2);
        } catch (ex) {
            Helper.log(ex);
            return maxVal;
        }
    },
    IsNumberBetween: function (num, minVal, maxVal) {
        var isBetween = false;
        try {
            return num > minVal && num <= maxVal;
        } catch (ex) {
            Helper.log(ex);
            return isBetween;
        }
    },
    CalculateVolume: function (width = 0, depth = 0, height = 0) {
        try {
            return width * depth * height;
        } catch (ex) {
            Helper.log(ex);
            return -1;
        }
    },
    SetNotification: function (message, messagetype, timeout) {
        try {
          if (Helper.StringIsNullOrEmpty(message))
            return;
        if (timeout == null) timeout = 2000;
        var options = {
            timeOut: timeout,
            closeButton: true,
            progressBar: true,
            preventDuplicates: true
        }
        if ((typeof message) == 'string') {
            switch (messagetype) {
                case "success":
                    toastr.success(message, '', options);
                    break;
                case "error":
                    toastr.error(message, '', options);
                    break;
                case "warning":
                    toastr.warning(message, '', options);
                    break;
                case "info":
                    toastr.info(message, '', options);
                    break;

                default:
                    toastr.success(message, '', options);
            }
        }
        else {
            message.forEach(function (value, index) {
                delete message[index];
                Notification.SetNotification(value, messagetype, timeout);
            });
            }
        } catch (ex) {
            Helper.log(ex);
        }
    },
}


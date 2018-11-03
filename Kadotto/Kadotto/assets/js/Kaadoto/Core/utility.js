
/*
*
* Last modified Date: May. 02, 2016
* Last modified by:Fatemeh Nasiri
* Last Modified :add new method for scrolling to element 
*/

$(function () {
    $.utility = {};
    //# array ,item
    /*
    description:
    do not hide an element if it is hidden several times unless u call the methodseveral time
    */
    $.utility.loderhiding = 0;
    $.utility.lodershowing = 0;
    $.utility.loderpagingClickcalling = 0;
    $.utility.hidingfixloader = 0;
    $.utility.loderpagingClick = 0;
    $.utility.hideWithStack = function (elem) {
        if ($(elem).data('hidden') == 0)
            $(elem).hide();
        $(elem).data('hidden', $(elem).data('hidden') + 1)
        return elem;
    }
    //# array ,item
    /*
    description:
    show an element and minus the hiddening counts
    */
    $.utility.showWithStack = function (elem) {
        $(elem).removeClass('hidden').show();
        if ($(elem).data('hidden') == undefined)
            $(elem).data('hidden', 0);
        else
            $(elem).data('hidden', $(elem).data('hidden') - 1);
        return elem;
    }
    //# array ,item
    /*
    description:
    returns the intersect of to array objects 
    */
    $.utility.intersect = function (obj1, obj2) {
        var res = [];
        $.each(obj1, function () {
            var object = this;
            $.each(obj2, function () {
                if (object.ID == this.ID) {
                    res.push(object);
                    return false;
                }
            });
        });
        return res;
    }
    //# array ,item
    /*
    description:
    remove obj2 from obj1 returns an array of objects
    */
    $.utility.minus = function (arrObj1, arrObj2) {
        var res = [];
        if (arrObj2.length == 0)
            return res;
        $.each(arrObj1, function () {
            var that = this;
            var flag = false;
            $.each(arrObj2, function () {
                if ($.utility.equalObjects(this, that))
                    flag = true;

            });
            if (!flag)
                res.push(this);
        });
        return res;
    }
    //# array ,item
    /*
    description:
    remove obj2 from obj1 returns an array of objects
    */
    $.utility.addUniqItemToArray = function (obj1, item) {
        if (!$.utility.isIncluded(obj1, item) || obj1.length == 0)
            obj1.push(item);
    }
    //# array ,item
    /*
    description:
    remove obj2 from obj1 returns an array of objects
    */
    $.utility.removeFromRowIDArray = function (obj1, item) {
        var idx = $.utility.indexOfInArray(obj1, item); // Find the index
        if (idx != -1) obj1.splice(idx, 1); // Remove it if really found!
    }
    //# array ,index
    /*
    description:
    remove index from obj1 returns an array of objects
    */
    $.utility.removeFromRowByIndex = function (obj1, index) {
        if (index != -1) obj1.splice(index, 1); // Remove it if really found!
    }
    //# array ,item
    /*
    description:
    find in the array contains the object the factor for existance is the id of object
    */
    $.utility.SearchArrayByID = function (arr, item) {
        if (arr == undefined) return null;
        for (var i = 0; i < arr.length; i++)
            if (arr[i].ID == item)
                return arr[i];

    }
    //# array ,item, key
    /*
    description:
    find in the array contains the object the factor for existance is the key of object
    */
    $.utility.SearchArrayByKey = function (arr, item, key) {
        if (arr == undefined || arr.length == 0) return null;
        for (var i = 0; i < arr.length; i++)
            if (arr[i][key] == item)
                return arr[i];
        return null;
    }
    //# array ,item
    /*
    description:
    find in the array contains the object the factor for existance is the id of object
    */
    $.utility.indexOfInArray = function (arr, item) {
        // return (obj1.indexOf(item) == -1)
        for (var i = 0; i < arr.length; i++) {
            if (arr[i] == item)
                return i;
        }
        return -1;
    }
    //# array ,item
    /*
    description:
    find in the array contains the object the factor for existance is the id of object
    */
    $.utility.isIncluded = function (arr, item) {
        for (var i = 0; i < arr.length; i++) {
            if (arr[i] == item)
                return true;
        }
        return false;
    }
    //# array of objects,object
    /*
    description:
    find in the array contains the object the factor for existance is the id of object
    */
    $.utility.contains = function (arr, obj) {
        for (var i = 0; i < arr.length; i++) {
            if (arr[i].ID == obj.ID) return true;
        }
    }
    //# array of objects,object
    /*
    description:
    remove the given object from the array of objects
    */
    $.utility.removeItem = function (arr, item) {
        var result = [];
        $.each(arr, function () {
            if (this != item)
                result.push(item);
        });
        return result;
    }
    //# Date
    /*
    description:
    convert Date Object to .Net Date string and vice versa
    */
    $.utility.dateNet = function (date) {
        if (date != null) {
            if (/\/Date\([0-9\+]*\)\//.test(date))
                return eval('new ' + date.split('/')[1]);
            return '/Date(' + date.getTime() + ')/';
        }
    }
    /*
    return:
    string
    description:
    convert date to string
    */
    $.utility.dateToString = function (dateObject) {
        if (typeof dateObject != 'undefined') {
            var monthNames = ["Jan.", "Feb.", "Mar.", "Apr.", "May", "Jun.", "Jul.", "Aug.", "Sep.", "Oct.", "Nov.", "Dec."];
            //["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
            return monthNames[dateObject.getMonth()] + ' ' + dateObject.getDate() + ' ' + dateObject.getFullYear();
        }
        else return "-";
    }

    /*
    return:
    string
    description:
    convert date to string as standard Fromat MMM/DD/YYYY
    */
    $.utility.dateToStringStandardFormat = function (dateObject) {
        if (typeof dateObject != 'undefined') {
            var monthNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
            //["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
            return monthNames[dateObject.getMonth()] + '/' + dateObject.getDate() + '/' + dateObject.getFullYear();
        }
        else return "-";
    }

    /*
    return:
    string
    description:
    convert date time to string as standard Fromat MMM/DD/YYYY
    */
    $.utility.dateTimeToStringStandardFormat = function (dateObject) {
        if (typeof dateObject != 'undefined') {
            var monthNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
            //["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
            var hour = dateObject.getHours();
            var min = dateObject.getMinutes();
            if (hour < 10)
                hour = "0" + hour;
            if (min < 10)
                min = "0" + min;

            return monthNames[dateObject.getMonth()] + '/' + dateObject.getDate() + '/' + dateObject.getFullYear() + ' (' + hour + ':' + min + ')';
        }
        else
            return "-";
    }

    /*
    return:
    string
    description:
    convert date time to string
    */
    $.utility.dateTimeToString = function (dateObject) {
        if (typeof dateObject != 'undefined') {
            var monthNames = ["Jan.", "Feb.", "Mar.", "Apr.", "May", "Jun.", "Jul.", "Aug.", "Sep.", "Oct.", "Nov.", "Dec."];
            //["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
            var hour = dateObject.getHours();
            var min = dateObject.getMinutes();
            if (hour < 10)
                hour = "0" + hour;
            if (min < 10)
                min = "0" + min;
            return monthNames[dateObject.getMonth()] + ' ' + dateObject.getDate() + ' ' + dateObject.getFullYear() + ' (' + hour + ':' + min + ')';
        }
        else return "-";
    }
    //# End
    /*
    return:
    string
    description:
    convert date to string
    */
    $.utility.netDateTojsDate = function (dateObject) {
        dateObject = $.utility.dateNet(dateObject);
        if (typeof dateObject != 'undefined') {
            return dateObject.getMonth() + '/' + dateObject.getDate() + '/' + dateObject.getFullYear();
        }
        else return "-";
    }
    //# End
    //# Object
    /*
    return:
    int
    description:
    return size of an object [do not support nested object]
    */
    $.utility.count = function (obj) {
        var i = 0;
        for (var item in obj)
            i++;
        return i;
    }
    /*
    return:
    boolean
    description:
    this will check if variable is null
    or if all item in object has null value
    */
    $.utility.isNull = function (variable) {
        if (typeof (variable) == 'object') {
            var isNull = true;
            for (var i in variable) {
                if (!$.utility.isNull(variable[i]))
                    return false;
            }
        } else if (variable != null)
            return false;
        return true;
    }
    /*
    return:
    boolean
    description:
    this is same as isNull. if variable is null
    or if all item in object has null value.
    note:
    it skip checking the '__type' key 
    */
    $.utility.isNullDTO = function (variable) {
        if (typeof (variable) == 'object') {
            var isNull = true;
            for (var i in variable) {
                if (i != '__type' && !$.utility.isNullDTO(variable[i]))
                    return false;
            }
        } else if (variable != null)
            return false;
        return true;
    }
    //# End

    //# String
    /*
    return:
    string
    description:
    retrieve a part of template
    */
    $.utility.generatePartial = function (template, partName) {
        var partName = '<!--' + partName + '-->';
        return '<!--data-->' + template.substring(template.indexOf(partName) + partName.length, template.lastIndexOf(partName)) + '<!--data-->';
    };
    /*
    params:
    template
    replacements { searchString:replaceString }
    description:
    replace
    note:
    replacements is object of "searchString":"replaceString"
    */
    $.utility.format = function (template, replacements) {
        for (var i in replacements)
            template = template.replace(new RegExp('\\$' + i + '\\$', 'g'), replacements[i]);
        return template;
    };
    /*
    replacements is object of "searchString":"replaceString"
    */
    $.utility.matchedItemText = function (elem, searchText) {
        var matchedItem = [];
        $.each(elem, function () {
            if ($(this).html().toUpperCase() == searchText.toUpperCase() || $(this).text().toUpperCase() == searchText.toUpperCase())
                matchedItem.push($(this));
        });
        return matchedItem;
    };
    /*
    params:
    url
    description:
    detect if the url address is a service address
    return:
    boolean
    */
    $.utility.isService = function (url) {
        return ((/\.svc\/[\w]+$/i).test(url));
    };
    //# End

    //# Ajax
    /*
    return:
    boolean
    description:
    include .js/.css file unless the url is not set
    */
    $.utility.includeUnlessNull = function (url, callback) {
        if (url === null || url == '')
            return false;
        $.include(url, callback);
        return true;
    }
    /*
    description:
    data is javascript object
    */
    $.utility.getData = function (url, callback, data, error, loader) {
        $.ajax({
            'type': 'POST',
            'url': url,
            'data': $.toJSON(data),
            'contentType': 'application/json; charset=utf-8',
            'dataType': 'json',
            'success': $.isFunction(callback) ? function (data) {
                if (!$.utility.isNull(data["d"]) && typeof data["d"].Messages != 'undefined' && !$.utility.isNullDTO(data["d"].Messages)) {
                    $.each(data["d"].Messages,
                                         function () {
                                             if (this.Type == 'AuthenticationError') {
                                                 window.location.reload();
                                             }
                                         }
                                      );
                }
                callback(data["d"]);
            } : null,
            'error': error
        });
    }
    $.utility.getDataSync = function (url, callback, data, error, loader) {
        $.ajax({
            'type': 'POST',
            'url': url,
            'data': $.toJSON(data),
            'contentType': 'application/json; charset=utf-8',
            'async': false,
            'dataType': 'json',
            'success': $.isFunction(callback) ? function (data) {
                if (!$.utility.isNull(data["d"]) && typeof data["d"].Messages != 'undefined' && !$.utility.isNullDTO(data["d"].Messages)) {
                    $.each(data["d"].Messages,
                                         function () {
                                             if (this.Type == 'AuthenticationError') {
                                                 window.location.reload();
                                             }
                                         }
                                      );
                }
                callback(data["d"]);
            } : null,
            'error': error
        });
    }
    //# End
    $.utility.getKey = function (name) {
        name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
        var regexS = "[\\?&]" + name + "=([^&#]*)";
        var regex = new RegExp(regexS);
        var results = regex.exec(window.location.href);
        if (results == null)
            return "";
        else
            return results[1];
    }

    $.utility.getmvcKey = function GetURLParameter() {
        var sPageURL = window.location.href;
        var indexOfLastSlash = sPageURL.lastIndexOf("/");

        if (indexOfLastSlash > 0 && sPageURL.length - 1 != indexOfLastSlash)
            return sPageURL.substring(indexOfLastSlash + 1);
        else
            return 0;
    }
    //# More
    //$.browser.isIE7Less = ($.browser.msie) && ($.browser.version.split('.')[0] < 7);
    //# End   

    $.utility.ArrayMax = function (array) {
        return Math.max.apply(Math, array);
    }

    //returns the minimum number within the array
    $.utility.ArrayMin = function (array) {
        return Math.min.apply(Math, array);
    }
    //returns the true in case of equals two object 
    $.utility.equalObjects = function (obj1, obj2) {
        for (p in obj1) {
            if (typeof (obj2[p]) == 'undefined') { return false; }
        }

        for (p in obj1) {
            if (obj1[p]) {
                switch (typeof (obj1[p])) {
                    case 'object':
                        if (!$.utility.equalObjects(obj1[p], obj2[p])) { return false }; break;
                    case 'function':
                        if (typeof (obj2[p]) == 'undefined' || (p != 'equals' && obj1[p].toString() != obj2[p].toString())) { return false; }; break;
                    default:
                        if (obj1[p] != obj2[p]) { return false; }
                }
            }
            else {
                if (obj2[p]) {
                    return false;
                }
            }
        }

        for (p in obj2) {
            if (typeof (obj1[p]) == 'undefined') { return false; }
        }
        return true;
    }
    $.utility.objectContainsInArray = function (arr, obj, valueField) {
        /* var res = false;
        if (arr == undefined)
        return false;
        $.each(arr, function () {
        if ($.utility.equalObjects(this, obj)) {
        res = true;
        return;
        }
        });
        return res;*/
        if (valueField != undefined) {
            var res = false;
            if (arr != [] && arr != undefined) {
                $.each(arr, function (index, value) {
                    if (JSON.stringify(obj) == JSON.stringify(value[valueField])) {
                        res = true;
                    }
                });
            }
            return res;
        }
        else {
            var res = false;
            if (arr != [] && arr != undefined) {
                $.each(arr, function (index, value) {
                    if (JSON.stringify(obj) == JSON.stringify(value)) {
                        res = true;
                    }
                });
            }
            return res;
        }
    }

    /*
    description:
    remove obj2 from obj1 returns an array of objects
    */
    $.utility.removeObjeFromArray = function (Array, obj2, valueField) {
        if (valueField != undefined) {
            var index = -1;
            for (var i = 0; i < Array.length; i++) {
                //if ($.utility.equalObjects(Array[i][valueField], obj2))
                if (Array[i][valueField] == obj2)
                    index = i;
            }
            if (index != -1) Array.splice(index, 1);
        }
        else {
            var index = -1;
            for (var i = 0; i < Array.length; i++) {
                if ($.utility.equalObjects(Array[i], obj2))
                    index = i;
            }
            if (index != -1) Array.splice(index, 1);
        }
    }



    $.utility.convertStringToDouble = function (dataToConvert) {
        var a1 = dataToConvert.replace(/^\s+|\s+$/, '').split(" ");
        if (a1.length == 2) {
            var a2 = a1[1].split('/');
            var b1 = eval(a2[0]);
            var b2 = eval(a2[1]);
            return eval(a1[0]) + (b1 / b2);
        }
        else
            if (a1[0].search("/") != -1) {
                var a2 = a1[0].split('/');
                var b1 = eval(a2[0]);
                var b2 = eval(a2[1]);
                return eval(b1 / b2);
            }
            else
                return eval(a1[0]);
    }

    $.utility.guidGenerator = function () {
        var S4 = function () {
            return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
        };
        return (S4() + S4() + "-" + S4() + "-" + S4() + "-" + S4() + "-" + S4() + S4() + S4());
    }

    $.utility.netDateTojsDateMonthName = function (dateObject) {
        dateObject = $.utility.dateNet(dateObject);
        if (typeof dateObject != 'undefined') {
            var monthNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
            return monthNames[dateObject.getMonth()] + '/' + dateObject.getDate() + '/' + dateObject.getFullYear();
        }
        else return "";
    }
    $.utility.ConvertStringToDatetime = function (strDate) {
        var FinalDate;
        var ArrDate = strDate.split('/');
        var MonthName = ArrDate[0].toLowerCase();
        var ArrMonthNames = ["jan", "feb", "mar", "apr", "may", "jun", "jul", "aug", "sep", "oct", "nov", "dec"];
        var Month = jQuery.inArray(MonthName, ArrMonthNames) + 1;
        if (Month < 10) {
            Month = "0" + Month;
        }
        var Day = eval(ArrDate[1]);
        if (Day < 10) { Day = "0" + Day; }
        var Year = eval(ArrDate[2]);
        FinalDate = Year + '-' + Month + '-' + Day;

        var isoExp = /^\s*(\d{4})-(\d\d)-(\d\d)\s*$/,
        date = new Date(NaN), month,
        parts = isoExp.exec(FinalDate);
        if (parts) {
            month = +parts[2];
            date.setFullYear(parts[1], month - 1, parts[3]);
            if (month != date.getMonth() + 1) {
                date.setTime(NaN);
            }
        }
        return date;

    }
    $.utility.disableEnableDropDown = function (container, status) {
        //dropdown in consists of a button and an input items. for enable/disable we must do it on the button and input components
        var input = container + ' input';
        var button = container + ' button';

        $(input).prop('disabled', status);
        $(button).prop('disabled', status);
        /*  if (!status) {
        $(input).attr('disabled', '');
        $(button).attr('disabled', '');
        }
        else {
        $(input).attr('disabled', 'disabled');
        $(button).attr('disabled', 'disabled');
        }*/
    }
    $.utility.getDropDownEnableStatus = function (container) {
        //disabled >> returns false.
        var input = container + ' input';
        if ($(input).attr('disabled') == 'disabled' || $(input).attr('disabled') == false)
            return false;
        else return true;
    }

    $.utility.equalTwoArray = function (array1, array2) {
        var foo = [];
        var i = 0;
        if (array1.length != array2.length) {
            return false;
        }
        else {
            jQuery.grep(array2, function (el) {

                if (jQuery.inArray(el, array1) == -1) foo.push(el);

                i++;
            });

            if (foo.length > 0) {
                return false;
            }
            else {
                return true;
            }
        }
    }


    $.utility.ValidationText = function (container) {
        $('.numericKeyDown:visible', container).keydown(function (event) {
            // Allow: backspace, delete, tab, escape, and enter
            if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 ||    // Allow: Ctrl+A
                                        (event.keyCode == 65 && event.ctrlKey === true) ||  // Allow: home, end, left, right
                                         (event.keyCode >= 35 && event.keyCode <= 39) ||    // Allow:  dot
                                         ($(this).val().length != 0 && event.keyCode == 110 || event.keyCode == 190)) { // let it happen, don't do anything
                return;
            }
            else {
                // Ensure that it is a number and stop the keypress
                if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                    event.preventDefault();
                }
            }


        }).blur(function () {
            if (/^-?(?:\d+|\d{1,3}(?:,\d{3})+)(?:\.\d+)?$/.test($(this).val()) || $(this).val() == "") {
                $.fn.validation.makeValid(this, { inValidClass: 'invalid', validClass: 'valid' }, $.maadisht.messages.err2);
            }
            else {
                $.fn.validation.makeInvalid(this, { inValidClass: 'invalid', validClass: 'valid' }, $.maadisht.messages.err2);
            }
        });
    }
    $.utility.addKey = function (itemToAdd) {
        var url = window.location.href;
        url = url.split('#');
        return location.href = url[0] + (!(/\?/.test(url[0])) ? "?" : "&") + itemToAdd + (url[1] == undefined ? "" : "#" + url[1]);
    }
    //change format of input value on keypress 
    $.utility.formatMoneyLive = function (input) {
        $(input).formatCurrencyLive({
            roundToDecimalPlace: -1,
            symbol: ''
        });

    }
    //get number and return money format 
    $.utility.changeToMoneyFormat = function (value) {
        return $.getFormattedCurrency(value, { roundToDecimalPlace: -1, symbol: '' });
    }
    //get money format and return float number
    $.utility.changeMoneyToFloat = function (value) {
        return $.toNumber(value);
    }

    //setup back button click event
    $.utility.setupBackButton = function (first, second, callback) {

        $('.back_Btn_fn').die('click').live('click', function () {
            $(second).slideUp(function () {
                $(first).slideDown();
                $.utility.setupBackButtonDefaultAction();
                callback();
            });
        });

    }

    $.utility.setupBackButtonDefaultAction = function () {

        $('.back_Btn_fn').die('click').live('click', function () {
            window.history.back();
            $.maadisht.loadTab();
        });
    }

    $.utility.getRandomId = function () {
        return Math.floor(Math.random() * 26) + Date.now();
    }

    $.utility.scrollTo = function (elem) {
        $('html,body').animate({
            scrollTop: $(elem).offset().top
        });
    }
});
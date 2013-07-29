/// <reference path="jquery-1.9.1-vsdoc.js" />
/// <reference path="jquery-1.9.1.intellisense.js" />
/// <reference path="jquery-ui-1.8.11.js" />


var ahboo = function ($) {
    var getQueryStringByName = function (name, url) {
        var match = RegExp('[?&]' + name + '=([^&]*)').exec(url);
        return match && decodeURIComponent(match[1].replace(/\+/g, ' '));
    },

    formatLimitedString = function (str, limit) {
        if (str.length > limit)
            return str.substring(0, limit - 4) + '...';
        else
            return str;
    },

    clearFormErrorMsg = function (containerId) {
        $(containerId + ' span[data-valmsg-for]').addClass('field-validation-valid').removeClass('field-validation-error').empty();
    },

    //Populate input DOM with value into the holder
    createInputForData = function (holder, fieldName, value) {
        //holder should b jquery obj
        holder.append(" <input type=\"hidden\" name=\"" + fieldName + "\" value=\"" + value + "\" /> ");
    };

    return {
        getQueryStringByName: getQueryStringByName,
        formatLimitedString: formatLimitedString,
        clearFormErrorMsg: clearFormErrorMsg,
        createInputForData: createInputForData
    };
}(jQuery);


/*====================Custom Validator =======================*/
$(document).ready(function () {
    $.validator.methods.number = function (value, element) {
        return this.optional(element) || !isNaN(Globalize.parseFloat(value));
    }

    $(function () {
        Globalize.culture('en-GB');
    });

    $.validator.addMethod('date',
       function (value, element, params) {
           if (this.optional(element)) {
               return true;
           }

           var ok = true;
           try {
                var sometihng = Globalize.parseDate(value, 'd', 'en-GB');
           }
           catch (err) {
               ok = false;
           }
           return ok;
       });
});


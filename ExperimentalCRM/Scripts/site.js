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

// /Song/Create2
//================================================================

var PlaceCreate = function ($) {
    var LetsDoIt = function () {

        var dom_SelectedPlaces = $('#SelectedPlaces'),
            dom_SearchBox = $('#SearchPlaces'),
            dom_PlaceTemplate = $('#placeList'),
            dom_SelectedPlaceContainer = $('#PlaceOutputDiv');

        dom_SearchBox.each(function () {
            $(this).autocomplete({
                source: function (request, response) {
                    var something = ' ';
                    $.ajax({
                        url: '/Article/QuickSearchPlace',
                        dataType: 'json',
                        data: {
                            Term: dom_SearchBox.val(),
                            Excludes: dom_SelectedPlaces.val()
                        },
                        success: function (data) {
                            response(data);
                            //d_ajaxProgressImg.hide();
                        }
                    });
                },
                //open: function (event, ui) {
                //    //d_ajaxProgressImg.hide();
                //},
                //focus: function (event, ui) {
                //    return false;
                //},
                select: function (event, ui) {
                    //Show artist in the artist list using template
                    var item = dom_PlaceTemplate.tmpl(ui.item);
                    dom_SelectedPlaceContainer.append(item);

                    //Add artistID into hidden artistid list
                    var selectedPlaces = dom_SelectedPlaces.val();
                    if (selectedPlaces != null && selectedPlaces != '')
                        selectedPlaces += ',' + ui.item.value;
                    else {
                        selectedPlaces = ui.item.value;
                        //$('#Singby').show();
                    }
                    dom_SelectedPlaces.val(selectedPlaces);

                    //clear the search txt box
                    $(this).val('');
                    return false;
                },
                autoFocus: true
            });
        });

        dom_SelectedPlaceContainer.delegate('.close', 'click', function () {
            var parent = $(this).parent();
            var placeId = parent.children("input:hidden").val();
            var idArray = dom_SelectedPlaceContainer.val().split(',');
            var len = idArray.length;
            var newIDList;
            for (var i = 0; i < len; i++) {
                if (placeId != idArray[i]) {
                    if (newIDList != null)
                        newIDList += ',' + idArray[i];
                    else
                        newIDList = idArray[i];
                }
            }
            dom_SelectedPlaces.val(newIDList);
            parent.fadeOut(function () {
                $(this).remove();
            });
        });

        $('#mainForm').submit(function () {
            var placeIdArray = dom_SelectedPlaces.val().split(',');
            var dataHolder = $('#dataHolderForFormSubmit');
            for (var i = 0; i < placeIdArray.length; i++) {
                ahboo.createInputForData(dataHolder, 'Places[' + i + '].PlaceId', placeIdArray[i]);
            }
            return true;
        });
    }
    return {
        LetsDoIt: LetsDoIt
    };
}

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


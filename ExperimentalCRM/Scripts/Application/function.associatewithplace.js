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
            var idArray = dom_SelectedPlaces.val().split(',');
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

        //$('#mainForm').submit(function () {
        //    var selectedPlacesStr = dom_SelectedPlaces.val();
        //    if (selectedPlacesStr.length == 0)
        //        return true;

        //    return true;
        //});
    }
    return {
        LetsDoIt: LetsDoIt
    };
}
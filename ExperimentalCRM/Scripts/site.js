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
        holder.append(" <input type=\"text\" name=\"" + fieldName + "\" value=\"" + value + "\" /> ");
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

var Song_Create2 = function ($) {
    var LetsDoIt = function () {

        var dom_SelectedPlaces = $('#SelectedPlaces'),
            dom_SearchBox = $('#SearchPlaces'),
            dom_PlaceTemplate = $('#placeList'),
            dom_SelectedPlaceContainer = $('#PlaceOutputDiv');

        $("#SearchPlaces").each(function () {
            $(this).autocomplete({
                source: function (request, response) {
                    //d_ajaxProgressImg.show();
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
                open: function (event, ui) {
                    //d_ajaxProgressImg.hide();
                },
                focus: function (event, ui) {
                    return false;
                },
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
            //.data("autocomplete")._renderItem = function (ul, item) {
            //    /*var searchTerm = this.term;
            //    var itemLabel = item.label;
            //    itemLabel = itemLabel.replace(new RegExp("(" + searchTerm + ")", "gi"), '<strong>$1</strong>');
            //    item.label = itemLabel;*/
            //    var htmlToAppend = $('#resultList').tmpl(item);
            //    return $("<li></li>")
            //    .data("item.autocomplete", item)
            //    .append(htmlToAppend)
            //    .appendTo(ul);
            //};
        });

        //function album(albumId, name, m_Name, releaseDate, recordLabelId) {
        //    return {
        //        AlbumId: albumId,
        //        Name: name,
        //        M_Name: m_Name,
        //        ReleaseDate: releaseDate,
        //        RecordLabelId: recordLabelId
        //    };
        //}

        //var linkItems = new Array(),
        //varArtist,
        //varGenre,
        //varAlbum,
        //formValidate,
        //d_linkName = $('#linkName'),
        //d_source = $('#source'),
        //d_urlLink = $('#urlLink'),
        //d_linkTypeID = $('#linkTypeID'),
        //d_linkForm = $('#LinkForm'),
        //d_artistForm = $('#ArtistForm'),
        //d_genreForm = $('#GenreForm'),
        //d_albumForm = $('#AlbumForm'),
        //d_outputDiv = $('#OutputDiv'),
        //d_artistOutputDiv = $('#ArtistOutputDiv'),
        //d_searchbox = $('#ArtistSearch'),
        //d_selectedArtistsBox = $('#SelectArtists'),
        //d_ajaxProgressImg = $('.textbox-ajax-progress'),
        //d_newArtistDialog = $('#NewArtistDialog'),
        //d_newGenreDialog = $('#NewGenreDialog'),
        //d_newAlbumDialog = $('#NewAlbumDialog');
        
        //$('#PlayDialog').dialog({
        //    autoOpen: false,
        //    height: 390,
        //    width: 590,
        //    modal: true,
        //    show: "puff",
        //    beforeClose: function () {
        //        $('#PlayHolder').empty();
        //    }
        //});

        //d_newGenreDialog.dialog({
        //    autoOpen: false,
        //    height: 300,
        //    width: 580,
        //    modal: true,
        //    show: "puff",
        //    buttons: {
        //        Save: function () {
        //            formValidate = d_genreForm.validate();
        //            if (d_genreForm.valid()) {
        //                varGenre = new genre(0, $('#GenreForm input[name="Name"]').val(), $('#GenreForm input[name="MyanmarName"]').val());
        //                $.ajax({
        //                    url: "/Genre/Ajax_AddNewGenre",
        //                    dataType: "json",
        //                    data: varGenre,
        //                    success: function (data) {
        //                        $('#GenreID').html('');
        //                        var addedGenreId = data.AddedGenreID;
        //                        $.each(data.Genres, function () {
        //                            $('#GenreID').append($('<option />').val(this.GenreID).text(this.Name));
        //                        });
        //                        $('#GenreID').val(addedGenreId);
        //                    },
        //                    error: function () {

        //                    }
        //                });
        //                $(this).dialog("close");
        //            }
        //        },
        //        Cancel: function () {
        //            $(this).dialog("close");
        //        }
        //    },
        //    close: function () {
        //        if (formValidate != null) {
        //            ahboo.clearFormErrorMsg(d_genreForm.selector);
        //            formValidate.resetForm();
        //        }
        //        $('#GenreForm :input').val('');
        //    }
        //});

        //d_newAlbumDialog.dialog({
        //    autoOpen: false,
        //    height: 400,
        //    width: 580,
        //    modal: true,
        //    show: "puff",
        //    buttons: {
        //        Save: function () {
        //            formValidate = d_albumForm.validate();
        //            if (d_albumForm.valid()) {
        //                varAlbum = new album(0, $('#AlbumForm input[name="Name"]').val(), $('#AlbumForm input[name="M_Name"]').val(),
        //                $('#AlbumForm input[name="ReleaseDate"]').val(), $('#AlbumForm select[name="RecordLabelID"]').val());
        //                $.ajax({
        //                    url: "/Album/Ajax_AddNewAlbum",
        //                    dataType: 'json',
        //                    data: varAlbum,
        //                    success: function (data) {
        //                        $('#AlbumID').html('');
        //                        var addedAlbumId = data.AddedAlbumID;
        //                        $.each(data.Albums, function () {
        //                            $('#AlbumID').append($('<option />').val(this.AlbumID).text(this.Name));
        //                        });
        //                        $('#AlbumID').val(addedAlbumId);
        //                    },
        //                    error: function () {

        //                    }
        //                });
        //                $(this).dialog("close");
        //            }
        //        },
        //        Cancel: function () {
        //            $(this).dialog("close");
        //        }
        //    },
        //    close: function () {
        //        if (formValidate != null) {
        //            ahboo.clearFormErrorMsg('#AlbumForm');
        //            formValidate.resetForm();
        //        }
        //        $('#AlbumForm :input, #AlbumForm select').val('');
        //    }
        //});

        //d_newArtistDialog.dialog({
        //    autoOpen: false,
        //    height: 300,
        //    width: 580,
        //    modal: true,
        //    show: "puff",
        //    buttons: {
        //        Save: function () {
        //            formValidate = d_artistForm.validate();
        //            if (d_artistForm.valid()) {
        //                varArtist = new artist(0, $('#ArtistForm input[name="Name"]').val(),
        //                    $('#ArtistForm input[name="M_Name"]').val(), $('#ArtistForm input[name="Description"]').val());
        //                $.ajax({
        //                    url: "/Artist/Ajax_AddNewArtist",
        //                    dataType: 'json',
        //                    data: varArtist,
        //                    success: function (data) {
        //                        varArtist = data;
        //                        var item = $('#artistList').tmpl({ label: varArtist.Name, value: varArtist.ArtistID });
        //                        d_artistOutputDiv.append(item);

        //                        //Add artistID into hidden artistid list
        //                        var selectedArts = d_selectedArtistsBox.val();
        //                        if (selectedArts != null && selectedArts != '')
        //                            selectedArts += ',' + varArtist.ArtistID;
        //                        else {
        //                            selectedArts = varArtist.ArtistID;
        //                            $('#Singby').show();
        //                        }
        //                        d_selectedArtistsBox.val(selectedArts);
        //                    },
        //                    error: function () {

        //                    }
        //                });
        //                $(this).dialog("close");
        //            }

        //        },
        //        Cancel: function () {
        //            $(this).dialog("close");
        //        }
        //    },
        //    close: function () {
        //        if (formValidate != null) {
        //            ahboo.clearFormErrorMsg(d_artistForm.selector);
        //            formValidate.resetForm();
        //        }
        //        $('#ArtistForm :input').val('');
        //    }
        //});

        //$('#NewLinkDialog').dialog({
        //    autoOpen: false,
        //    height: 300,
        //    width: 580,
        //    modal: true,
        //    show: "puff",
        //    buttons: {
        //        Save: function () {
        //            formValidate = d_linkForm.validate();
        //            if (d_linkForm.valid()) {
        //                var formId = d_linkForm.attr('name');

        //                //Edit
        //                if (formId != null && formId != '') {
        //                    for (var i = 0; i < linkItems.length; i++) {
        //                        if (formId == linkItems[i].Id) {
        //                            linkItems[i] = null;
        //                            linkItems[i] = getLinkFormData(formId);
        //                            $('#linkItem' + formId).replaceWith($('#DynamicInputTmpl').tmpl(linkItems[i]));
        //                        }
        //                    }
        //                } else { //Add
        //                    var lItemObj = getLinkFormData(null);
        //                    linkItems.push(lItemObj);
        //                    var item = $('#DynamicInputTmpl').tmpl(linkItems[linkItems.length - 1]).show().fadeIn();
        //                    d_outputDiv.append(item);
        //                    if (linkItems.length == 1)
        //                        $('#OutputDiv .related-link-txt').show();
        //                }

        //                //Close Dialog
        //                $(this).dialog("close");
        //            }
        //        },
        //        Cancel: function () {
        //            $(this).dialog("close");
        //        }
        //    },
        //    close: function () {
        //        clearLinkDialogForm();
        //        if (formValidate != null) {
        //            formValidate.resetForm();
        //            ahboo.clearFormErrorMsg(d_linkForm.selector);
        //        }
        //    }
        //});

        //Convert link form data into linkitem obj
        //function getLinkFormData(linkId) {
        //    var id = linkId;
        //    if (id === null)
        //        id = linkItems.length + 1;

        //    var lItemObj = new linkItem(id, d_linkName.val(), d_urlLink.val(), d_source.val(), d_source.children(':selected').text(), 1, d_linkTypeID.val(), d_linkTypeID.children(':selected').text());
        //    if (lItemObj.Source == 1) {
        //        lItemObj.LinkHtmlElement = unescape("<img src=\"http://i3.ytimg.com/vi/" + ahboo.getQueryStringByName('v', lItemObj.UrlLink) + "/default.jpg\" alt=\"" + lItemObj.Name + "\" />");
        //    }
        //    return lItemObj;
        //}

        //Clear Link Dialog Form
        //function clearLinkDialogForm() {
        //    d_linkName.val('').trigger('focusout');
        //    d_urlLink.val('').trigger('focusout');
        //    d_source.val('').trigger('focusout');
        //    d_linkTypeID.val(0);
        //    d_linkForm.attr('name', '');
        //}

        //Event bindings

        //$('#AddAlbum').click(function () {
        //    d_newAlbumDialog.dialog("open");
        //});

        //$('#AddGenre').click(function () {
        //    d_newGenreDialog.dialog("open");
        //});

        //$('#AddArtist').click(function () {
        //    d_newArtistDialog.dialog("open");
        //});

        //$('.field-row').bind('mouseenter', function () {
        //    $('#' + $(this).attr('name')).fadeIn().show();
        //});

        //$('.field-row').bind('mouseleave', function () {
        //    $('#' + $(this).attr('name')).hide();
        //});

        //$('#mainForm').submit(function () {
        //    var artistIdArray = d_selectedArtistsBox.val().split(',');
        //    var dataHolder = $('#dataHolderForFormSubmit');
        //    for (var i = 0; i < artistIdArray.length; i++) {
        //        ahboo.createInputForData(dataHolder, 'Artists[' + i + '].ArtistID', artistIdArray[i]);
        //    }
        //    for (var i = 0; i < linkItems.length; i++) {
        //        ahboo.createInputForData(dataHolder, 'Links[' + i + '].Name', linkItems[i].Name);
        //        ahboo.createInputForData(dataHolder, 'Links[' + i + '].UrlLink', linkItems[i].UrlLink);
        //        ahboo.createInputForData(dataHolder, 'Links[' + i + '].SourceID', linkItems[i].Source);
        //        ahboo.createInputForData(dataHolder, 'Links[' + i + '].UserID', 1);
        //        ahboo.createInputForData(dataHolder, 'Links[' + i + '].LinkTypeID', linkItems[i].LinkTypeID);
        //    }
        //    var str = "something";
        //    return true;
        //});

        //d_artistOutputDiv.delegate('.remove', 'click', function () {
        //    var parent = $(this).parent();
        //    var artistID = $(this).attr('ab-aid');
        //    var idArray = d_selectedArtistsBox.val().split(',');
        //    var len = idArray.length;
        //    var newIDList;
        //    for (var i = 0; i < len; i++) {
        //        if (artistID != idArray[i]) {
        //            if (newIDList != null)
        //                newIDList += ',' + idArray[i];
        //            else
        //                newIDList = idArray[i];
        //        }
        //    }
        //    if (newIDList == null)
        //        $('#Singby').fadeOut();
        //    d_selectedArtistsBox.val(newIDList);
        //    parent.fadeOut(function () {
        //        $(this).remove();
        //    });
        //});

        //$('#AddMoreLink').click(function () {
        //    $('#NewLinkDialog').dialog("open");
        //});

        //d_outputDiv.on('mouseenter', '.link-items', function () {
        //    $('.item-action', this).addClass('item-action-show ').show();
        //});

        //d_outputDiv.on('mouseleave', '.link-items', function () {
        //    $('.item-action', this).hide();
        //});

        //d_outputDiv.on('click', '.link-items a.play', function () {
        //    var itemId = $(this).attr('name');
        //    var linkValue = ahboo.getQueryStringByName('v', $('#OutputDiv a[name="LinkHtmlElement' + itemId + '"]').attr('href'));
        //    var linkTitle = $('#OutputDiv span[name="Name' + itemId + '"]').html();
        //    $('#PlayDialog').dialog({ title: ahboo.formatLimitedString(linkTitle, 70) });
        //    $('#PlayDialog').dialog("open");
        //    $('#PlayHolder').append("<iframe width=\"560\" height=\"315\" src=\"http://www.youtube.com/embed/" + linkValue + "?autoplay=1\" frameborder=\"0\" allowfullscreen></iframe>");
        //});

        //d_outputDiv.on('click', '.link-items a.edit', function () {
        //    var itemId = $(this).attr('name');
        //    $('#LinkForm :text, #LinkForm textarea').css('color', '#000000');
        //    d_linkName.val($('#OutputDiv span[name="Name' + itemId + '"]').html());
        //    d_source.val($('#OutputDiv span[name="Source' + itemId + '"]').html());
        //    d_urlLink.val($('#OutputDiv a[name="LinkHtmlElement' + itemId + '"]').attr('href'));
        //    d_linkTypeID.val($('#OutputDiv span[name="LinkTypeID' + itemId + '"]').html());
        //    d_linkForm.attr('name', itemId);
        //    $('#NewLinkDialog').dialog("open");
        //});

        //d_outputDiv.on('click', 'span.remove-item', function () {
        //    var itemId = $(this).attr('name');
        //    var newArray = new Array();
        //    for (var i = 0; i < linkItems.length; i++) {
        //        if (itemId != linkItems[i].Id)
        //            newArray.push(linkItems[i]);
        //    }
        //    linkItems = newArray;
        //    if (linkItems.length < 1)
        //        $('#OutputDiv .related-link-txt').hide();
        //    $('#linkItem' + itemId).fadeOut(function () {
        //        $(this).remove();
        //    });
        //});

    }
    return {
        LetsDoIt: LetsDoIt
    };
}


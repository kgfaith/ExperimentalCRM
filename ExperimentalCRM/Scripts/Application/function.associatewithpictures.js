(function ($) {
    var isAjaxRequestOnGoing = false,
    $associateWithPicturesDialog = $('#AssociateWithPicturesDialog'),
    $newPhotoFormValidator = new customFormValidator($('#newphoto-form')),
    $ajaxLoader = $('#floatingCirclesG');
    $ajaxLoader.hide();

    $associateWithPicturesDialog.dialog({
        autoOpen: false,
        height: 500,
        width: 580,
        modal: true,
        show: "puff",
        buttons: null,
        close: function () {
            window.selectPictures.selectPicturesViewModel.resetViewModel();
        }
    });

    $('#AddSlideshowBtn').click(function () {
        $associateWithPicturesDialog.dialog("open");
    });

    //Detect Ctrl+V
    var ctrlDown = false;
    var ctrlKey = 17, vKey = 86, cKey = 67;

    $(document).keydown(function (e) {
        if (e.keyCode == ctrlKey) ctrlDown = true;
    }).keyup(function (e) {
        if (e.keyCode == ctrlKey) {
            setTimeout(function () {
                ctrlDown = false;
            }, 1500);
        }
    });

    //$(".no-copy-paste").keydown(function (e) {
    //    if (ctrlDown && (e.keyCode == vKey || e.keyCode == cKey)) return false;
    //});

    $(document).on('keyup', 'input#newpic_url', getFlickrPicInfo);

    function getFlickrPicInfo(e) {
        var isCtrlV = (ctrlDown && e.keyCode == vKey);
        if (!isAjaxRequestOnGoing && isCtrlV) {
            var flickrUrl = e.currentTarget.value;
            //check url len less than 30
            if (flickrUrl.length < 30) return false;

            //get flickr photoId first
            var patt = new RegExp('photos/[^/]+/([0-9]+)');
            var n = flickrUrl.match(patt);
            if (n != null) {
                if (n.length == 2 && n[1] != '') {
                    $newPhotoFormValidator.addError({
                        "FlickrUrl": null
                    });
                    sendFlickrAjaxRequest(n[1], flickrUrl);
                }
            } else {
                $newPhotoFormValidator.addError({
                    "FlickrUrl": "Invalid Flickr url"
                });
            }
        }
    }

    function sendFlickrAjaxRequest(photoId, flickrUrl) {
        var options = {
            url: '/Photo/JsonGetFlickrPhotoInfo',
            data: {
                photoId: photoId
            },
            dataType: 'json',
            success: function (data) {
                data.Url = flickrUrl;
                window.selectPictures.selectPicturesViewModel.newPhotoData().populateDataForModel(data);
                window.selectPictures.selectPicturesViewModel.showAllField(true);
            },
            error: function (xhr, status, error) {
            },
            complete: function () {
                $ajaxLoader.hide();
            }
        };
        $ajaxLoader.show();
        $.ajax(options);
    }

})(jQuery);
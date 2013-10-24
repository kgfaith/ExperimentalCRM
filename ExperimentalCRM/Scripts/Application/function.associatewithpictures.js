(function ($) {
    var isAjaxRequestOnGoing = false;
    $associateWithPicturesDialog = $('#AssociateWithPicturesDialog');

    $associateWithPicturesDialog.dialog({
        autoOpen: false,
        height: 500,
        width: 580,
        modal: true,
        show: "puff",
        buttons: {
            Save: function () {
    
            },
            Cancel: function () {
                $(this).dialog("close");
            }
        },
        close: function () {
        }
    });

    $('#AddSlideshowBtn').click(function () {
        $associateWithPicturesDialog.dialog("open");
    });

    $(document).on('keyup', 'input#newpic_url', getFlickrPicInfo);

    function getFlickrPicInfo(e) {
        if (!isAjaxRequestOnGoing) {
            var flickrUrl = e.currentTarget.value;
            //check url len less than 30
            if (flickrUrl.length < 30) return false;

            //get flickr photoId first
            var patt = new RegExp('photos/[^/]+/([0-9]+)');
            var n = flickrUrl.match(patt);
            if (n != null) {
                if (n.length == 2 && n[1] != '') {
                    sendFlickrAjaxRequest(n[1], flickrUrl);
                }
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
                isAjaxRequestOnGoing = false;
            }
        };
        isAjaxRequestOnGoing = true;
        $.ajax(options);
    }

})(jQuery);
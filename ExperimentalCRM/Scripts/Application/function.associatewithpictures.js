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

    $('#fileupload').fileupload({
        dataType: 'json',
        done: function (e, data) {
            $.each(data.result.files, function (index, file) {
                $('<p/>').text(file.name).appendTo('#imguploaded');
            });
        }
    });

    (function () {
        'use strict';
        // Change this to the location of your server-side upload handler:
        var url = '/Photo/UploadImage';
        var uploadButton = $('<button/>')
            .addClass('btn btn-primary')
            .prop('disabled', true)
            .text('Processing...')
            .on('click', function () {
                var $this = $(this),
                    data = $this.data();
                $this
                    .off('click')
                    .text('Abort')
                    .on('click', function () {
                        $this.remove();
                        data.abort();
                    });
                data.submit().always(function () {
                    $('#progress').show();
                    $this.remove();
                });
            });

        $('#fileupload').fileupload({
            url: url,
            dataType: 'json',
            autoUpload: false,
            acceptFileTypes: /(\.|\/)(gif|jpe?g|png)$/i,
            maxFileSize: 5000000, // 5 MB
            // Enable image resizing, except for Android and Opera,
            // which actually support image resizing, but fail to
            // send Blob objects via XHR requests:
            disableImageResize: /Android(?!.*Chrome)|Opera/
                .test(window.navigator.userAgent),
            previewMaxWidth: 100,
            previewMaxHeight: 100,
            previewCrop: true
        }).on('fileuploadadd', function (e, data) {
            data.context = $('<div/>').appendTo('#files');
            $.each(data.files, function (index, file) {
                var node = $('<p/>')
                        .append($('<span/>').text(file.name));
                if (!index) {
                    node
                        .append('<br>')
                        .append(uploadButton.clone(true).data(data));
                }
                node.appendTo(data.context);
            });
        }).on('fileuploadprocessalways', function (e, data) {
            var index = data.index,
                file = data.files[index],
                node = $(data.context.children()[index]);
            if (file.preview) {
                node
                    .prepend('<br>')
                    .prepend(file.preview);
            }
            if (file.error) {
                node
                    .append('<br>')
                    .append($('<span class="text-danger"/>').text(file.error));
            }
            if (index + 1 === data.files.length) {
                data.context.find('button')
                    .text('Upload')
                    .prop('disabled', !!data.files.error);
            }
        }).on('fileuploadprogressall', function (e, data) {
            var progress = parseInt(data.loaded / data.total * 100, 10);
            $('#progress .progress-bar').css(
                'width',
                progress + '%'
            );
        }).on('fileuploaddone', function (e, data) {
            $.each(data.result.files, function (index, file) {
                if (file.url) {
                    var link = $('<a>')
                        .attr('target', '_blank')
                        .prop('href', file.url);
                    $(data.context.children()[index])
                        .wrap(link);
                } else if (file.error) {
                    var error = $('<span class="text-danger"/>').text(file.error);
                    $(data.context.children()[index])
                        .append('<br>')
                        .append(error);
                }
            });

            //hide progress bar after timeout
            setTimeout(function () {
                $('#progress').fadeOut();
            }, 1500);

        }).on('fileuploadfail', function (e, data) {
            $.each(data.files, function (index, file) {
                var error = $('<span class="text-danger"/>').text('File upload failed.');
                $(data.context.children()[index])
                    .append('<br>')
                    .append(error);
            });
        }).prop('disabled', !$.support.fileInput)
            .parent().addClass($.support.fileInput ? undefined : 'disabled');

    })();

})(jQuery);
(function ($) {
    $associateWithPicturesDialog = $('#AssociateWithPicturesDialog');

    $associateWithPicturesDialog.dialog({
        autoOpen: false,
        height: 300,
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

})(jQuery);
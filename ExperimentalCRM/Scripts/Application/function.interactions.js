(function ($) {
    //var $thumbnailImageDiv = $('.thumb-nail-div');
    //$thumbnailImageDiv.on('mouseenter', function () {
    //    $('.cross-btn-small', this).toggleClass('hidden');
    //    $(this).toggleClass('area-hover');
    //});

    //$thumbnailImageDiv.on('mouseleave', function () {
    //    $('.cross-btn-small', this).toggleClass('hidden');
    //    $(this).toggleClass('area-hover');
    //});

    $('#SlideShowPicDiv').on('mouseenter', '.thumb-nail-div', function () {
        $('.cross-btn-small', this).toggleClass('hidden');
        $(this).toggleClass('area-hover');
    });

    $('#SlideShowPicDiv').on('mouseleave', '.thumb-nail-div', function () {
        $('.cross-btn-small', this).toggleClass('hidden');
        $(this).toggleClass('area-hover');
    });

})(jQuery);
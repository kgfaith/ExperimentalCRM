$(function () {

    var $showChildBtn = $("#ShowChildBtn");
    var $childHolder = $("#child-holder");
    var placeId = $('input[name="PlaceId"]').val();
    
    $showChildBtn.click(function () {
        $.ajax(
            {
                type: "GET",
                url: "/Place/PlaceChildList",
                data: { placeId: placeId}
            })
            .done(function (html) {
                $childHolder.html('');
                $childHolder.append(html);
            })
            .fail(function() {
                alert("error");
            });
    });

    
});
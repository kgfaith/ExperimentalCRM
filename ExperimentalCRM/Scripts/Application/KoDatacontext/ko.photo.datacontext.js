window.photo = window.photo || {};

window.photo.datacontext = (function () {

    function saveNewPhoto(newPhoto, callBack)
    {
        $.ajax({
            type: "POST",
            url: "/Photo/JsonAddNewFlickrPhoto",
            data: newPhoto,
            success: function (data) {
                callBack(data);
            },
            dataType: "json",
            traditional: true,
            error: function () {
            }
        });

        return true;
    }
    var datacontext = {
        saveNewPhoto: saveNewPhoto,
    };

    return datacontext;
})();
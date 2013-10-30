window.photo = window.photo || {};

window.photo.datacontext = (function () {

    function saveNewPhoto(newPhoto, callBack)
    {
        var something = "something";
        $.ajax({
            type: "POST",
            url: "/Photo/JsonAddNewPhoto",
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
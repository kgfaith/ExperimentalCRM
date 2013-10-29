window.selectPictures = window.selectPictures || {};

window.selectPictures.datacontext = (function () {

    function saveNewPhoto(newPhoto)
    {
        $.ajax({
            type: "POST",
            url: url,
            data: newPhoto,
            success: function () {
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
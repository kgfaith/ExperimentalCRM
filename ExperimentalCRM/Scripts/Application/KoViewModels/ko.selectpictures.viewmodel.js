window.selectPictures = window.selectPictures || {};
window.photo = window.photo || {};

window.selectPictures.selectPicturesViewModel = (function (ko, datacontext) {

    var mainSelectedPics = ko.observableArray();
    var isNewPhoto =  ko.observable(false);
    var isFlickrPhoto = ko.observable(false);
    var showAllField = ko.observable(false);
    var onOptionPage = ko.observable(true);
    var newPhotoData = ko.observable();
    var searchString = ko.observable();
    var searchResultPic = ko.observableArray();

    isFlickrPhoto.ForEditing = ko.computed({
        read: function () {
            return isFlickrPhoto().toString();
        },
        write: function (newValue) {
            isFlickrPhoto(newValue === "true");
            if(newValue != "true")
                chooseAddNormalPhoto();
        },
        owner: this
    });

    var resetViewModel = function () {
        isNewPhoto(false);
        isFlickrPhoto(false);
        showAllField(false);
        onOptionPage(true);
        newPhotoData(new photoModel());
    };

    var chooseAddNewPhoto = function () {
        onOptionPage(false);
        isNewPhoto(true);
        isFlickrPhoto(false);
        
    };

    var chooseAddExistingPhoto = function () {
        onOptionPage(false);
        isNewPhoto(false);
        isFlickrPhoto(false);
    };

    var backToOption = function () {
        onOptionPage(true);
        isNewPhoto(false);
        isFlickrPhoto(false);
        newPhotoData(new photoModel());
        showAllField(false);
    };

    var search = function () {
    };

    var addToSelection = function () {
        
    };

    var chooseAddFlickrPhoto = function () {
        onOptionPage(false);
        isNewPhoto(true);
        isFlickrPhoto(true);
        newPhotoData(new photoModel());
    };

    var chooseAddNormalPhoto = function () {
        onOptionPage(false);
        isNewPhoto(true);
        isFlickrPhoto(false);
        newPhotoData(new photoModel());
        showAllField(false);
    };

    var saveNormalPhoto = function (data) {

    };

    var saveFlickrPhoto = function (data) {
        datacontext.saveNewPhoto(data, saveSccessful);
    };

    var savePhoto = function (formElement) {
        var $form = $(formElement);
        if ($form.valid()) {
            var formData = $form.serializeObject();
            var url = newPhotoData().flickrUrl();
            if (url != '') {
                formData.SourceId = 2;
                saveFlickrPhoto(formData);
            } else {
                formData.SourceId = 1;
                saveNormalPhoto(formData);
            }
        }
    };

    function saveSccessful(data) {
        if (data.newPhotoId > 0) {
            $('#AssociateWithPicturesDialog').dialog("close");
            var photoOb = new photoModel(data);
            mainSelectedPics.push(photoOb);
        }
    }

    function initialize() {
        newPhotoData(new photoModel());
    }
    initialize();

    return {
        mainSelectedPics: mainSelectedPics,
        isNewPhoto: isNewPhoto,
        isFlickrPhoto: isFlickrPhoto,
        showAllField: showAllField,
        newPhotoData: newPhotoData,
        searchString: searchString,
        searchResultPic: searchResultPic,
        onOptionPage: onOptionPage,
        resetViewModel: resetViewModel,

        chooseAddNewPhoto: chooseAddNewPhoto,
        chooseAddExistingPhoto: chooseAddExistingPhoto,
        search: search,
        addToSelection: addToSelection,
        chooseAddFlickrPhoto: chooseAddFlickrPhoto,
        chooseAddNormalPhoto: chooseAddNormalPhoto,
        savePhoto : savePhoto, 
        backToOption: backToOption
    };
})(ko, photo.datacontext);

// Initiate the Knockout bindings
ko.applyBindings(window.selectPictures.selectPicturesViewModel, $("#AssociateWithPicturesDialog").get(0));
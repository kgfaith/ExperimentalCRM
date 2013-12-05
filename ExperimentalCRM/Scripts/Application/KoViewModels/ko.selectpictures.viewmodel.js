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
    var searchResultPics = ko.observableArray();

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
        searchResultPics([]);
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
        resetViewModel();
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

    var addSearchResultPicture = function (data) {
        var photoOb = new photoModel(data);
        searchResultPics.push(photoOb);
    };

    var clearSearchResult = function () {
        searchResultPics([]);
    };

    var addSelectedPicture = function (data) {
        var photoOb = new photoModel(data);
        mainSelectedPics.push(photoOb);
    };

    var savePhoto = function (formElement) {
        var $form = $(formElement);
        $form.validate();
        var s = $form.valid();
        if ($form.valid()) {
            var formData = $form.serializeObject();
            var url = newPhotoData().flickrUrl();
            if (typeof url != 'undefined' && url != '') {
                formData.SourceId = 2;
                saveFlickrPhoto(formData);
            }
            //else {
            //    formData.SourceId = 1;
            //    saveNormalPhoto(formData);
            //}
        }
    };

    var selectedPicIdsString = ko.computed(function () {
        var str = "";
        ko.utils.arrayForEach(mainSelectedPics(), function (pic) {
            str += pic.pictureId() + ',';
        });
        return str;
    });

    var selectSearchResult = function (photo) {
        if (photo.isSelected())
            photo.isSelected(false);
        else {
            photo.isSelected(true);
        }
    };

    var removePictureFromSelectedList = function (photo) {
        mainSelectedPics.remove(photo);
        $('#SelectedSlideShowPictures').val(selectedPicIdsString());
    };

    var addToSelectedPictureList = function () {
        ko.utils.arrayForEach(searchResultPics(), function (pic) {
            if (pic.isSelected()) {
                mainSelectedPics.push(pic);
            }
        });
        searchResultPics([]);
        $('#AssociateWithPicturesDialog').dialog("close");
    }

    var pageLoad = function (currentSlideShowPics) {
        if (typeof currentSlideShowPics != 'undefined') {
            if (currentSlideShowPics != null) {
                if (currentSlideShowPics.length > 0) {
                    ko.utils.arrayForEach(currentSlideShowPics, function (pic) {
                        var photoOb = new photoModel(pic);
                        mainSelectedPics.push(photoOb);
                    });
                    $('#SelectedSlideShowPictures').val(selectedPicIdsString());
                }
            }
        }
    }

    function saveSccessful(data) {
        if (data.PictureId > 0) {
            var photoOb = new photoModel(data);
            mainSelectedPics.push(photoOb);
            $('#AssociateWithPicturesDialog').dialog("close");
            
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
        searchResultPics: searchResultPics,
        onOptionPage: onOptionPage,
        resetViewModel: resetViewModel,
        selectedPicIdsString: selectedPicIdsString,

        chooseAddNewPhoto: chooseAddNewPhoto,
        chooseAddExistingPhoto: chooseAddExistingPhoto,
        search: search,
        addToSelection: addToSelection,
        chooseAddFlickrPhoto: chooseAddFlickrPhoto,
        chooseAddNormalPhoto: chooseAddNormalPhoto,
        savePhoto : savePhoto, 
        backToOption: backToOption,
        addSelectedPicture: addSelectedPicture,
        clearSearchResult: clearSearchResult,
        addSearchResultPicture: addSearchResultPicture,
        selectSearchResult: selectSearchResult,
        addToSelectedPictureList: addToSelectedPictureList,
        removePictureFromSelectedList: removePictureFromSelectedList,
        pageLoad: pageLoad
    };
})(ko, photo.datacontext);

// Initiate the Knockout bindings
ko.applyBindings(window.selectPictures.selectPicturesViewModel);

if (typeof viewModelSlideshowPics == 'undefined')
    var viewModelSlideshowPics;

window.selectPictures.selectPicturesViewModel.pageLoad(viewModelSlideshowPics);
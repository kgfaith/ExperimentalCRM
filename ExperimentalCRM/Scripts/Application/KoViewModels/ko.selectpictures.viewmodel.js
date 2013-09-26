window.selectPictures = window.selectPictures || {};

window.selectPictures.selectPicturesViewModel = (function (ko, datacontext) {

    var mainSelectedPics = ko.observableArray();
    var dialogSelectedPics = ko.observableArray();
    var isNewPhoto =  ko.observable(false);
    var isFlickrPhoto = ko.observable(false);
    var onOptionPage = ko.observable(true);
    var newNomralPhoto = ko.observable();
    var newFlickrPhoto = ko.observable();
    var searchString = ko.observable();
    var searchResultPic = ko.observableArray();

    //datacontext.getUserDetails(userDetails, errorMessage, null);
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
    };

    var search = function () {
    };

    var addToSelection = function () {
    };

    var chooseAddFlickrPhoto = function () {
        onOptionPage(false);
        isNewPhoto(true);
        isFlickrPhoto(true);
    };

    var chooseAddNormalPhoto = function () {
        onOptionPage(false);
        isNewPhoto(true);
        isFlickrPhoto(false);
    };

    var SaveNormalPhoto = function () {
    };


    var SaveFlickrPhoto = function () {
    };

    function initialize() {
        newNomralPhoto(new photoModel());
        newFlickrPhoto(new photoModel());
    }
    initialize();

    return {
        mainSelectedPics: mainSelectedPics,
        dialogSelectedPics: dialogSelectedPics,
        isNewPhoto: isNewPhoto,
        isFlickrPhoto: isFlickrPhoto,
        newNomralPhoto: newNomralPhoto,
        newFlickrPhoto : newFlickrPhoto,
        searchString: searchString,
        searchResultPic: searchResultPic,
        onOptionPage: onOptionPage,

        chooseAddNewPhoto: chooseAddNewPhoto,
        chooseAddExistingPhoto: chooseAddExistingPhoto,
        search: search,
        addToSelection: addToSelection,
        chooseAddFlickrPhoto: chooseAddFlickrPhoto,
        chooseAddNormalPhoto: chooseAddNormalPhoto,
        SaveNormalPhoto: SaveNormalPhoto,
        SaveFlickrPhoto: SaveFlickrPhoto,
        backToOption: backToOption
    };
})(ko, null);

// Initiate the Knockout bindings
ko.applyBindings(window.selectPictures.selectPicturesViewModel, $("#AssociateWithPicturesDialog").get(0));


/*
- MainPageSelectedPics

- ViewModelForDialog
	- SelectedPics  []{phototype}
	- IsNewPhoto 
	- IsFlickrPhoto
	- AddingPhotoInfo    {phototype}
	- SearchString 
	- SearchResultPic  []  {phototype}
	

	functions
		- chooseAddNewPhoto
		- chooseAddExistingPhoto
		- search
		- addToSelection
		- chooseAddFlickrPhoto
		- chooseAddNormalPhoto
		- SaveNormalPhoto
		- SaveFlickrPhoto



*/
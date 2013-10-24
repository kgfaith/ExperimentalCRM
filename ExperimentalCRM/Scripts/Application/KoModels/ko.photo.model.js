
var photoModel = function(data) {

        var self = this;
        data = data || {};

        self.pictureId = ko.observable(data.pictureId);
        self.fileName = ko.observable(data.fileName);
        self.flickrUrl = ko.observable(data.flickrUrl);
        self.ownerName = ko.observable(data.ownerName);
        self.title = ko.observable(data.title);
        self.description = ko.observable(data.description);
        self.pictureSourceId = ko.observable(data.pictureSourceId);
        self.pictureSourceName = ko.observable(data.pictureSourceName);
        self.errorMessage = ko.observable();
        
        self.toJson = function () {
            return ko.toJSON(self);
        };

        self.populateDataForModel = function (data) {
            self.pictureId(data.PictureId);
            self.fileName(data.PictureId);
            self.flickrUrl(data.Url);
            self.ownerName(data.OwnerName);
            self.title(data.Title);
            self.description(data.Description);

        };
    };


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
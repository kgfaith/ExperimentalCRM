
var photoModel = function(data) {

        var self = this;
        data = data || {};

        self.pictureId = ko.observable(data.PictureId);
        self.fileName = ko.observable(data.FileName);
        self.flickrUrl = ko.observable(data.FlickrUrl);
        self.imageUrl = ko.observable(data.ImageUrl);
        self.isImageUrlNull = ko.computed(function () {
            var str = self.imageUrl();
            var isNull = (typeof str == 'undefined' || str == '');
            return isNull;
        }, this);

        self.ownerName = ko.observable(data.OwnerName);
        self.title = ko.observable(data.Title);
        self.description = ko.observable(data.Description);
        self.pictureSourceId = ko.observable(data.PictureSourceId);
        self.pictureSourceName = ko.observable(data.PictureSourceName);
        self.errorMessage = ko.observable();
        
        self.toJson = function () {
            return ko.toJSON(self);
        };

        self.populateDataForModel = function (data) {
            self.pictureId(data.PictureId);
            self.fileName(data.PictureId);
            self.flickrUrl(data.Url);
            self.imageUrl(data.SmallImageUrl);
            self.ownerName(data.OwnerName);
            self.title(data.Title);
            self.description(data.Description);
        };
    };


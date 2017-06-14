function ProductListViewModel() {
    var self = this;
    var img;
    //self.productList = ko.observableArray([{}]);
    //self.produtList = ko.observableArray([]);
    self.productsTable = ko.observableArray([]);
    self.productTableEditor = ko.observableArray([]);
    self.productImageEditor = ko.observable({ Image: ko.observable(), productPictures: ko.observableArray([]), ProductDesplayed: ko.observable(), Product: {}, productMainImageInvalid: ko.observable(false), productDeletePictures: [], productPictureIsDeleted: ko.observable(false), productUpdatedPictures: [], productUpdatedUrlPicture: "", productNewPictures: [], ProductPictureNewUrl: "", ProductNewUrLPicture: "" });
    self.productShortDescriptionEditor = ko.observable({ productShortDescriptions: [] });
    self.productDescriptionEditor = ko.observable({ productDescriptions: ko.observableArray([]) });
    self.test = ko.observableArray([1, 2, 3]);
    self.productImageEditor().productUpdatedUrlPicture = self.productImageEditor().ProductDesplayed;

    self.changeImage = function (model, event) {
        var input = event.target;
        if (input.files && input.files[0]) {
            var reader = new FileReader(); 
            reader.onload = function (e) {
                self.productImageEditor().Image(e.target.result);
                console.log(self.productImageEditor().Image());
            }
            reader.readAsDataURL(input.files[0]);
        }
    };
    self.changeNameDescription=function() {
        
    }

    self.addPicture = function (model, event) {
        var input = event.target;
        if (input.files && input.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                self.productImageEditor().productPictures.push(e.target.result);
                self.productImageEditor().productNewPictures.push({ picture: e.target.result, indexPicure: self.productImageEditor().productPictures().length-1 });
                self.productImageEditor().ProductDesplayed(e.target.result);

            }
            reader.readAsDataURL(input.files[0]);
        }
    };

    self.addProductNewUrlPicture=function() {
        self.productImageEditor().productPictures.push(self.productImageEditor().ProductNewUrLPicture);
        self.productImageEditor().productNewPictures.push({ picture: self.productImageEditor().ProductNewUrLPicture, indexPicure: self.productImageEditor().productPictures().length - 1 });
        self.productImageEditor().ProductDesplayed(self.productImageEditor().ProductNewUrLPicture);
    }

    self.changePicture = function (model, event) {
        var input = event.target;
        if (input.files && input.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                var editPicture = self.productImageEditor().ProductDesplayed();
                for (var i=0; i<self.productImageEditor().productPictures().length; i++) {
                    if (editPicture == self.productImageEditor().productPictures()[i]) {
                        self.productImageEditor().productPictures().splice(i, 1);
                        self.productImageEditor().productUpdatedPictures.push({ editPicture: editPicture, indexPicure: i });
                        break;
                    }
                }
                self.productImageEditor().productPictures.push(e.target.result);
                self.productImageEditor().ProductDesplayed(e.target.result);
                
            }
            reader.readAsDataURL(input.files[0]);
        }
    };

    self.changeUrlPicture=function() {
        for (var i = 0; i < self.productImageEditor().productPictures().length; i++) {
            if (self.productImageEditor().productPictures()[i] == self.productImageEditor().ProductDesplayed) {
                self.productImageEditor().productUpdatedPictures.push({ editPicture: self.productImageEditor().ProductDesplayed, indexPicure: i });
                
                self.productImageEditor().productPictures()[i]=self.productImageEditor().productUpdatedUrlPicture;
                self.productImageEditor().ProductDesplayed(self.productImageEditor().productUpdatedUrlPicture);
                        break;
            }
        }
    }
    
    self.undoProductPictureChange = function () {
        var et = self.productImageEditor().productUpdatedPictures[0].indexPicure;
        for (var i = 0; i < self.productImageEditor().productPictures().length; i++) {
            var t = self.productImageEditor().productUpdatedPictures[i].indexPicure;
            if (self.productImageEditor().productUpdatedPictures[i].indexPicure == i) {
                self.productImageEditor().productPictures().splice(i, 1);
                self.productImageEditor().productPictures().push(self.productImageEditor().productUpdatedPictures[i].editPicture);
                self.productImageEditor().ProductDesplayed(self.productImageEditor().productUpdatedPictures[i].editPicture);
                self.productImageEditor().productUpdatedUrlPicture = self.productImageEditor().productUpdatedPictures[i].editPicture;
                break;
            }
        }
    }

    self.deleteProductPicture = function (image) {
        for (var i = 0; i < self.productImageEditor().productPictures().length; i++) {
            if (self.productImageEditor().productPictures()[i] == image) {
                self.productImageEditor().productDeletePictures.push(image);
                self.productImageEditor().productPictureIsDeleted(true);
                //self.productImageEditor().productPictures().splice(i, 1);
                //var indexNextPicture = i + 1;
                //if (indexNextPicture >= self.productImageEditor().productPictures().length) {
                //    indexNextPicture = 0;
                //}
                //self.productImageEditor().ProductDesplayed(self.productImageEditor().productPictures()[indexNextPicture]);
            }
        }
    }

    self.delNewImage = function (image) {
        for (var i = 0; i < self.productImageEditor().productNewPictures.length; i++) {
            var e = self.productImageEditor().productNewPictures[0];
            if (image == self.productImageEditor().productNewPictures[i].picture) {
                self.productImageEditor().productNewPictures.splice(i, 1);
                var num = self.productImageEditor().productPictures().length;
                for (var p = 0; p < self.productImageEditor().productPictures().length; p++) {
                    if (image == self.productImageEditor().productPictures()[p]) {
                        self.productImageEditor().productPictures().splice(p, 1);
                        var indexNextPicture = p + 1;
                        if (indexNextPicture >= self.productImageEditor().productPictures().length) {
                            indexNextPicture = 0;
                        }
                        self.productImageEditor().ProductDesplayed((self.productImageEditor().productPictures()[indexNextPicture]));
                        self.productImageEditor().productUpdatedUrlPicture = self.productImageEditor().productPictures()[indexNextPicture];
                    }
                }
                
            }
            
        }
    }

    self.openProductShortDescriptionEditor = function (productId) {
        
        for (var i = 0; i < products.length; i++) {
            if (productId == products[i].ProductId) {
                for (var d = 0; d < products[i].Descriptions.length; d++)
                    if (products[i].Descriptions[d].IsShort) {
                        var description;
                        description.name = products[i].Descriptions[d].Name;
                        description.text = products[i].Descriptions[d].Text;
                        self.productShortDescriptionEditor().productShortDescriptions.push(description);
                    }
            }
        }
    }

    self.openProductDescriptionEditor = function (productId) {
        for (var i = 0; i < products.length; i++) {
            if (products[i].ProductId == productId) {
                var descriptions = [];
                for (var d = 0; d < products[i].Descriptions.length; d++) {
                    var description={};
                    description.name = products[i].Descriptions[d].Name;
                    description.text = products[i].Descriptions[d].Text;
                    descriptions.push(description);
                    self.test([1,2,3,4,5,6]);
                    //alert(q);
                    //console.log(self.productDescriptionEditor().productDescriptions());
                }
                self.productDescriptionEditor().productDescriptions(descriptions);
                break;
            }
        }
        
    }

    self.openProductImageEditor = function (productId) {
        
        self.productImageEditor().productMainImageInvalid(false);
        for (var i = 0; i < products.length; i++) {
            if (productId == products[i].ProductId) {
                self.productImageEditor().Image(products[i].Image);
                self.productImageEditor().Product = products[i];
                self.productImageEditor().ProductDesplayed(products[i].Pictures[0]);
                for (var p=0; p<products[i].Pictures.length; p++) {
                    self.productImageEditor().productPictures.push(products[i].Pictures[p]);
                }
                
                break;
            }
        }
    };

    self.slideProductImage = function (image, direction) {
        self.productImageEditor().productPictureIsDeleted(false);
        var num = self.productImageEditor().productPictures().length;
        var w = self.productImageEditor().productPictures()[0];
        var wl = self.productImageEditor().productPictures();
        for (var i = 0; i < num; i++) {
            var prI = self.productImageEditor().productPictures()[i];
            if (prI == image) {
                var numImage=0;
                if (direction == 0) {
                    numImage = i - 1;
                    if (numImage < 0) {
                        numImage = self.productImageEditor().productPictures().length - 1;
                    }
                } else {
                    numImage = i + 1;
                    if (numImage >= self.productImageEditor().productPictures().length) {
                        numImage = 0;
                    }
                }
                var productPicture = self.productImageEditor().productPictures()[numImage];
                if (self.productImageEditor().productDeletePictures!=undefined) {
                    for (var p = 0; p < self.productImageEditor().productDeletePictures.length; p++) {
                        if (productPicture == self.productImageEditor().productDeletePictures[p]) {
                            self.productImageEditor().productPictureIsDeleted(true);
                        }
                    }
                }
                self.productImageEditor().ProductDesplayed(productPicture);
                self.productImageEditor().productUpdatedUrlPicture = productPicture;
                break;
            }
            
        }
        img = self.productImageEditor().ProductDesplayed(productPicture);
    }
    self.undoProductMainImageChange = function() {
        //self.productImageEditor().Image(self.productImageEditor().Product.Image);
        self.productImageEditor().productMainImageInvalid(true);
    };

    self.addImageProductPictures = function (model, event) {
        var input = event.target;
        if (input.files && input.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                self.productImageEditor().productPictures.push(e.target.result);
                
            }
            reader.readAsDataURL(input.files[0]);
        }
    };
    self.saveProductImageChange = function () {
        if (self.productImageEditor().Image().match(/\.(jpeg|jpg|gif|png)$/) == null) {
            self.productImageEditor().productMainImageInvalid(true);
        } else {
            self.productImageEditor().productMainImageInvalid(false);
        }
    };
};
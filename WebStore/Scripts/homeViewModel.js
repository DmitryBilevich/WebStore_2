function HomeViewModel() {
    var self = this;
    var data = {};
    self.data = data;
    data.sections = [];

    
    var sections;

    $.ajax({
        url: "/api/home",
        type: "Get",
        contentType: 'application/json',
        async: false,
        success: function (x) {
            x = JSON.parse(x);
            sections = x.Sections;
        }
    });
    console.log(sections);
    if (sections) {
        for (var i = 0; i <sections.length; i++) {
            var categories = sections[i].Categories;
            for (var j = 0; j < categories.length; j++) {
                var category = categories[j];
                category.isActive = ko.observable(false);
            }
            data.sections.push(sections[i]);
        }
    } else {
        // Mock data in case if ajax request is failed.
        data.sections = [getLaptopsTabletsSection, getPhonesSection];
    }

    self.productMenuItems = [];
    for (var i=0; i<data.sections.length; i++ ) {
        self.productMenuItems.push({ name: data.sections[i].Name, isActive: ko.observable(false), url: data.sections[i].URL, isLongText: data.sections[i].IsLongText, categories: data.sections[i].Categories });
     }

    self.showBanner = ko.observable(false);
    self.showProductList = ko.observable(false);
    self.productMenuActive = ko.observable();
    self.showBanner(true);
    window.location.hash = "#";

    self.disActiveMenuItems = function() {
        for (var i = 0; i < self.productMenuItems.length; i++) {
            self.productMenuItems[i].isActive(false);
        }
    };

    self.productCategoryHover = function (section, category) {
        for (var i = 0; i < section.categories.length; i++) {
                section.categories[i].isActive(false);
        }
        category.isActive(true);
    };
    self.showLogin = ko.observable(false);
   
    self.login = function () {
        self.goToMainPage();
    };

    self.openProductMenu = function() {
        self.showBanner(false);
    };

    self.productMenuItemClick = function(item) {
        var isActive = item.isActive();
        for (var i = 0; i < self.productMenuItems.length; i++) {
            self.productMenuItems[i].isActive(false);
        }
        if (!isActive)
            item.isActive(true);

        self.showBanner(false);
        self.productMenuActive(item.name);
        window.location.hash = item.url;
    };

    self.goToMainPage = function() {
        for (var i = 0; i < self.productMenuItems.length; i++) {
            self.productMenuItems[i].isActive(false);
        }
        window.location.hash = "";
        self.hideAllContainers();
        self.disActiveBreadcrumbNav();
        self.showBanner(true);
    };

    self.displayedProductList = ko.observableArray();

    function shuffle(array) {
        var currentIndex = array.length, temporaryValue, randomIndex;

        // While there remain elements to shuffle...
        while (0 !== currentIndex) {

            // Pick a remaining element...
            randomIndex = Math.floor(Math.random() * currentIndex);
            currentIndex -= 1;

            // And swap it with the current element.
            temporaryValue = array[currentIndex];
            array[currentIndex] = array[randomIndex];
            array[randomIndex] = temporaryValue;
        }

        return array;
    }

    self.breadcrumbNav = {
        isActive: ko.observable(false),
        section: ko.observable(),
        category: ko.observable(),
        subCategory: ko.observable(),
        product: ko.observable(),
    };

    self.breadcrumbNavCategoryClick = function() {
        self.breadcrumbNav.subCategory(null);
        self.breadcrumbNav.product(null);
        self.categoryClick(self.breadcrumbNav.section(), self.breadcrumbNav.category());
    };

    self.breadcrumbNavSubCategoryClick = function () {
        self.breadcrumbNav.product(null);
        self.subCategoryClick(self.breadcrumbNav.category(), self.breadcrumbNav.subCategory());
    };

    self.breadcrumbNavSectionClick = function() {
        self.hideAllContainers();
        self.breadcrumbNav.product(null);
        self.breadcrumbNav.subCategory(null);
        self.breadcrumbNav.category(null);

        var section = self.breadcrumbNav.section();
        var array = [];
        for (var i = 0; i < section.categories.length; i++) {
            var category = section.categories[i];
            if (category.subCategories) {
                for (var k=0;k<category.subCategories.length;k++) {
                    var subCategory = category.subCategories[k];
                    if (!subCategory.products)
                        continue;
                    for (var j = 0; j < subCategory.products.length; j++) {
                        array.push(subCategory.products[j]);
                    }
               }
            }
        }
        self.displayedProductList(shuffle(array));
        self.title(section.name);
        self.showProductList(true);
    };

    self.categoryClick = function (section, category) {
        self.hideAllContainers();
        self.disActiveMenuItems();
        window.location.hash = category.url;
        var array = [];
        for (var i = 0; i < category.subCategories.length; i++) {
            var subCategory = category.subCategories[i];
            if (!subCategory.products)
                continue;
            for (var j = 0; j < subCategory.products.length; j++) {
                array.push(subCategory.products[j]);
            }
        }

        self.displayedProductList(shuffle(array));
        self.showProductList(true);
        self.title(category.name);
        self.breadcrumbNav.isActive(true);
        self.breadcrumbNav.section(section);
        self.breadcrumbNav.category(category);
    };

    self.subCategoryClick = function (category, item) {
        self.hideAllContainers();
        window.location.hash = item.url;
        var section = self.breadcrumbNav.section();
        for (var i = 0; i < self.productMenuItems.length; i++) {
            if (self.productMenuItems[i].isActive()) {
                if(!section)
                section = self.productMenuItems[i];
                self.productMenuItems[i].isActive(false);
                break;
            }
        }
        category.isActive(false);
        self.displayedProductList(item.products);
        self.showProductList(true);
        self.title(item.name);
        self.breadcrumbNav.isActive(true);
        self.breadcrumbNav.section(section);
        self.breadcrumbNav.category(category);
        self.breadcrumbNav.subCategory(item);
    };

    self.title = ko.observable("");
    self.breadcrumbs = ko.observableArray([]);

    self.showProduct = ko.observable(false);

    self.displayedProduct = ko.observable();

    self.openProduct = function(product) {
        self.title(null);
        self.breadcrumbs.push(product.name);
        self.displayedProduct(product);
        self.showProductList(false);
        self.showProduct(true);
        self.productDetailsQty(1);

        self.breadcrumbNav.product(product);
    };

    self.productScrollToSpecification = function() {
        $('#mainContainer').animate({
            scrollTop: $("#productSpecifTable").offset().top
        }, 2000);
    };

    self.timer = ko.observable(new Date());
    window.setInterval(function () { self.timer(new Date()); }, 1000);
    var monthNames = [
        "January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"
    ];
    self.shippingTomorrow = ko.computed(function () {
        if (self.showProduct() != true)
            return null;

        var date = new Date();
        date.setDate(self.timer().getDate() + 1);

        return monthNames[date.getMonth()] + " " + date.getDate();
    }, self);

    self.shippingOrderTimer = ko.computed(function () {
        if (self.showProduct() != true)
            return null;
        
        var date1 = self.timer();
        var date2 = new Date();
        date2.setHours(20);
        date2.setMinutes(0);
        date2.setMinutes(0);
        date2.setSeconds(0);
        date2.setMilliseconds(0);
        var diff = date2 - date1;
        if (diff < 0)
            return null;

        var hours = Math.floor(diff / 36e5);
        var minutes = Math.floor((diff - hours * 36e5) / 1000 / 60);
        var seconds = Math.floor((diff - hours * 36e5 - minutes * 60000) / 1000);

        return hours + ":" + minutes + ":" + seconds;
    }, self);

    self.cart = {
        products: ko.observableArray([]), 
        isEmpty: ko.observable(true)
    };
    self.cart.productsCount = ko.pureComputed(function () {
        var quantity = 0;
        for (var i = 0; i < self.cart.products().length; i++) {
            quantity = quantity + self.cart.products()[i].quantity();
        }
        return quantity;
    }, self);
    self.cart.isEmpty = ko.pureComputed(function () {
        if (self.cart.productsCount() > 0)
            return false;
        return true;
    }, self);

    self.cart.total = ko.pureComputed(function() {
        var total = 0;
        for (var i = 0; i < self.cart.products().length; i++) {
            total = total + parseFloat(self.cart.products()[i].getTotalPrice().slice(1));
        }
        return "$" + total;
    }, self);

    self.listAddProductToCart = function(product) {
        self.addProductToCart(product, 1);
    }

    self.quantityOptions = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

    self.productDetailsQty = ko.observable(1);

    self.prodAddProductToCart = function () {
        self.addProductToCart(self.displayedProduct(), self.productDetailsQty());
    }

    self.productJustAdded = ko.observable();

    self.showCart = ko.observable(false);

    self.removeProductFromCart = function(product) {
        self.cart.products.remove(product);
    };

    self.addProductToCart = function (product, qty) {
        qty = parseInt(qty);
        //if (self.cart.isEmpty() == true)
        //    self.cart.isEmpty(false);

        var match = false;
        for (var i = 0; i < self.cart.products().length; i++) {
            if (self.cart.products()[i].name == product.name) {
                self.cart.products()[i].quantity(self.cart.products()[i].quantity() + qty);
                match = true;
                break;
            }
        }
        if (!match) {
            var cartProd = jQuery.extend(true, {}, product);
            cartProd.quantity = ko.observable(qty);
            cartProd.getTotalPrice = ko.pureComputed(function() {
                var quantity = cartProd.quantity();
                var price = cartProd.price;
                if (!quantity || !price)
                    return null;

                var priceFloat = parseFloat(price.slice(1));
                if (!priceFloat)
                    return null;

                var result = "$" + priceFloat * parseInt(quantity);

                return result;
            }, self);
            self.cart.products.push(cartProd);
        }

        self.productJustAdded(product);
        $("#productAddedDialog").modal("show");
    }

    self.hideAllContainers = function () {
        self.title(null);
        self.breadcrumbs([]);
        self.showProduct(false);
        self.showBanner(false);
        self.showProductList(false);
        self.showCart(false);
        self.showCheckout(false);
        self.showLogin(false);
    };

    self.goToCart = function () {
        $("#productAddedDialog").modal("hide");
        self.hideAllContainers();
        self.disActiveBreadcrumbNav();
        self.showCart(true);
        window.location.hash = 'Cart';
    };

    self.goToCheckout = function () {
        $("#productAddedDialog").modal("hide");
        self.hideAllContainers();
        self.disActiveBreadcrumbNav();
        self.showCheckout(true);
    };

    self.continueShopping = function () {
        self.goToMainPage();
    };

    self.showCheckout = ko.observable(false);

    self.cartGoToCheckout = function () {
        self.hideAllContainers();
        self.disActiveBreadcrumbNav();
        self.showCheckout(true);
    };

    self.disActiveBreadcrumbNav = function() {
        self.breadcrumbNav.isActive(false);
        self.breadcrumbNav.section(null);
        self.breadcrumbNav.category(null);
        self.breadcrumbNav.subCategory(null);
        self.breadcrumbNav.product(null);
        window.location.hash = '#';
    };

    self.goToLogin = function() {
        self.hideAllContainers();
        self.disActiveBreadcrumbNav();
        self.title(null);
        self.showLogin(true);
    };
};
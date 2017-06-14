function getPhonesSection() {
    var section = {};
    section.name = "Phones";
    var category1 = { name: "Smartphones and Mobiles", isActive: ko.observable(false) };
    var category2 = { name: "Smart Watches and Wristbands", isActive: ko.observable(false) };
    var category3 = { name: "Watches and accessories", isActive: ko.observable(false) };
    var category4 = { name: "GPS Navigation", isActive: ko.observable(false) };
    var category5 = { name: "Video Recorders", isActive: ko.observable(false) };
    var category6 = { name: "Flash Memory", isActive: ko.observable(false) };
    var category7 = { name: "Drones", isActive: ko.observable(false) };
    var category8 = { name: "Multimedia Devices", isActive: ko.observable(false) };
    var category9 = { name: "Cell Phone Accessories", isActive: ko.observable(false) };
    var category10 = { name: "GPS Accessories", isActive: ko.observable(false) };
    var category11 = { name: "Accessories for drones", isActive: ko.observable(false) };

    section.categories = [category1, category2, category3, category4, category5, category6, category7, category8, category9, category10, category11];

    return section;
};
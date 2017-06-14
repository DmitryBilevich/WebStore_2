function getLaptopsTabletsSection() {
    var section = {};
    section.name = "Laptops_Tablets";
    var category1 = { name: "Laptops / Notebooks / Ultrabooks", isActive: ko.observable(false), url: '#Laptops_Notebooks_Ultrabooks' };
    var category2 = { name: "Laptops 2 in 1", isActive: ko.observable(false)};
    var category3 = { name: "Tablets", isActive: ko.observable(false) };
    var category4 = { name: "Ebook readers", isActive: ko.observable(false) };
    var category5 = { name: "Bags & Cases", isActive: ko.observable(false) };
    var category6 = { name: "Accessories for laptops", isActive: ko.observable(false) };
    var category7 = { name: "Accessories for tablets", isActive: ko.observable(false) };

    section.categories = [category1, category2, category3, category4, category5, category6, category7];

    var subCategory1 = { url: '#Laptops_Tablets/Notebooks_Laptops_11.6', name: "Notebooks / Laptops 11.6", image: 'http://cdn.x-kom.pl/i/setup/images/prod/big/product-medium,dell-inspiron-3179-m3-7y304gb128win10-czerwony-322954,pr_2016_9_6_6_19_54_472.jpg' };
    var subCategory2 = { url: '#Laptops_Tablets/Notebooks_Laptops 12.1', name: "Notebooks / Laptops 12.1", image: 'http://cdn.x-kom.pl/i/setup/images/prod/big/product-medium,apple-macbook-retina-6y308gb256mac-os-gold-302826,pr_2016_4_21_11_13_57_105.png' };
    var subCategory3 = { url: '', name: "Notebooks / Laptops 12.5", image: 'http://cdn.x-kom.pl/i/setup/images/prod/big/product-medium,dell-latitude-e7270-i5-6300u8gb2567pro10pro-fhd-293371,pr_2016_3_7_14_3_54_529.jpg' };
    var subCategory4 = { url: '', name: "Notebooks / Laptops 13.3", image: 'http://cdn.x-kom.pl/i/setup/images/prod/big/product-medium,apple-macbook-pro-i5-5257u8gb128iris-6100mac-os-229534,pr_2014_7_1_14_3_43_566.jpg' };
    var subCategory5 = { url: '', name: "Notebooks / Laptops 14.1", image: 'http://cdn.x-kom.pl/i/setup/images/prod/big/product-medium,kiano-slimnote-141-3735f2048mb32gbwindows-10-bialy-309343,pr_2016_5_31_16_20_41_567.jpg' };
    var subCategory6 = { url: '', name: "Notebooks / Laptops 15.4", image: 'http://cdn.x-kom.pl/i/setup/images/prod/big/product-medium,apple-macbook-pro-i716gb256gbmac-os-242492,pr_2014_7_2_7_59_20_766.jpg' };
    var subCategory7 = { url: '', name: "Notebooks / Laptops 15.6", image: 'http://cdn.x-kom.pl/i/setup/images/prod/big/product-medium,asus-r540sa-xx022t-n30504gb1tbdvd-rwwin10-281489,pr_2016_1_18_12_21_33_186.jpg' };
    var subCategory8 = { url: '', name: "Notebooks / Laptops 17.3", image: 'http://cdn.x-kom.pl/i/setup/images/prod/big/product-medium,dell-inspiron-5767-i5-7200u8gb1000win10-r7-fhd-323421,pr_2016_10_24_12_42_54_439.jpg' };
    var subCategory9 = { url: '', name: "Notebooks / Laptops 18.4", image: 'http://cdn.x-kom.pl/i/setup/images/prod/big/product-medium,msi-gt80s-titan-sli-i7-6920hq325121000-gtx980m-fhd-278869,pr_2015_12_16_12_53_31_209.jpg' };
    var subCategory10 = { url: '', name: "Ultrabook 11,6", image: 'http://cdn.x-kom.pl/i/setup/images/prod/big/product-medium,lenovo-yoga-300-11-n30502gb500win10-touch-284455,pr_2016_1_18_8_33_44_270.png' };
    var subCategory11 = { url: '', name: "Ultrabook 12,5", image: 'http://cdn.x-kom.pl/i/setup/images/prod/big/product-medium,asus-zenbook-3-ux390ua-i7-7500u8gb512ssdwin10-fhd-331258,pr_2016_11_4_15_49_10_234.jpg' };
    var subCategory12 = { url: '', name: "Ultrabook 13,3", image: 'http://cdn.x-kom.pl/i/setup/images/prod/big/product-medium,asus-zenbook-flip-ux360ca-m3-6y308gb512ssdwin10-319990,pr_2016_8_10_8_23_32_552.jpg' };
    category1.subCategories = [
        subCategory1, subCategory2, subCategory3, subCategory4,
        subCategory5, subCategory6, subCategory7, subCategory8,
        subCategory9, subCategory10, subCategory11, subCategory12
    ];

    var product = {
        name: 'Dell Inspiron 3162 N3710/4GB/128/Win10 blue',
        shortDescriptions: [
            "Procesor: Intel Pentium N3710 (4 rdzenie, 1.60 GHz, 2 MB cache)",
            'Memory: 4 GB (SO-DIMM DDR3, 1600 MHz)', 'Disc: 128 GB SSD SATA III', 'Graphics: Intel HD Graphics 405'
        ],
        image: 'http://cdn.x-kom.pl/i/setup/images/prod/big/product-medium,dell-inspiron-3162-n37104gb128win10-niebieski-322432,pr_2016_4_22_8_39_27_783.jpg',
        price: '$199.99',
        pictures: [
            'http://cdn.x-kom.pl/i/setup/images/prod/big/product-big,dell-inspiron-3162-n30604gb32win10-niebieski-322923,pr_2016_4_22_8_39_32_378.jpg',
            'http://cdn.x-kom.pl/i/setup/images/prod/big/product-big,dell-inspiron-3162-n30604gb32win10-niebieski-322923,pr_2016_4_22_8_39_27_783.jpg',
            'http://cdn.x-kom.pl/i/setup/images/prod/big/product-big,dell-inspiron-3162-n30604gb32win10-niebieski-322923,pr_2016_4_22_8_39_49_226.jpg',
            'http://cdn.x-kom.pl/i/setup/images/prod/big/product-big,dell-inspiron-3162-n30604gb32win10-niebieski-322923,pr_2016_4_22_8_39_59_431.jpg'
        ],
        rating: 4,
        Description: [
            { name: "RAM", text: "4 GB (SO-DIMM DDR3 1600 MHz)" },
            { name: "Procesor", text: "Intel Celeron N3060 (2 cores, from 1.60 GHz to 2.48 GHz, 2 MB cache)" },
            { name: "The maximum supported RAM", text: "4 GB" },
            { name: "Number of memory slots (total / free)", text: "0/0 memory (soldered)" },
            { name: "Hard Disk", text: "Drive 32 GB SSD eMMC" },
            { name: "Built-in optical drives", text: "No" },
            { name: "Screen type", text: "Matt, LED" },
            { name: "Screen size", text: "11.6''" },
            { name: "Screen resolution", text: "1366 x 768 (HD)" },
            { name: "Graphics card", text: "Intel HD Graphics" },
            { name: "The size of graphics memory", text: "Shared memory" },
            { name: "Sound", text: "Integrated sound card compatible with Intel High Definition Audio" },
            { name: "Webcam", text: "1.0 megapixel" },
            { name: "Connectivity", text: "Wi-Fi 802.11 b / g / n / ac" },
            { name: "Battery", text: "3-cell, 4013 mAh, Li-Ion" },
            { name: "Operating system", text: "Microsoft Windows Home 10 GB (64-bit)" },
            { name: "Included software", text: "Partition recovery (option to restore from a disk)" },
            { name: "Height", text: "18.5 mm" },
            { name: "Width", text: "293 mm" },
            { name: "Depth", text: "196.5 mm" },
            { name: "Weight", text: "1.18 kg (with battery)" },
            { name: "Supplied accessories", text: "AC adapter" },
            { name: "Warranty ", text: "24 months" }
        ]
    };

    subCategory1.products = [];
    for (var i = 1; i < 41; i++) {
        var p = jQuery.extend(true, {}, product);;
        p.name = "#" + i + " " + p.name;
        subCategory1.products.push(p);
    }


     product = {
         name: 'Apple MacBook Retina 6Y30/8GB/256/Mac OS Gold',
        shortDescriptions: [
            "Processor: Intel Core m3-6Y30 (2 cores, 1.10 GHz to 2.20 GHz, 4 MB cache)",
            'Memory: 8 GB (SO-DIMM DDR3 1866 MHz)', 'Dysk: 256 GB SSD M.2 PCIe', 'Graphics: Intel HD Graphics 515',
            'OS X El Capitan', '12 months (warranty)'
        ],
        image: 'http://cdn.x-kom.pl/i/setup/images/prod/big/product-medium,apple-macbook-retina-6y308gb256mac-os-gold-302826,pr_2016_4_21_11_13_57_105.png',
        price: '$1299',
        pictures: [
            'http://cdn.x-kom.pl/i/setup/images/prod/big/product-big,apple-macbook-retina-6y308gb256mac-os-gold-302826,pr_2016_4_21_11_14_2_183.png',
            'http://cdn.x-kom.pl/i/setup/images/prod/big/product-big,apple-macbook-retina-6y308gb256mac-os-gold-302826,pr_2016_4_21_11_13_57_105.png',
            'http://cdn.x-kom.pl/i/setup/images/prod/big/product-big,apple-macbook-retina-6y308gb256mac-os-gold-302826,pr_2016_4_21_11_14_7_386.png',
            'http://cdn.x-kom.pl/i/setup/images/prod/big/product-big,apple-macbook-retina-6y308gb256mac-os-gold-302826,pr_2016_4_21_11_14_12_105.jpg',
            'http://cdn.x-kom.pl/i/setup/images/prod/big/product-big,apple-macbook-retina-6y308gb256mac-os-gold-302826,pr_2016_4_21_11_14_2_183.png'
        ],
        rating: 5,
        Description: [
            { name: "Procesor", text: "Intel Core m3-6Y30 (2 cores, 1.10 GHz to 2.20 GHz, 4 MB cache)" },
            { name: "RAM", text: "8 GB (SO-DIMM DDR3, 1866 MHz)" },
            { name: "The maximum supported RAM", text: "8 GB" },
            { name: "Number of memory slots (total / free)", text: "0/0 memory (soldered)" },
            { name: "Hard Disk", text: " 	256 GB SSD M.2 PCIe" },
            { name: "Built-in optical drives", text: "No" },
            { name: "Screen type", text: "Glossy, LED, IPS Retina" },
            { name: "Screen size", text: "12,1''" },
            { name: "Screen resolution", text: "2304 x 1440" },
            { name: "Graphics card", text: "Intel HD Graphics" },
            { name: "The size of graphics memory", text: "Shared memory" },
            { name: "Sound", text: "Integrated sound card compatible with Intel High Definition Audio" },
            { name: "Webcam", text: "1.0 megapixel" },
            { name: "Connectivity", text: "Wi-Fi 802.11 b / g / n / ac" },
            { name: "Battery", text: "3-cell, 4013 mAh, Li-Ion" },
            { name: "Operating system", text: "Microsoft Windows Home 10 GB (64-bit)" },
            { name: "Included software", text: "Partition recovery (option to restore from a disk)" },
            { name: "Height", text: "13,1 mm" },
            { name: "Width", text: "280,5 mm" },
            { name: "Depth", text: "196,5 mm" },
            { name: "Weight", text: "0,93 kg (with battery)" },
            { name: "Supplied accessories", text: "AC adapter" },
            { name: "Warranty ", text: "12 months" }
        ]
    };

    subCategory2.products = [];
    for (var i = 1; i < 41; i++) {
        var p = jQuery.extend(true, {}, product);;
        p.name = "#" + i + " " + p.name;
        subCategory2.products.push(p);
    }

    return section;
};

var productImage;
var productEditableImages = [];
var productEditedList = [];
var modifiedProducts = {};


function selectSection(element) {
    var sectionId = $(element).val();
    var newOptions = "<option></option>";
    for (var i = 0; i < categories.length; i++) {
        if (categories[i].SectionId == sectionId) {
            newOptions += "<option value='" + categories[i].CategoryId + "'>" + categories[i].Name + "</option>";
        }
    }
    var row = $(".product-row").has(element);
    $(".product-category-select", row).html(newOptions);
    $(".product-subcategory-select", row).html("<option>select category</option>");
}
function selectCategory(element) {
    var categoryId = $(element).val();
    var newOptions = "<option></option>";
    for (var i = 0; i < subcategories.length; i++) {
        var num = subcategories[i].CategoryId;
        if (num == categoryId) {
            newOptions += "<option value='" + subcategories[i].SubcategoryId + "'>" + subcategories[i].Name + "</option>";
        }
    }
    var row = $(".product-row").has(element);
    $(".product-subcategory-select", row).html(newOptions);
}

function openProductImageEditor (productId) {
    var product;
    for (var i = 0; i < products.length; i++) {
        if (productId == products[i].ProductId) {
            product = products[i];
            productEditableImages = product.Pictures.slice();
            productImage = product.Image;
        }
    }
                
    var newImage = "<img id='product-mainImage-image' src='"+productImage+"'/></br>" +
        "<span> Image Url</span><input  id='imageUrl' type='text' value='" + productImage + "'/></br>" +
        "<span>  Image file</span><input onchange='changeImage(this)' id='imageFile' type='file'/>";
    $("#product-mainImage-image").attr("src", productImage);
    $("#imageUrl").attr("value", productImage);
};

function slideImage(forward) {
    var displayedImage = "";
    for (var i = 0; i < productEditableImages.length; i++) {
        if (productImage == productEditableImages[i]) {
            if (forward == 0) {
                displayedImage = productEditableImages[i - 1];
            } else {
                displayedImage = productEditableImages[i + 1];
            }
        }
    }
    var newImage = "<img src='" + displayedImage + "'/>";
    $(".product-image-conteiner").html(newImage);
};

function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#blah').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}

function changeImage(input) {
    var mainImage = "";
    $("#imageUrl").attr({ disabled: "" });

    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#product-mainImage-image').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
};

function delImageFile() {
    var mainImage = $("#imageUrl").val();
    $("#imageUrl").prop("disabled", false);
    //$("#product-mainImage-image").removeAttr("src");
    $("#product-mainImage-image").attr("src", mainImage);
    $("#imageFile").val("");
    
}

function changeProductProperty(element) {
    var productId = $(".product-row").has(element).attr("data-productid");
    modifiedProducts[productId] = null;
}

var productIdChangedProduct;
function showActionProductDialog(element) {
    var productName="";
    productIdChangedProduct = $(".product-row").has(element).attr("data-productid");
    for (var i = 0; i < products.length; i++) {
        if (productIdChangedProduct == products[i].ProductId) {
            productName = products[i].Name;
            break;
        }
    }
    $(".action-product-name").text(productName);
    var newName = $("input[name = 'name']", $(".product-row").has(element)).val();
    if (productName!=newName) {
        $(".action-product-newName").text(newName);
    }
}


function confirmUndoProductChanges() {
    $('#actionProduct').modal('toggle');
    customConfirm("YOU WANT TO", undoProductChanges);
}

function undoProductChanges() {
   
    var parentRow = $("tr[data-productid='" + productIdChangedProduct + "']");
    for (var i = 0; i < products.length; i++) {
        if (productIdChangedProduct==products[i].ProductId) {
            $("input[name='name']", parentRow).val(products[i].Name);
            $("input[name='price']", parentRow).val(products[i].Price);
            $("input[name='rating']", parentRow).val(products[i].Raing);
            break;
        }
    }
}

function confirmUpdateProduct(){
    $('#actionProduct').modal('toggle');
    customConfirm("YOU WANT TO SAVE CHANGES", updateProduct);
}

function updateProduct() {
    var product = {};
    var parentRow = $("tr[data-productid='" + productIdChangedProduct + "']");
    product.Name = $("input[name='name']", parentRow).val();
    product.Price = $("input[name='price']", parentRow).val();
    product.Rating = $("input[name='rating']", parentRow).val();
    product.ProductId = productIdChangedProduct;
    $.ajax({
        url: "/product/updateproduct",
        type: "POST",
        data: product
    });
}

var customConfirmYesFunction;
function customConfirmYes() {
    if (typeof customConfirmYesFunction=="function") {
        customConfirmYesFunction();
        $('#confirmDialog').modal('toggle');
    }
}

function customConfirm(text, fun) {
    customConfirmYesFunction = fun;
    $(".confirm-dialog-text").text(text);
    $('#confirmDialog').modal('toggle');
}


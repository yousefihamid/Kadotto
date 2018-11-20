$(function () {
    $.Kaadoto = {};
    $.Kaadoto.Shop = {};
    $.extend($.Kaadoto.Shop, {
        SelectedBoxPlaceCount: 0,
        SelectedProductCount: 0,
        initializing: function () {

        },
        AddBox: function (obj) {
            var Box = $(obj).siblings('img').clone();
            var BoxID = $(obj).parents('.ws-works-item').attr('tag');
            $.Kaadoto.Shop.SelectedBoxPlaceCount = $(obj).parents('.ws-works-item').attr('data-placeCount');
            var SelectedBox = $('.BoxSelected').clone().removeClass('BoxSelected').addClass('Box_' + BoxID);
            $(SelectedBox).attr("tag", BoxID);
            $(SelectedBox).append(Box)
            $('.SalePanel').removeClass('hidden');
            $('.selected-Boxes').append(SelectedBox);

            $('#Boxes').removeClass('in').css('height', 0).attr("aria-expanded", false);
            $('#Products').addClass('in').attr('style', null);
            $('#Box-toggle').attr('href', '');
            $('#Product-toggle').attr('href', '#Products');
        },
        DeleteBox: function (obj) {
            var BoxID = $(obj).parent().attr("tag");
            $('.selected-Products').html('');
            $('.selected-Boxes').html('');
            $('.Price').text(0);
            $('.SalePanel').addClass('hidden');
            $.Kaadoto.Shop.SelectedBoxPlaceCount = 0;

            $('#Products').removeClass('in').css('height', 0).attr("aria-expanded", false);
            $('#Boxes').addClass('in').attr('style', null);
            $('#Box-toggle').attr('href', '#Boxes');
            $('#Product-toggle').attr('href', '');
        },
        AddProduct: function (obj) {
            if ($.Kaadoto.Shop.SelectedBoxPlaceCount > $.Kaadoto.Shop.SelectedProductCount) {
                var Product = $(obj).siblings('img').clone();
                var ProductID = $(obj).parents('.ws-works-item').attr('tag');
                var ProductPrice = parseInt($('.ws-item-price', $(obj).parents(".ws-works-item")).attr("tag"));
                //var BoxID = $('[class^="Box_"]', '.selected-Boxes').attr("tag");
                var SelectedProduct = $('.ProductSelected').clone().removeClass('ProductSelected').addClass('Product_' + ProductID);
                $(SelectedProduct).attr("tag", ProductID);
                $(SelectedProduct).attr("data-price", ProductPrice);
                $(SelectedProduct).append(Product);
                $('.selected-Products').append(SelectedProduct);

                var TotalPrice = parseInt($('.Price').text());
                TotalPrice += ProductPrice;
                $('.Price').text(TotalPrice);
                $.Kaadoto.Shop.SelectedProductCount += 1;
            }
            else {
                var config = {
                    body: "Box dosen't have enough place;",
                    title: "Shop"
                };
                $.Tools.ShowModal(config);
            }
        },
        DeleteProduct: function (obj) {
            var ProductID = $(obj).parent().attr("tag");
            $('.Product_' + ProductID).remove();
            
            var TotalPrice = parseInt($('.Price').text());
            var ProductPrice = $(obj).parent().attr("data-price");
            TotalPrice -= ProductPrice;
            $('.Price').text(TotalPrice);
            $.Kaadoto.Shop.SelectedProductCount -= 1;
        },
        AddToCard: function () {
            if ($.Kaadoto.Shop.SelectedBoxPlaceCount == $.Kaadoto.Shop.SelectedProductCount) {
                var products = [];
                $.each($('[class*="Product_"]', '.selected-Products'), function () {
                    var product = {
                        ProductID: $(this).attr("tag")
                    };
                    products.push(product);
                });
                var Box = {
                    BoxID: $('[class*="Box_"]', '.selected-Boxes').attr("tag"),
                    Price: parseInt($('.Price').text()),
                    PackagedBoxDetails: products
                };
                var serviceOptions = {
                    url: "/Shop/AddToCard",
                    isAsync: true,
                    method: 'POST',
                    data: JSON.stringify(Box),
                    contentType: 'application/json; charset=utf-8',
                    successCallBack: function (data) {
                        if (data == true) {
                            window.location.href = '/Shop/ShoppingCart';
                        }
                    }
                };
                $.Ajax.Service.Call(new $.Ajax.Models.Service(serviceOptions));
            }
            else {
                var config = {
                    body: "Box dosen't have enough place;",
                    title: "Shop"
                };
                $.Tools.ShowModal(config);
                //alert("Box dosen't have enough place;");
            }
        }
    });
    $.Kaadoto.Shop.initializing();
});
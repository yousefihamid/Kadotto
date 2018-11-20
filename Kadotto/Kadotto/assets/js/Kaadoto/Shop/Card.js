$(function () {
    $.extend($.Kaadoto.Card, {
        initializing: function () {
            var serviceOptions = {
                url: "/Shop/GetCard",
                isAsync: true,
                successCallBack: function (data) {
                    if (data != null && data.length > 0) {
                        $('.ws-shop-minicart').removeClass('hidden');
                        var TotalPrice = 0;
                        $.each(data, function (Index, value) {
                            var PackagedBox = $('.Cart-item-temp').clone().removeClass('Cart-item-temp');
                            $('.packagedBoxTitle', PackagedBox).text(value.BoxTitle);
                            var path = $('.packagedBoxImageName', PackagedBox).attr("src");
                            $('.packagedBoxImageName', PackagedBox).attr("src", path + value.BoxImageName);
                            $('.packagedBoxPrice', PackagedBox).text(value.Price);
                            $('.minicart-content-items').append(PackagedBox);
                            TotalPrice += value.Price;
                        });
                        $('.ws-shop-minicart .packagedBoxTotalPrice').text(TotalPrice);
                    }
                }
            };
            $.Ajax.Service.Call(new $.Ajax.Models.Service(serviceOptions));
        }
    });
    $.Kaadoto.Card.initializing();
});
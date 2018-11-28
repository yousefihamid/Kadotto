$(function () {
    $.Kaadoto.ShoppingCart = {};
    $.extend($.Kaadoto.ShoppingCart, {
        initializing: function () {

        },
        QuantityChanged: function (obj) {
            var Count = $(obj).val();
            var Price = $(".packagedBoxPrice", $(obj).parents(".PackagedBoxTemp")).text();
            var Total = Count * Price;
            $(".packagedBoxTotalPrice", $(obj).parents(".PackagedBoxTemp")).text(Total);
            $.Kaadoto.ShoppingCart.OrderPrice();
        },
        OrderPrice: function () {
            var Subtotal = 0;
            $.each($(".packagedBoxTotalPrice", ".ws-mycart-content"), function () {
                Subtotal += parseInt($(this).text());
            });
            $(".SubtotalPrice").text(Subtotal);
            var OrderTotalPrice = Subtotal + $("ShippingPrice").text();
            $(".OrderTotalPrice").text(OrderTotalPrice);
        }
    });
    $.Kaadoto.ShoppingCart.initializing();
});
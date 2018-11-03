$(function () {
    $.Product = {
        init: function () {

        },
        Edit: function (id) {
            window.location.href = "/Product/Details?ID=" + id;
        },
        View: function (id) {
            $.ajax({
                url: '/Product/GetByID',
                type: 'GET',
                data: { ID: id },
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    var details = $('.details_fn').clone().removeClass('details_fn');
                    $('.Title', details).text(data.Title);
                    $('.BrifDescription', details).text(data.BrifDescription);
                    $('.LongDescription', details).text(data.LongDescription);
                    $('.ProductCategoryTitle', details).text(data.ProductCategoryTitle);
                    $('.Vendor', details).text(data.Vendor);
                    $('.Quantity', details).text(data.Quantity);
                    $('.Weight', details).text(data.Weight);
                    $('.Height', details).text(data.Height);
                    $('.CreationDate', details).text(data.CreationDateString);
                    $('.UpdateDate', details).text(data.UpdateDateString);
                    $('.DisplayOrder', details).text(data.DisplayOrder);

                    var config = {
                        body: details,
                        title: "Product"
                    };
                    $.Tools.ShowModal(config);
                },
                error: function () {
                    alert("Error");
                }
            });
        },
        Delete: function (id) {
            $.ajax({
                url: '/Product/Delete/' + id,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    window.location.href = "/Product/Index";
                },
                error: function () {
                    alert("Error");
                }
            });
        }
    }
    $.Product.init();
});
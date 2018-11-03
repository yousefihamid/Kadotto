$(function () {
    $.ProductCategory = {
        init: function () {

        },
        Edit: function (id) {
            window.location.href = "/ProductCategory/Details?ID=" + id;
        },
        View: function (id) {
            $.ajax({
                url: '/ProductCategory/GetByID',
                type: 'GET',
                data: { ID: id },
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    var details = $('.details_fn').clone().removeClass('details_fn');
                    $('.Title', details).text(data.Title);
                    $('.ParentTitle', details).text(data.ParentTitle);
                    var config = {
                        body: details,
                        title: "Product Category"
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
                url: '/ProductCategory/Delete/' + id,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    window.location.href = "/ProductCategory/Index";
                },
                error: function () {
                    alert("Error");
                }
            });
        }
    }
    $.ProductCategory.init();
});
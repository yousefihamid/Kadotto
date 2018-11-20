$(function () {
    $.Client = {
        init: function () {

        },
        Edit: function (id) {
            window.location.href = "/Client/Details?ID=" + id;
        },
        View: function (id) {
            $.ajax({
                url: '/Client/GetByID',
                type: 'GET',
                data: { ID: id },
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    var details = $('.details_fn').clone().removeClass('details_fn');
                    $('.Title', details).text(data.Title);
                    $('.ImageName', details).text(data.ImageName);
                    var config = {
                        body: details,
                        title: "Client"
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
                url: '/Client/Delete/' + id,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    window.location.href = "/Client/Index";
                },
                error: function () {
                    alert("Error");
                }
            });
        }
    }
    $.Client.init();
});
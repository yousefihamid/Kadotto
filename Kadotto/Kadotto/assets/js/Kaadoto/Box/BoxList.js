$(function () {
    $.Box = {
        init: function () {

        },
        Edit: function (id) {
            window.location.href = "/Box/Details?ID=" + id;
        },
        View: function (id) {
            $.ajax({
                url: '/Box/GetByID',
                type: 'GET',
                data: { ID: id },
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    var details = $('.details_fn').clone().removeClass('details_fn');
                    $('.Name', details).text(data.Name);
                    $('.BoxSize', details).text(data.BoxSize);
                    $('.BoxPlaceCount', details).text(data.BoxPlaceCount);
                    $('.Description', details).text(data.Description);
                    $('.DisplayOrder', details).text(data.DisplayOrder);
                    var config = {
                        body: details,
                        title: "Box"
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
                url: '/Box/Delete/' + id,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    window.location.href = "/Box/Index";
                },
                error: function () {
                    alert("Error");
                }
            });
        }
    }
    $.Box.init();
});
$(function () {
    $.Partition = {
        init: function () {

        },
        Edit: function (id) {
            window.location.href = "/Partition/Details?ID=" + id;
        },
        View: function (id) {
            $.ajax({
                url: '/Partition/GetByID',
                type: 'GET',
                data: { ID: id },
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    var details = $('.details_fn').clone().removeClass('details_fn');
                    $('.Title', details).text(data.Title);
                    $('.PartitionSize', details).text(data.PartitionSize);
                    var config = {
                        body: details,
                        title: "Partition"
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
                url: '/Partition/Delete/' + id,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    window.location.href = "/Partition/Index";
                },
                error: function () {
                    alert("Error");
                }
            });
        }
    }
    $.Partition.init();
});
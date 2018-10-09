$(function () {
    $.Customer = {
        init: function () {

        },
        Edit: function (id) {
            window.location.href = "/Customer/Details?ID=" + id;
        },
        View: function (id) {
            $.ajax({
                url: '/Customer/GetByID',
                type: 'GET',
                data: { ID: id },
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    var details = $('.details_fn').clone().removeClass('details_fn');
                    $('.NameFamily', details).text(data.Name + ' ' + data.Family);
                    $('.UserName', details).text(data.UserName);
                    $('.IsAdmin', details).text(data.IsAdmin);
                    $('.PhoneNumber', details).text(data.PhoneNumber);
                    $('.Email', details).text(data.Email);
                    $('.IsVerified', details).text(data.IsVerified);
                    $('.IsActive', details).text(data.IsActive);
                    $('.CreationDate', details).text(data.CreationDateString);
                    var config = {
                        body: details,
                        title: "Customer"
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
                url: '/Customer/Delete/' + id,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    window.location.href = "/Customer/Index";
                },
                error: function () {
                    alert("Error");
                }
            });
        }
    }
    $.Customer.init();
});
$(function () {
    $.Client = {
        SelectedID: 0,
        init: function () {
            $(document).ready(function () {
                $('#info-form').validator().on('submit', function (e) {
                    if (e.isDefaultPrevented()) {
                        //alert('form is not valid');
                    }
                    else {
                        e.preventDefault();
                        var Client = {
                            ID: $.Client.SelectedID,
                            Title: $('#Title').val(),
                            ImageName: $('.fileName', '#filePhoto').text()
                        };
                        $.ajax({
                            url: '/Client/Save',
                            type: 'POST',
                            data: JSON.stringify(Client),
                            contentType: 'application/json; charset=utf-8',
                            success: function (data) {
                                window.location.href = "/Client/Index";
                            },
                            error: function () {
                                alert("Error");
                            }
                        });
                    }
                });
            });
            $.Client.SelectedID = $.utility.getKey("ID");
            if ($.Client.SelectedID != 0) {
                $.Client.GetByID($.Client.SelectedID);
            }
        },
        GetByID: function (id) {
            $.ajax({
                url: '/Client/GetByID',
                type: 'GET',
                data: { ID: id },
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    $.Client.SelectedID = data.ID;
                    $('#Title').val(data.Title);
                    $('#ImageName').val(data.ImageName);
                },
                error: function () {
                    alert("Error");
                }
            });
        }
    }
    $.Client.init();
});
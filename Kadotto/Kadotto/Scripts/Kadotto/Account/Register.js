$(function () {
    $.Register = {
        SelectedID: 0,
        init: function () {
            $(document).ready(function () {
                $('#info-form').validator().on('submit', function (e) {
                    if (e.isDefaultPrevented()) {
                        //alert('form is not valid');
                    }
                    else {
                        e.preventDefault();
                        var User = {
                            UserName: $('#UserName').val(),
                            Password: $('#Password').val(),
                            PhoneNumber: $('#PhoneNumber').val(),
                            Name: $('#Name').val(),
                            Family: $('#Family').val(),
                        };
                        $.ajax({
                            url: '/Account/Add',
                            type: 'POST',
                            data: JSON.stringify(User),
                            contentType: 'application/json; charset=utf-8',
                            success: function (data) {
                                if (data != 0)
                                    window.location.href = "/Home/Index";
                            },
                            error: function () {
                                alert("Error");
                            }
                        });
                    }
                });
            });

            $.ajax({
                url: '/Account/GetPhoneNumber',
                type: 'GET',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    $("#PhoneNumber").val(data);
                },
                error: function () {
                }
            });
        }
    }
    $.Register.init();
});
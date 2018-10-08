$(function () {
    $.LogIn = {
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
                        };
                        $.ajax({
                            url: '/Account/VerifyUser',
                            type: 'POST',
                            data: JSON.stringify(User),
                            contentType: 'application/json; charset=utf-8',
                            success: function (data) {
                                if (data == true)
                                    window.location.href = "/Home/Index";
                                else
                                    alert("Invalid User and Password");
                            },
                            error: function () {
                                alert("Error");
                            }
                        });
                    }
                });
            });
        }
    }
    $.LogIn.init();
});
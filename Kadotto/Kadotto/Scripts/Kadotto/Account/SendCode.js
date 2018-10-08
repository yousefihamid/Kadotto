$(function () {
    $.SendCode = {
        SelectedID: 0,
        init: function () {
            $(document).ready(function () {
                $('#info-form').validator().on('submit', function (e) {
                    if (e.isDefaultPrevented()) {
                        //alert('form is not valid');
                    }
                    else {
                        e.preventDefault();
                        var number = $('#MobileNumber').val();
                        $.ajax({
                            url: '/Account/SendMobileCode',
                            type: 'POST',
                            data: JSON.stringify({ MobileNumber: number }),
                            contentType: 'application/json; charset=utf-8',
                            success: function (data) {
                                window.location.href = "/Account/VerifyCode";
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
    $.SendCode.init();
});
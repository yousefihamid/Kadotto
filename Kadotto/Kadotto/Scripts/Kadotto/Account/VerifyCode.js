$(function () {
    $.VerifyCode = {
        SelectedID: 0,
        init: function () {
            $(document).ready(function () {
                $('#info-form').validator().on('submit', function (e) {
                    if (e.isDefaultPrevented()) {
                        //alert('form is not valid');
                    }
                    else {
                        e.preventDefault();
                        $.ajax({
                            url: '/Account/VerifyMobileCode',
                            type: 'POST',
                            data: JSON.stringify({ Code: $('#Code').val() }),
                            contentType: 'application/json; charset=utf-8',
                            success: function (data) {
                                if (data == true)
                                    window.location.href = "/Account/Register";
                                else
                                    alert("Invalid Code");
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
    $.VerifyCode.init();
});
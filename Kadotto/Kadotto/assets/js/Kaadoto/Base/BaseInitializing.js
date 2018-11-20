$(function () {
    $.Kaadoto = {};
    $.Kaadoto.BaseInitializing = {};
    $.Kaadoto.Card = {};
    $.extend($.Kaadoto.BaseInitializing, {
        initializing: function () {
            $.ajax({
                url: '/Account/GetCurrentUser',
                type: 'GET',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    if (data != null) {
                        $(".loginMenu").remove();
                        $(".registerMenu").remove();

                        if (data.IsAdmin == true) {
                            $(".adminMenu").removeClass("hidden");
                        }
                        else {
                            $(".adminMenu").remove();
                        }
                    }
                    else {
                        $(".adminMenu").remove();
                    }
                },
                error: function () {

                }
            });
        },
        LogOut: function () {

        }
    });
    $.Kaadoto.BaseInitializing.initializing();
});
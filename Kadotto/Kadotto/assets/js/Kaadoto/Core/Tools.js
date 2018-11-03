$(function () {
    $.Tools = {
        ShowModal: function (config) {
            $('.modal-title', '#myModal').html(config.title);
            $('.modal-body', '#myModal').html(config.body);
            $('.modal-footer', '#myModal').html(config.footer);
            if (config.showFooter == true) {
                $('.modal-footer', '#myModal').show();
            }
            else {
                $('.modal-footer', '#myModal').hide();
            }
            $('#myModal').modal('show');
        }
    };

});
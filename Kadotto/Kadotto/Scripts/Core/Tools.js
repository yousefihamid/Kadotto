$(function () {
    $.Tools = {
        ShowModal: function (config) {
            $('.modal-title', '#modal-container').html(config.title);
            $('.modal-body', '#modal-container').html(config.body);
            $('.modal-footer', '#modal-container').html(config.footer);
            if (config.showFooter == true) {
                $('.modal-footer', '#modal-container').show();
            }
            else {
                $('.modal-footer', '#modal-container').hide();
            }
            $('#modal-container').modal('show');
        }
    };

});
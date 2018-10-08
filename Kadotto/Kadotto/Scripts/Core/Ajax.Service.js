$(function () {
    $.Ajax = {};
    $.Ajax.Service = {};
    $.extend($.Ajax.Service,
    {
        Options: function (option) {
            this.url = option.url;
            this.method = option.method == undefined ? 'Get' : option.method;
            this.isAsync = option.isAsync == undefined ? false : option.isAsync;
            this.data = option.data == undefined ? {} : option.data;
            this.datatype = option.dataType == undefined ? 'json' : option.dataType;
            this.contentType = option.contentType;
            this.successCallBack = option.successCallBack;
            this.showSuccessMessage = option.showSuccessMessage == undefined ? false : option.showSuccessMessage;
            this.completeCallBack = option.completeCallBack;
            this.errorCallBack = option.errorCallBack;
            this.hasLoader = option.hasLoader;
        },
        Call: function (options) {
            var object = {
                url: options.url,
                method: options.method,
                async: options.isAsync,
                data: options.data,
                dataType: options.dataType,
                success: function (data, status, xhr) {
                    if (status == "success") {
                        if (options.successCallBack != undefined) {
                            options.successCallBack(data);
                        }
                    }
                },
                complete: function () {
                    if (options.completeCallBack != undefined)
                        options.completeCallBack();
                },
                error: function (xhr) {
                    if (options.errorCallBack != undefined) {
                        var result = options.errorCallBack(xhr);
                    }
                }
            };

            if (options.contentType != undefined)
                object.contentType = options.contentType;

            $.ajax(object);
        }
    });
});

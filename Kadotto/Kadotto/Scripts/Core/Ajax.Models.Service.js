$(function () {
    $.Ajax.Models = {};
    $.extend($.Ajax.Models,
        {
            Service: function (option) {
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
            DeleteService: function (option) {
                this.url = option.url;
                this.isAsync = option.isAsync == undefined ? true : option.isAsync;
                this.successCallBack = option.successCallBack;
                this.completeCallBack = option.completeCallBack;
                this.errorCallBack = option.errorCallBack;
            }
        }
    );
});
$(function () {
    $.ProductCategory = {
        SelectedID: 0,
        init: function () {
            $(document).ready(function () {
                $('#info-form').validator().on('submit', function (e) {
                    if (e.isDefaultPrevented()) {
                        //alert('form is not valid');
                    }
                    else {
                        e.preventDefault();
                        var ParentID = $('#ParentProductCategory').find(":selected").val();
                        var ProductCategory = {
                            ID: $.ProductCategory.SelectedID,
                            Title: $('#Title').val(),
                            ParentID: ParentID == "" ? null : ParentID
                        };
                        $.ajax({
                            url: '/ProductCategory/Save',
                            type: 'POST',
                            data: JSON.stringify(ProductCategory),
                            contentType: 'application/json; charset=utf-8',
                            success: function (data) {
                                window.location.href = "/ProductCategory/Index";
                            },
                            error: function () {
                                alert("Error");
                            }
                        });
                    }
                });
            });
            $.ProductCategory.SelectedID = $.utility.getKey("ID");
            if ($.ProductCategory.SelectedID != 0) {
                $.ProductCategory.GetByID($.ProductCategory.SelectedID);
            }
        },
        GetByID: function (id) {
            $.ajax({
                url: '/ProductCategory/GetByID',
                type: 'GET',
                data: { ID: id },
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    $.ProductCategory.SelectedID = data.ID;
                    $('#Title').val(data.Title);
                    $("#ParentProductCategory").val(data.ParentID);
                },
                error: function () {
                    alert("Error");
                }
            });
        }
    }
    $.ProductCategory.init();
});
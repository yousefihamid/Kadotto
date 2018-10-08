$(function () {
    $.Product = {
        SelectedID: 0,
        init: function () {
            $(document).ready(function () {
                $('#info-form').validator().on('submit', function (e) {
                    if (e.isDefaultPrevented()) {
                        //alert('form is not valid');
                    }
                    else {
                        e.preventDefault();

                        var Product = {
                            ID: $.Product.SelectedID,
                            Title: $('#Title').val(),
                            BrifDescription: $('#BrifDescription').val(),
                            LongDescription: $('#LongDescription').val(),
                            ProductCategoryID: $('#ProductCategory').find(":selected").val(),
                            Vendor: $('#Vendor').val(),
                            Quantity: $('#Quantity').val(),
                            Weight: $('#Weight').val(),
                            Height: $('#Height').val(),
                            DisplayOrder: $('#DisplayOrder').val(),
                            Visible: true
                        };
                        $.ajax({
                            url: '/Product/Save',
                            type: 'POST',
                            data: JSON.stringify(Product),
                            contentType: 'application/json; charset=utf-8',
                            success: function (data) {
                                window.location.href = "/Product/Index";
                            },
                            error: function () {
                                alert("Error");
                            }
                        });
                    }
                });
            });
            $.Product.SelectedID = $.utility.getKey("ID");
            if ($.Product.SelectedID != 0) {
                $.Product.GetByID($.Product.SelectedID);
            }
        },
        GetByID: function (id) {
            $.ajax({
                url: '/Product/GetByID',
                type: 'GET',
                data: { ID: id },
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    $.Product.SelectedID = data.ID;
                    $('#Title').val(data.Title);
                    $("#BrifDescription").val(data.BrifDescription);
                    $("#LongDescription").val(data.LongDescription);
                    $("#ProductCategory").val(data.ProductCategoryID);
                    $("#Vendor").val(data.Vendor);
                    $("#Quantity").val(data.Quantity);
                    $("#Weight").val(data.Weight);
                    $("#Height").val(data.Height);
                    $("#DisplayOrder").val(data.DisplayOrder);
                },
                error: function () {
                    alert("Error");
                }
            });
        }
    }
    $.Product.init();
});
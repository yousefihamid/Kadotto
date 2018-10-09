$(function () {
    $.Customer = {
        SelectedID: 0,
        init: function () {
            $(document).ready(function () {
                $('#info-form').validator().on('submit', function (e) {
                    if (e.isDefaultPrevented()) {
                        //alert('form is not valid');
                    }
                    else {
                        e.preventDefault();
                        var Customer = {
                            ID: $.Customer.SelectedID,
                            Name: $('#Name').val(),
                            CustomerSize: $('#CustomerSize').val(),
                            CustomerPlaceCount: $('#CustomerPlaceCount').val(),
                            Description: $('#Description').val(),
                            DisplayOrder: $('#DisplayOrder').val()
                        };
                        $.ajax({
                            url: '/Customer/Save',
                            type: 'POST',
                            data: JSON.stringify(Customer),
                            contentType: 'application/json; charset=utf-8',
                            success: function (data) {
                                window.location.href = "/Customer/Index";
                            },
                            error: function () {
                                alert("Error");
                            }
                        });
                    }
                });
            });
            $.Customer.SelectedID = $.utility.getKey("ID");
            if ($.Customer.SelectedID != 0) {
                $.Customer.GetByID($.Customer.SelectedID);
            }
        },
        GetByID: function (id) {
            $.ajax({
                url: '/Customer/GetByID',
                type: 'GET',
                data: { ID: id },
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    $.Customer.SelectedID = data.ID;
                    $('#Name').val(data.Name);
                    $('#CustomerSize').val(data.CustomerSize);
                    $('#CustomerPlaceCount').val(data.CustomerPlaceCount);
                    $('#Description').val(data.Description);
                    $('#DisplayOrder').val(data.DisplayOrder);
                },
                error: function () {
                    alert("Error");
                }
            });
        }
    }
    $.Customer.init();
});
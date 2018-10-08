$(function () {
    $.Box = {
        SelectedID: 0,
        init: function () {
            $(document).ready(function () {
                $('#info-form').validator().on('submit', function (e) {
                    if (e.isDefaultPrevented()) {
                        //alert('form is not valid');
                    }
                    else {
                        e.preventDefault();
                        var Box = {
                            ID: $.Box.SelectedID,
                            Name: $('#Name').val(),
                            BoxSize: $('#BoxSize').val(),
                            BoxPlaceCount: $('#BoxPlaceCount').val(),
                            Description: $('#Description').val(),
                            DisplayOrder: $('#DisplayOrder').val()
                        };
                        $.ajax({
                            url: '/Box/Save',
                            type: 'POST',
                            data: JSON.stringify(Box),
                            contentType: 'application/json; charset=utf-8',
                            success: function (data) {
                                window.location.href = "/Box/Index";
                            },
                            error: function () {
                                alert("Error");
                            }
                        });
                    }
                });
            });
            $.Box.SelectedID = $.utility.getKey("ID");
            if ($.Box.SelectedID != 0) {
                $.Box.GetByID($.Box.SelectedID);
            }
        },
        GetByID: function (id) {
            $.ajax({
                url: '/Box/GetByID',
                type: 'GET',
                data: { ID: id },
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    $.Box.SelectedID = data.ID;
                    $('#Name').val(data.Name);
                    $('#BoxSize').val(data.BoxSize);
                    $('#BoxPlaceCount').val(data.BoxPlaceCount);
                    $('#Description').val(data.Description);
                    $('#DisplayOrder').val(data.DisplayOrder);
                },
                error: function () {
                    alert("Error");
                }
            });
        }
    }
    $.Box.init();
});
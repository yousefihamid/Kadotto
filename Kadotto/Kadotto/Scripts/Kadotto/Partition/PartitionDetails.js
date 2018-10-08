$(function () {
    $.Partition = {
        SelectedID: 0,
        init: function () {
            $(document).ready(function () {
                $('#info-form').validator().on('submit', function (e) {
                    if (e.isDefaultPrevented()) {
                        //alert('form is not valid');
                    }
                    else {
                        e.preventDefault();
                        var Partition = {
                            ID: $.Partition.SelectedID,
                            Title: $('#Title').val(),
                            PartitionSize: $('#PartitionSize').val()
                        };
                        $.ajax({
                            url: '/Partition/Save',
                            type: 'POST',
                            data: JSON.stringify(Partition),
                            contentType: 'application/json; charset=utf-8',
                            success: function (data) {
                                window.location.href = "/Partition/Index";
                            },
                            error: function () {
                                alert("Error");
                            }
                        });
                    }
                });
            });
            $.Partition.SelectedID = $.utility.getKey("ID");
            if ($.Partition.SelectedID != 0) {
                $.Partition.GetByID($.Partition.SelectedID);
            }
        },
        GetByID: function (id) {
            $.ajax({
                url: '/Partition/GetByID',
                type: 'GET',
                data: { ID: id },
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    $.Partition.SelectedID = data.ID;
                    $('#Title').val(data.Title);
                    $("#PartitionSize").val(data.PartitionSize);
                },
                error: function () {
                    alert("Error");
                }
            });
        }
    }
    $.Partition.init();
});
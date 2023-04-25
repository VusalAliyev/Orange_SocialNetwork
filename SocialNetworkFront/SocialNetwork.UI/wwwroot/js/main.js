$(document).ready(function () {
    $('#submitBtn').click(function () {
        $.ajax({
            url: 'textfile.txt',
            type: 'GET',
            dataType: 'text',
            success: function (data) {
                $('#textArea').val(data);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert('Error: ' + textStatus + ' - ' + errorThrown);
            }
        });
    });
});
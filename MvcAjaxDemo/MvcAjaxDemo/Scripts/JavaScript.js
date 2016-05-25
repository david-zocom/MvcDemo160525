$(document).ready(function () {
    $('#ajaxButton').on('click', function () {
        $('#ajaxResult').html('AJAX startar');

        $.ajax({
            url: '/Default/Api',
            dataType: 'json',
            data: {},
            success: function (data) {
                $('#ajaxResult').html('Det finns '
                    + data.Count + ' djur i databasen!');
            },
            error: function (jqXHR, statusText, errorThrown) {
                $('#ajaxResult').html('Ett fel inträffade: <br>'
                    + statusText);
            }
        });
    }); // ajaxButton on click

    $('#ajaxButtonCrossDomain').on('click', function () {
        $('#ajaxResultCrossDomain').html('AJAX startar');

        $.ajax({
            url: 'http://forverkliga.se/JavaScript/api/simple.php',
            dataType: 'jsonp',
            data: { key: 'key' },
            success: function (data) {
                $('#ajaxResultCrossDomain').html('Messelande: '
                    + data.message + '<br>Tid: ' + data.time);
            },
            error: function (jqXHR, statusText, errorThrown) {
                $('#ajaxResultCrossDomain').html('Ett fel inträffade: <br>'
                    + statusText);
            }
        });
    });
});
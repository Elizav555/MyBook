$(document).ready(function () {
    $('#containerProfile').show();
    $('#containerSubscr').hide();
    $('#containerHistory').hide();

    $('#subscr').click(function () {
        $('#containerProfile').hide();
        $('#containerSubscr').show();
        $('#containerHistory').hide();
        return false;
    });

    $('#profile').click(function () {
        $('#containerProfile').show();
        $('#containerSubscr').hide();
        $('#containerHistory').hide();
    });


    $('#history').click(function () {
        $('#containerProfile').hide();
        $('#containerSubscr').hide();
        $('#containerHistory').show();
    });
});
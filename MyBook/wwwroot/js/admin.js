$(document).ready(function () {
    $('#containerAuthor').show();
    $('#containerSubscription').hide();
    $('#containerBook').hide();
    $('#containerBookCenter').hide();
    $('#containerUser').hide();

    $('#book').click(function () {
        $('#containerAuthor').hide();
        $('#containerSubscription').hide();
        $('#containerBook').show();
        $('#containerBookCenter').hide();
        $('#containerUser').hide();
        return false;
    });

    $('#author').click(function () {
        $('#containerAuthor').show();
        $('#containerSubscription').hide();
        $('#containerBook').hide();
        $('#containerBookCenter').hide();
        $('#containerUser').hide();
        return false;
    });


    $('#subscr').click(function () {
        $('#containerAuthor').hide();
        $('#containerSubscription').show();
        $('#containerBook').hide();
        $('#containerBookCenter').hide();
        $('#containerUser').hide();
        return false;
    });


    $('#bookCenter').click(function () {
        $('#containerAuthor').hide();
        $('#containerSubscription').hide();
        $('#containerBook').hide();
        $('#containerBookCenter').show();
        $('#containerUser').hide();
        return false;
    });
});
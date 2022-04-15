$(document).ready(function () {
    $.post({
        url: "/AdminProfile/EditSubscription",
        success: function (result) {
            $('#container').html(result);
        }
    });

    $('#book').click(function () {
        $.post({
            url: "/AdminProfile/EditBook",
            success: function (result) {
                $('#container').html(result);
            }

        });
        return false;
    });

    $('#author').click(function () {
        $.post({
            url: "/AdminProfile/EditAuthor",
            success: function (result) {
                $('#container').html(result);
            }

        });
        return false;
    });


    $('#subscr').click(function () {
        $.post({
            url: "/AdminProfile/EditSubscription",
            success: function (result) {
                $('#container').html(result);
            }

        });
        return false;
    });


    $('#bookCenter').click(function () {
        $.post({
            url: "/AdminProfile/EditBookCenter",
            success: function (result) {
                $('#container').html(result);
            }

        });
        return false;
    });
});
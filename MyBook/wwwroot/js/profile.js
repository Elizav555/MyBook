$(document).ready(function () {
    $.get({
        url: "/UserProfile/EditProfile/" + $('#userId').val(),
        success: function (result) {
            $('#container').html(result);
        }
    });

    $('#subscr').click(function () {
        $.get({
            url: "/UserProfile/EditSubscription/" + $('#userId').val(),
            success: function (result) {
                $('#container').html(result);
            }

        });
        return false;
    });

    $('#profile').click(function () {
        $.get({
            url: "/UserProfile/EditProfile/" + $('#userId').val(),
            success: function (result) {
                $('#container').html(result);
            }

        });
        return false;
    });


    $('#history').click(function () {
        $.get({
            url: "/UserProfile/History/" + $('#userId').val(),
            success: function (result) {
                $('#container').html(result);
            }

        });
        return false;
    });
});
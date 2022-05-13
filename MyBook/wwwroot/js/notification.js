﻿$(document).ready(function () {
    var connection = new signalR.HubConnectionBuilder().withUrl("/NotificationHub").build();
    connection.on("sendToUser", (notificationHeading, notificationContent) => {
        $('.modal-title').html(notificationHeading);
        $('#modal-text').html(notificationContent);
        $('#modal').modal('show');
    });
    connection.start().catch(function (err) {
        return console.error(err.toString());
    });

    $('#notifyAll').click(function () {
        $.ajax({
            url: '/Home/NotifyAll',
            type: "GET",
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Error" + errorThrown)
            },
            success: function (data) {
                //Do nothing
            }
        });
    });
});
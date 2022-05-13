"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/NotificationHub").build();
connection.on("sendToUser", (notificationHeading, notificationContent) => {
    //var heading = document.createElement("h3");
    //heading.textContent = notificationHeading;

    //var p = document.createElement("p");
    //p.innerText = notificationContent;

    //var div = document.createElement("div");
    //div.appendChild(heading);
    //div.appendChild(p);

    //document.getElementById("notificationsList").appendChild(div);

    $('.modal-title').html(notificationHeading);
    $('.modal-text').html(notificationContent);
    $('#modal').modal('show');
});
connection.start().catch(function (err) {
    return console.error(err.toString());
});
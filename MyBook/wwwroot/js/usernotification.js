"use strict";
if (userId == null) {
    return;
}
var connection = new signalR.HubConnectionBuilder().withUrl("/NotificationUserHub?userId=" + userId).build();
connection.on("sendToUser", (notificationHeading, notificationContent) => {
    var heading = document.createElement("h3");
    heading.textContent = notificationHeading;

    var p = document.createElement("p");
    p.innerText = notificationContent;

    var div = document.createElement("div");
    div.appendChild(heading);
    div.appendChild(p);

    document.getElementById("notificationsList").appendChild(div);
});

connection.start().catch(function (err) {
    return console.error(err.toString());
}).then(function () {
    connection.invoke('GetConnectionId').then(function (connectionId) {
        document.getElementById('signalRConnectionId').innerHTML = connectionId;
    })
});
const chatHub = new signalR.HubConnectionBuilder()
    .withUrl('/notification')
    .build();

chatHub.on("UrgentNotification", function (urgentMessage) {
    alert(urgentMessage);
});

chatHub.start();

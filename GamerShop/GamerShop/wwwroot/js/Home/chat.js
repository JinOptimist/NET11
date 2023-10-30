$(document).ready(function () {
    const chatHub = new signalR.HubConnectionBuilder()
        .withUrl('/chat')
        .build();

    init();

    $('#newMessage').on("keyup", function (event) {
        if (event.which == 13) { // 13 == enter
            console.log('user press enter');
            addMessage();
            event.preventDefault();
        }
    });

    chatHub.on("SomeOneAddNewMessage", someOneAddMessageToChat);

    chatHub.start();

    function init() {
        $.get('/api/Chat/GetLastMessages')
            .done(function (chatMessages) {
                chatMessages.forEach(function (chatMesage) {
                    someOneAddMessageToChat(chatMesage.userName, chatMesage.message);
                });
            });
    }

    function someOneAddMessageToChat(userName, messageText) {
        const messageDiv = $(".message.template").clone();
        messageDiv.removeClass('template');
        messageDiv.find('.user-name').text(userName);
        messageDiv.find('.message-text').text(messageText);
        $('.messages').append(messageDiv);
    }

    function addMessage() {
        const message = $('#newMessage').val();

        chatHub.invoke('AddNewMessage', message);

        const userId = $('#UserId').val();
        const userName = $('#UserName').val();

        const url = 'https://localhost:7250/addMessage';
        const dateTimeNow = new Date().toISOString();
        const data = {
            "senderId": userId,
            "senderName": userName,
            "text": message,
            "createDateTime": dateTimeNow
        };

        var json = JSON.stringify(data);
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: url,
            data: json,
            dataType: "json"
        });

        $('#newMessage').val('');
    }
});
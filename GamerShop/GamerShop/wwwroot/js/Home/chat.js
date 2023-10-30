$(document).ready(function () {
    const chatHub = new signalR.HubConnectionBuilder()
        .withUrl('/chat')
        .build();

    init();

    $('#newMessage').on("keyup", function (event) {
        if (event.which == 13) { // 13 == enter
            console.log('user press enter');

            const message = $('#newMessage').val();
            chatHub.invoke('AddNewMessage', message);

            $('#newMessage').val('');

            event.preventDefault();
        }
    });

    chatHub.on("SomeOneAddNewMessage", addMessageToChat);

    chatHub.start();

    function init() {
        $.get('/api/Chat/GetLastMessages')
            .done(function (chatMessages) {
                chatMessages.forEach(function (chatMesage) {
                    addMessageToChat(chatMesage.userName, chatMesage.message);
                });
            });
    }

    function addMessageToChat(userName, messageText) {
        const messageDiv = $(".message.template").clone();
        messageDiv.removeClass('template');
        messageDiv.find('.user-name').text(userName);
        messageDiv.find('.message-text').text(messageText);
        $('.messages').append(messageDiv);
    }
});
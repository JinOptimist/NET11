$(document).ready(function () {
    $('#Login').on("focusout", function () {
        const currentUserLogin = $('#Login').val();

        $('.checkResult').text('???');
        $('.checkResult').removeClass('error');
        $('.checkResult').removeClass('free');
        $('.checkResult').addClass('waiting');

        const url = '/api/user/isExistUsername?name=' + currentUserLogin;
        $.get(url)
            .done(function (answer) {
                $('.checkResult').removeClass('waiting');
                if (answer) {
                    $('.checkResult').text('Имя уже занято');
                    $('.checkResult').addClass('error');
                } else {
                    $('.checkResult').text('Имя свободно');
                    $('.checkResult').addClass('free');
                }
            });
    });
});
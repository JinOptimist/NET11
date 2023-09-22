$(document).ready(function () {
    $(".content").click(function () {
        $(this).animate({ left: '100px' }, "slow");
        $(this).animate({ fontSize: '3em' }, "slow");
    });

});


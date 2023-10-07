$(document).ready(function () {
    const popoverTriggerList = document.querySelectorAll('[data-bs-toggle="popover"]')
    const popoverList = [...popoverTriggerList].map(popoverTriggerEl => new bootstrap.Popover(popoverTriggerEl))

    $('.shows div:eq(0)').animate({ opacity: 1 }, 200, function () {
        $(this).next().animate({ opacity: 1 }, 200, arguments.callee);//с использованием ссылки на функцию-родитель arguments.callee.
    });
});


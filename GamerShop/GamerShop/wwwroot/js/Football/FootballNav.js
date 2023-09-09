$(document).ready(function () {
    let currentPath = window.location.pathname;
    $('header').find('li').each(function () {
        let path = $('a', this).attr('href').indexOf(currentPath) >= 0
        if (path) {
            $('span', this).addClass('active-page');
            return false;
        }
    })
    const popoverTriggerList = document.querySelectorAll('[data-bs-toggle="popover"]')
    const popoverList = [...popoverTriggerList].map(popoverTriggerEl => new bootstrap.Popover(popoverTriggerEl))

    $('.shows div:eq(0)').animate({ opacity: 1 }, 200, function () {
        $(this).next().animate({ opacity: 1 }, 200, arguments.callee);//с использованием ссылки на функцию-родитель arguments.callee.
    });
});


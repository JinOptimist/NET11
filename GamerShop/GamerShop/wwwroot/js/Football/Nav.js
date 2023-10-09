$(document).ready(function () {
    let currentPath = window.location.pathname;
    $('header').find('li').each(function () {
        let path = $('a', this).attr('href').indexOf(currentPath) >= 0
        if (path) {
            $('span', this).addClass('active-page');
            return false;
        }
    })
});


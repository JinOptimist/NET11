$(document).ready(function () {
    $('header').find('li').each(function () {
        let currentSection = location.pathname == $('a', this).attr('href');
        console.log(currentSection);
        if(currentSection){
            $('span', this).addClass('active-color');
        }
    })
    console.log(location.pathname);
});

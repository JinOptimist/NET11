$(document).ready(function () {
    $('.user-row .symbol').click(function () {
        if ($(this).text() == '+') {
            $(this).text('-');
        } else {
            $(this).text('+');
        }
        
        $(this).toggleClass('blue');

        $(this)
            .closest('.user-row') // parent
            .find('.movie-info')
            .toggle(); // child
    });

    $('.search-button').click();

    $('.search-text').on("keyup", runSearch);

    function runSearch() {
        const userSearchText = $('.search-text').val();
        $('.user-row .name')
            .each(function () {
                const row = $(this)
                    .closest('.user-row');
                if ($(this).text().indexOf(userSearchText) < 0) {
                    row.css('opacity', '0.5');
                } else {
                    row.css('opacity', '1');
                }
            })
    }
});


//let user = {};
//user.age = 123;
//user.name = 'Jon';

//if (user) {
//    console('+');
//} else {
//    console('-');
//}

//let numberStr = '123';
//numberStr + 1

//const test = '123';
//test = '1';

//function todoV1(a, b) {
//    return (a + b) * 2;
//}

//let answer = todoV1(1, 4);

//let todoV2 = function (a, b) {
//    return (a + b) * 2;
//}
//let answer2 = todoV2(1, 4);

//function sort(list, funcLyamda) {
//    //for....
//    //func(user);
//}

//sort([1, 2, 3], (x) => x.Id);
//sort([1, 2, 3], function (user) { return user.Id });

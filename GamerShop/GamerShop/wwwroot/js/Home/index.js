$(document).ready(function () {
    $('.user-row .symbol').click(onSymbolClick);

    $('.search-text').on("focusout", runSearch);

    function runSearch() {
        const userSearchText = $('.search-text').val();

        const url = '/api/home/getUsers?search=' + userSearchText;
        $.get(url)
            .done(function(users){
                $('.users').empty();
                
                users.forEach(user => {
                    const newUserRowTag = $('.user-row.template').clone();
                    newUserRowTag.removeClass('template');
                    newUserRowTag.find('.name').text(user.name);
                    newUserRowTag.find('.favorite-movie-name').text(user.favoriteMovieName);
                    newUserRowTag.find('.symbol').click(onSymbolClick);
                    $('.users').append(newUserRowTag);
                });
            });
    }

    function onSymbolClick() {
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
    }
});

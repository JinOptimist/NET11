$(document).ready(function () {
    const count = 2;
    const countUrl = '/api/FootballLeagues/Count';
    let maxPossibleСount;

    $.get(countUrl)
        .done(function (answer) {
            maxPossibleСount = answer;
        })

    $('.more').on('click', function () {
        if (typeof maxPossibleСount === "undefined") { return false }
        let skip = GetCountOption();
        PasteOptions(skip, count);
        $('.selectpicker').trigger('change');
        $('.selectpicker').focus();
        HideMore(skip + count);
    })

    $(".more").on('mousedown', function () {
        return false;
    });

    function HideMore(resultCount) {
        
        if (maxPossibleСount > resultCount) { return false } 
        $('.more').css('display', 'none');
    }


    function PasteOptions(skip, count) {

        return $.get('/api/FootballLeagues/get?skip=' + skip + '&count=' + count).
            done(function (answer) {
                $.each(answer, function () {
                    $('.selectpicker').append(`<option value="${this.id}">${this.shortName}</option>`);
                });
                $('.selectpicker').append($('.more'));

            });

    }

    function GetCountOption() {

        return $(".selectpicker").children().length - 1;///-1-Item'.More'
    }
});
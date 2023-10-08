$(document).ready(function () {
    $(".flex-container .title").click(descriptionHide);

});


function animate() {
    $(this).animate({ left: '100px' }, "slow");
    $(this).animate({ fontSize: '3em' }, "slow");
}

function descriptionHide() {

    $(this)
        .closest('.flex-container')
        .find('.description')
        .toggle();
}


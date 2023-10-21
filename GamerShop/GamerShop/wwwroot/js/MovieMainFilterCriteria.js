$(document).ready(function () {
    function updateMovieCollectionList(filterValue) {
        $.ajax({
            url: '/MovieMain/UpdateMovieCollectionList',
            type: 'GET',
            data: { filterCriteria: filterValue },
            success: function (data) {
                $('#movieCollectionList').html(data);
            },
            error: function (error) {
                console.error(error);
            }
        });
    }

    updateMovieCollectionList($('#filterCriteria').val());

    $('#filterCriteria').change(function () {
        const selectedValue = $(this).val();
        updateMovieCollectionList(selectedValue);
    });
});

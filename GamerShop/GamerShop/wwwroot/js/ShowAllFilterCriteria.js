$(document).ready(function () {

    function updateSortedData(sortingCriteria, isAscending) {
        $.ajax({
            url: '/MovieCollection/UpdateShowAll',
            type: 'GET',
            data: { sortingCriteria: sortingCriteria, isAscending: isAscending },
            success: function (data) {
                $('#showAllContainer').html(data);
            },
            error: function (error) {
                console.error(error);
            }
        });
    }

    $('#sorterCriteria, #sorterDirection').change(function () {
        const selectedSortingCriteria = $('#sorterCriteria').val();
        const selectedIsAscending = $('#sorterDirection').val();
        updateSortedData(selectedSortingCriteria, selectedIsAscending);
    });


});

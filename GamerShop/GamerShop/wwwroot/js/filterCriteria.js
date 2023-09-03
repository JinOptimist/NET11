document.addEventListener('DOMContentLoaded', function () {
    const urlParams = new URLSearchParams(window.location.search);
    const filterCriteria = urlParams.get('filterCriteria');

    if (filterCriteria) {
        const selectElement = document.getElementById('filterCriteria');
        selectElement.value = filterCriteria;
    }
});

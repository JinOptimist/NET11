$(document).ready(function () {
    const popoverTriggerList = document.querySelectorAll('[data-bs-toggle="popover"]')
    const popoverList = [...popoverTriggerList].map(popoverTriggerEl => new bootstrap.Popover(popoverTriggerEl))

    $('.shows div:eq(0)').animate({ opacity: 1 }, 200, function () {
        $(this).next().animate({ opacity: 1 }, 200, arguments.callee);//с использованием ссылки на функцию-родитель arguments.callee.
    });
    $('#accept').click(function () {
        $('#exampleModal').modal('toggle');
        let count = CountChecked(document.querySelectorAll('.form-check-input'));
        $('#filter').text((count == 0) ? 'Установить фильтр' : 'Фильтров ' + count);

    });

    function CountChecked(elemtsArray) {

        let count = 0;

        for (var i = 0; i < elemtsArray.length; i++) {

            if (elemtsArray[i].checked) {
                count++;
            }
        }
        return count
    }
});


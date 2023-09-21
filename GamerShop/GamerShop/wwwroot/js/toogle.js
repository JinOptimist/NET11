document.addEventListener('DOMContentLoaded', function () {
    const toggle = document.getElementById('toggle');
    const toggleText = document.querySelector('.toggle-text');

    toggle.addEventListener('change', function () {
        if (toggle.checked) {
            toggleText.textContent = toggleText.getAttribute('data-on');
        } else {
            toggleText.textContent = toggleText.getAttribute('data-off');
        }
    });
});

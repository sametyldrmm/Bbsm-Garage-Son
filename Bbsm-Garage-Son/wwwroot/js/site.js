// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.querySelectorAll('.checkbox').forEach(function (checkbox) {
    checkbox.addEventListener('change', function () {
        var hiddenInput = checkbox.nextElementSibling;
        if (checkbox.checked) {
            hiddenInput.value = checkbox.getAttribute('data-id');
        } else {
            hiddenInput.value = '';
        }
    });
});


// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


const phone = {
    mask: '+000 000-000000'
};

document.querySelectorAll('.mask-phone').forEach(c => IMask(c, phone))
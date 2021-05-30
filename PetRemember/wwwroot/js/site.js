// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $("#logintab").click(function() {
        $("#registerform").hide();
        $("#loginform").show();
        $("#registertab").removeClass("activo");
        $(this).addClass("activo");
    });
    $("#registertab").click(function() {
        $("#loginform").hide();
        $("#registerform").show();
        $("#logintab").removeClass("activo");
        $(this).addClass("activo");
    });
});
// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $(window).on('scroll', function () {
        if ($(this).scrollTop() > 80) {
            $('header').addClass("sticky");
        }
        else {
            $('header').removeClass("sticky");
        }
    })
})

//var parallax = $('.parallax');
//var scrollposition = $(this).scrollTop();
//parallax.css("transform", "translateY(" + scrollposition * 0.5 + "px" + ")");
'use strict';

$(document).ready(function () {

    $('.resume_submit').on('click', function () {
        $('.review__pop-up').show();
    });

    $('.review__pop-up_close, .review__pop-up_button-cancel ').on('click', function () {
        $('.review__pop-up').hide();
    })

    //$('.review__pop-up_button-submit').on('click', function () {
    //    window.location.href='/Home/Index';
    //});
});
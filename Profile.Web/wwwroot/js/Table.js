'use strict';

$(document).ready(function (event) {

    $('.table__checkbox_button').on('click', function () {
        $('.table__button_dropdown').show();
    });

    $(document).click(function (event) {
        $(event.target).attr('class') === 'table__button_list' ? $('.table__button_dropdown').show() : $('.table__button_dropdown').hide();
    });

    $('.table__show_all').on('click', function () {
        $('.table__button_list').each(function () {

            if (!$(this).prop('checked')) {
                $(this).click();
            }
        });
    });
});
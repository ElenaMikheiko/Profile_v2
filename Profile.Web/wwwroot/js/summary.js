'use strict';

///////////////////CONST
const REGEXP_FOR_NAME = /[^a-zA-Z.]/gi,
    VALIDATE_PATTERN = /[^a-z0-9"№%*_ =+@#$^&.,:;()!?`-]/ig,
    REGEXP_PERSONAL = /[^a-z.`-]/ig,
    TEXTAREA_MAX_LENGTH = 1000,
    INPUT_MAX_LENGTH = 100,
    PHONE_INPUT_LENGTH = 19,
    PHONE_INPUT_MASK = '+375 (99) 999-99-99',
    TAB_LENGTH = 12,
    FORM_MAX_LENGTH = 5,
    FORM_MIN_LENGTH = 2,
    MIN_ELEMENTS = 1,
    ERROR_MESSAGE = $('<div class="error__message">Empty field.</div>'),
    MAX_LINK_COUNT = 10;

//////////////Allow symbols
function allowedSymbols() {
    let amount = $(this).val();

    $(this).val(amount.replace(VALIDATE_PATTERN, ''));
};

//////////////Check for future year
function checkForFuture() {
    let thisYear = new Date();

    $(this).each(function () {
        if ($('option:selected', this).val() > thisYear.getFullYear()) {
            $(this).addClass('error');
        } else {
            $(this).removeClass('error');
        }
    });
};

function symbolCounter() {
    let maxLength = $(this).data('counter'),
        textLength = $(this).val().length;

    if (textLength > maxLength) {
        $(this).addClass('error');
        $(this).next()
            .html(maxLength - textLength + '/' + maxLength)
            .removeClass('count_grey')
            .addClass('count_red');
    } else {
        $(this).removeClass('error');
        $(this).next()
            .html(maxLength - textLength + '/' + maxLength)
            .removeClass('count_red')
            .addClass('count_grey');
    }
};

function changeTab() {
    $('.nav-pills > .active').next('a')
        .removeClass('disabled')
        .trigger('click');
    $('.nav-pills > .active').prev('a')
        .addClass('passed disabled')
        .removeClass('notpassed');
};

///////////////Add index to input for BE
function addUniqName() {
    let newArray = $(this).attr('name').replace(REGEXP_FOR_NAME, '').split('.');

    for (let i = 0; i < $(this).length; i++) {
        let attrName = newArray[0] + '[' + i + ']';

        for (let j = 1; j < newArray.length; j++) {
            attrName += '.' + newArray[j];
        }

        $(this).eq(i).attr('name', attrName);
    }
};

/////////////Reset blocks
function resetBlock() {
    $(this)
        .find('input').val('')
        .end()
        .find('.count_message').html(INPUT_MAX_LENGTH + '/' + INPUT_MAX_LENGTH).removeClass('count_red')
        .end()
        .find('select').val('0')
        .end()
        .find('.error').removeClass('error');
};

////////////Check last completed tab
function openLastTab() {
    $('.messageBox').show();
    let lastTab = +$('.current__tab').val(),
        tab = $('.nav-link'),
        contentDisplay = $('.tab-pane');

    if (lastTab >= MIN_ELEMENTS && lastTab <= TAB_LENGTH) {
        $('.messageBox').hide();
        $('#resumeFormContainer').show();
        tab.eq(lastTab)
            .removeClass('notpassed disabled')
            .addClass('active');

        tab.eq(0)
            .removeClass('active')
            .addClass('notpassed disabled');

        contentDisplay.eq(lastTab)
            .removeClass('fade')
            .addClass('active show');

        contentDisplay.eq(0)
            .removeClass('active show')
            .addClass('fade');

        for (let i = 0; i < lastTab; i++) {
            tab.eq(i)
                .removeClass('notpassed')
                .addClass('passed');
        }
    }
};

$(document).ready(function () {

    openLastTab();

    /////////////Phone Mask
    $("#phone").inputmask(PHONE_INPUT_MASK);

    //////////Impement skills plugin
    $('.tab__skills_select').select2({
        tags: true,
        tokenSeparators: [',']
    });

    /////////////Clone Check
    $('.tab-pane').each(function () {
        if ($('.tab__remove_common', this).length > MIN_ELEMENTS) {
            $('.tab__remove_common', this).show();
        }
    });

    if ($('.tab__certificate_form').length > MIN_ELEMENTS) {
        $('.tab__remove_certificate').show();
    }

    if ($('.tab__test_form').length > MIN_ELEMENTS) {
        $('.tab__remove_test').show();
    }

    /////////////Checkbox check
    $('.tab__work_clone').each(function () {

        if ($('.work_checkbox', this).prop('checked')) {
            $('._work_end-year', this).prop('disabled', true);
            $('._work_end-month', this).prop('disabled', true);
        } else {
            $('._work_end-year', this).prop('disabled', false);
            $('._work_end-month', this).prop('disabled', false)
        }
    });

    ////////////////Count symbols after loading
    $('input[data-counter], textarea[data-counter]').each(function () {
        let maxLength = $(this).data('counter');

        $(this).next().html(maxLength - $(this).val().length + '/' + maxLength);
    });

    //////////////Symbol counter
    $('.content__tabs').on('input', 'input, textarea', symbolCounter);

    ///////////////Change tab
    $('.next_step').on('click', changeTab);

    $('.controls_back').on('click', function () {
        $('.nav-pills > .active').prev('a')
            .removeClass('disabled')
            .trigger('click');
        $('.nav-pills > .active').next('a')
            .removeClass('passed')
            .addClass('notpassed disabled');
    });

    //////////Complete Message
    $('.complete_back').on('click', function () {
        $('.messageBox__complete').hide();
        $('.content__tabs').show();
    });

    ///////Textarea Validation
    $('input, textarea').on('input', allowedSymbols);

    /////////////////Check select
    $('select').on('click', function () {
        $(this).each(function () {
            if ($('option:selected', this).val() !== '0') {
                $(this).removeClass('error');
            }
        });
    });

    $('.controls_next-start').on('click', function () {
        $('.messageBox').hide();
        $('#resumeFormContainer').show();
    });

    $('.personal_back').on('click', function () {
        $('#resumeFormContainer').hide();
        $('.messageBox').show();
    });

    //////////Personal info
    $('.tab__info_name, .tab__info_phone').off('input');

    $('.tab__info_name').each(function () {
        $(this).on('input', function () {
            $(this).val($(this).val().replace(REGEXP_PERSONAL, ''));
        });
    });

    $('.tab__info_phone').on('input', function () {
        $(this).removeClass('error');
    });

    $('.personal_next').on('click', function () {
        let phoneValidate = $('.tab__info_phone').val().replace(/_/g, '').length;

        $('.tab__info_name').each(function () {
            if (!$(this).val().length) {
                $(this).addClass('error');
            }
        });

        if (phoneValidate !== PHONE_INPUT_LENGTH) {
            $('.tab__info_phone').addClass('error');
        } else {
            $('.tab__info_phone').removeClass('error');
        }

        if (!$('.tab__personal input').hasClass('error')) {
            changeTab();
        }
    });

    //////Objective
    $('.objective_next').on('click', function (e) {
        let objectiveDropdown = $('.tab__objective_dropdown');

        if (objectiveDropdown.prop('value') === '0') {
            objectiveDropdown.addClass('error');
        } else {
            objectiveDropdown.removeClass('error');
        }

        if (!objectiveDropdown.hasClass('error')) {
            changeTab();
        } else {
            e.preventDefault();
        }
    });

    //////Summary
    $('.summary_next').on('click', function (e) {
        let summaryTextarea = $('.tab__summary_textarea'),
            errorMessage = $('.error__message');

        if (!summaryTextarea.val().length) {
            summaryTextarea.addClass('error');
            errorMessage.remove();
            summaryTextarea.before(ERROR_MESSAGE);
        } else if (summaryTextarea.val().length > TEXTAREA_MAX_LENGTH) {
            summaryTextarea.addClass('error');
        } else {
            summaryTextarea.removeClass('error');
            errorMessage.remove();
        }

        if (!$('.tab__summary textarea').hasClass('error')) {
            changeTab();
        } else {
            e.preventDefault();
        }
    });

    /////////Skills
    $('.tab__skills_select + span').on('input click', function () {
        $(this).removeClass('error');
    });

    $('.skill_next').on('click', function (e) {
        if (!$('.tab__skills_select').val().length) {
            $('.tab__skills_select + span').addClass('error');
        } else {
            $('.tab__skills_select + span').removeClass('error');
        }

        if (!$('.tab__skills_input span').hasClass('error')) {
            changeTab();
        } else {
            e.preventDefault();
        }
    });

    /////////Language
    $('.clone').on('click', function (e) {
        let cloneLang = $('.tab__languages_dropdown:first').clone(true);
        let cloneLevel = $('.tab__languages_level:first').clone(true);

        cloneLang.appendTo('.tab__languages_form')
        cloneLevel
            .find('.tab__languages_level').attr('option:selected', this).val('0')
            .removeClass('error')
            .end()
            .appendTo('.tab__languages_form');

        if ($('.tab__languages_dropdown').length === FORM_MAX_LENGTH) {
            $('.clone').hide();
        }

        if ($('.tab__languages_dropdown').length) {
            $('.tab__remove').show();
            $('.tab__level').removeClass('error');
            $('.tab__languages_dropdown').removeClass('error');
        } else {
            $('.tab__remove').hide();
        }
    });

    $('.tab__remove').click(function () {
        if ($('.tab__languages_dropdown').length === FORM_MIN_LENGTH) {
            $('.tab__remove').hide();
        }

        $(this).parent()
            .prev('.tab__languages_dropdown').remove()
            .end()
            .remove();

        if ($('.tab__languages_dropdown').length < FORM_MAX_LENGTH) {
            $('.tab__add').show();
        }
    });

    $('.language__next').on('click', function (e) {
        let $elements = $('.tab__languages_dropdown');

        $elements
            .removeClass('error')
            .each(function () {
                let selectedValue = this.value;
                $elements
                    .not(this)
                    .filter(function () {
                        return this.value === selectedValue;
                    })
                    .addClass('error');
            });

        $('.tab__languages_level select').each(function () {
            if ($('option:selected', this).prop('value') === 'none' || $('option:selected', this).prop('value') === '0') {
                $(this).addClass('error');
            } else {
                $(this).removeClass('error');
            }
        });

        if (!$('.tab__languages_content select').hasClass('error')) {
            $('._ulanguages').each(function () {
                let $this = $(this);
                let currentLanguageId = $this.val();

                if (currentLanguageId !== '' && currentLanguageId !== 0) {
                    let $levelDropDown = $this.next('.tab__languages_level').find('._langlevel'),
                        currentName = $levelDropDown.attr('name'),
                        newName = currentName.replace(/\[\d+\]/g, '[' + currentLanguageId + ']');

                    $levelDropDown.attr('name', newName);
                }
            });
            changeTab();
        } else {
            e.preventDefault();
        }
    });

    /////////////Education
    $('.education_add').on('click', function () {
        let educationClone = $('.tab__education_form:first').clone(true);

        educationClone
            .find('input').val('')
            .end()
            .find('.education_dropdown').attr('option:selected', this).val('0')
            .end()
            .find('.count_message').html(INPUT_MAX_LENGTH + '/' + INPUT_MAX_LENGTH).removeClass('count_red')
            .end()
            .appendTo('.tab__clone');
        $('.tab__remove_education').show();
        educationClone.find('.error').removeClass('error');
    });

    $('.tab__remove_education').on('click', function () {
        if ($('.tab__remove_education').length === FORM_MIN_LENGTH) {
            $('.tab__remove_education').hide();
        }

        $(this).parent().remove();
    });

    $('.education_next').on('click', function (e) {
        $('.tab__education_dropdown').each(function () {
            if ($('option:selected', this).val() === '0' || $('._uadmission', this).val() > $('._ugraduation', this).val()) {
                $('select', this).addClass('error');
            } else {
                $('select', this).removeClass('error');
                checkForFuture.bind($('._uadmission'))();
            }
        });

        $('.education_input').each(function () {
            if (!$(this).val().length || $(this).val().length > $(this).data('counter')) {
                $(this).addClass('error');
            } else {
                $(this).removeClass('error');
            }
        });

        if (!$('.tab__education input, .tab__education select').hasClass('error')) {
            addUniqName.bind($('._uinstitute'))();
            addUniqName.bind($('._udepartment'))();
            addUniqName.bind($('._uspecialization'))();
            addUniqName.bind($('._uadmission'))();
            addUniqName.bind($('._ugraduation'))();
            addUniqName.bind($('._ueducationlevel'))();
            changeTab();
        } else {
            e.preventDefault();
        }
    });

    /////////////////Develop
    $('.develop_add').on('click', function () {
        let developClone = $('.tab__develop_clone :first').clone(true);

        resetBlock.bind(developClone)();
        developClone.appendTo('.tab__develop_clone');
        $('.tab__remove_develop').show();
    });

    $('.tab__remove_develop').on('click', function () {
        if ($('.tab__remove_develop').length === FORM_MIN_LENGTH) {
            $('.tab__remove_develop').hide();
        }

        $(this).parent().remove();
    });

    $('.develop_next').on('click', function () {
        if (!$('.tab__develop_clone input, .tab__develop_clone select').hasClass('error')) {
            addUniqName.bind($('._udev-organization'))();
            addUniqName.bind($('._udev-specialization'))();
            addUniqName.bind($('.tab__develop_dropdown'))();
            changeTab();
        }
    });

    ///////////////////Certificates
    $('.certificate_add').on('click', function () {
        let certificateClone = $('.tab__certificate_form:first').clone(true);

        resetBlock.bind(certificateClone)();
        $('.tab__certificate_clone').append(certificateClone);
        $('.tab__remove_certificate').show();
    });

    $('.tab__remove_certificate').on('click', function () {
        $(this).parent().remove();

        if ($('.tab__remove_certificate').length === MIN_ELEMENTS) {
            $('.tab__remove_certificate').hide();
        }
    });

    $('.test_add').on('click', function () {
        let testClone = $('.tab__test_form:first').clone(true);

        resetBlock.bind(testClone)();
        $('.tab__test_clone').append(testClone);
        $('.tab__remove_test').show();
    });

    $('.tab__remove_test').on('click', function () {
        $(this).parent().remove();

        if ($('.tab__remove_test').length === MIN_ELEMENTS) {
            $('.tab__remove_test').hide();
        }
    });

    $('.certificate_next').on('click', function (e) {
        $('.tab__certificate input').each(function () {
            if ($(this).val().length > INPUT_MAX_LENGTH) {

                $(this).addClass('error');
            } else {
                $(this).removeClass('error');
            }
        });

        if (!$('.tab__certificate input, .tab__certificate select').hasClass('error')) {
            addUniqName.bind($('._ucertificate-organization'))();
            addUniqName.bind($('._ucertificate-title'))();
            addUniqName.bind($('._ucertificate-attestation'))();
            addUniqName.bind($('._ucertificate-input'))();
            addUniqName.bind($('._utest-organization'))();
            addUniqName.bind($('._utest-title'))();
            addUniqName.bind($('._utest-attestation'))();
            changeTab();
        } else {
            e.preventDefault();
        }
    });

    ////////////////Work
    $('.add_work').on('click', function () {
        let workClone = $('.tab__work_clone:first').clone(true);

        workClone.find('input').val('');
        workClone.find('.tab__work_dropdown').attr('option:selected', this).val('0');
        workClone.find('textarea').val('');
        workClone.find('.tab__work_finish').show();
        workClone.find('.count_textarea-work').html(TEXTAREA_MAX_LENGTH + ' / ' + TEXTAREA_MAX_LENGTH);
        workClone.find('.error').removeClass('error');
        workClone.find('.end__work').prop('disabled', false);
        workClone.find('.count_message').html(INPUT_MAX_LENGTH + '/' + INPUT_MAX_LENGTH);
        workClone.find('.count_message').removeClass('count_red');
        workClone.find('.work_checkbox').prop('checked', false);
        $(workClone).appendTo('.tab__work_form');
        $('.tab__remove_work').show();
    });

    $('.work_checkbox').on('click', function () {
        let endOfWork = $(this).closest('.tab__work_clone').find('.end__work');

        if ($(this).prop('checked')) {
            endOfWork.prop('disabled', true);
            $(this).closest('.tab__work_clone').find('.tab__work_dropdown').removeClass('error');
        } else {
            endOfWork.prop('disabled', false);
        }
    });

    $('.tab__remove_work').on('click', function () {
        $(this).parent().remove();

        if ($('.tab__remove_work').length === MIN_ELEMENTS) {
            $('.tab__remove_work').hide();
        }
    });

    $('.work_next').on('click', function (e) {
        $('.tab__work_dropdown').each(function () {
            if ($('option:selected', this).val() === '0') {
                $(this).addClass('error');
            } else {
                $(this).removeClass('error');
            }
        });

        $('.tab__work_form textarea').each(function () {
            if (!$(this).val().length || $(this).val().length > TEXTAREA_MAX_LENGTH) {
                $(this).addClass('error');
            } else {
                $(this).removeClass('error');
            }
        });

        let startWorkYear = $('._work_start-year', this).val(),
            startWorkMonth = $('._work_start-month', this).val(),
            endWorkYear = $('._work_end-year', this).val(),
            endWorkMonth = $('._work_end-month', this).val();

        $('.work_checkbox').each(function () {
            if (!$(this).prop('checked')) {
                if (+endWorkYear < +startWorkYear) {
                    $(this).closest('.tab__work_clone').find('.tab__work_dropdown').addClass('error');
                }

                if (+endWorkYear === +startWorkYear && +endWorkMonth < +startWorkMonth) {
                    $(this).closest('.tab__work_clone').find('.tab__work_dropdown').addClass('error');
                }
            }
        });

        $('.tab__work_input').each(function () {
            if (!$(this).val().length) {
                $(this).addClass('error');
            } else {
                $(this).removeClass('error');
            }
        });

        $('.tab__work_form').each(function () {
            if ($('input', this).prop('checked')) {
                $(this).find('.end__work').removeClass('error');
            }
        });

        if (!$('.tab__work input, .tab__work select, .tab__work textarea').hasClass('error')) {
            addUniqName.bind($('._work_start-year'))();
            addUniqName.bind($('._work_start-month'))();
            addUniqName.bind($('._work_present'))();
            addUniqName.bind($('._work_end-year'))();
            addUniqName.bind($('._work_end-month'))();
            addUniqName.bind($('._work-organization'))();
            addUniqName.bind($('._work-position'))();
            addUniqName.bind($('._work-respons'))();
            changeTab();
        } else {
            e.preventDefault();
        }
    });

    ////////////////Portfolio
    $('.tab__portfolio_add').on('click', function () {
        let portfolioClone = $('.tab__portfolio_form:first').clone(true);

        $('.tab__portfolio').append(portfolioClone);
        portfolioClone.find('input').val('');
        $('.tab__remove_portfolio').show();

        if ($('.tab__portfolio_add').length >= MAX_LINK_COUNT) {
            $('.tab__portfolio_add').hide();
        }
    });

    $('.tab__remove_portfolio').on('click', function (e) {
        $(this).parent().remove();

        if ($('.tab__portfolio_add').length < MAX_LINK_COUNT) {
            $('.tab__portfolio_add').show();
        }

        if ($('.tab__remove_portfolio').length < FORM_MIN_LENGTH) {
            $('.tab__remove_portfolio').hide();
        }
    });

    $('.portfolio_next').on('click', function () {
        if (!$('.tab__portfolio input').hasClass('error')) {
            addUniqName.bind($('.tab__portfolio_link'))();
            changeTab();
        }
    });

    //////////////Additional
    $('.info__next').on('click', function () {
        if (!$('.tab__additional textarea').hasClass('error')) {
            changeTab();
        }
    });

    ////////////////Recommendations
    $('.tab__recommend_add').on('click', function () {
        let contactClone = $('.tab__recommend_form:first').clone(true);

        $('.tab__recommend_remove').show();
        contactClone
            .find('input').val('').removeClass('error')
            .end()
            .find('textarea').val('').removeClass('error')
            .end()
            .find('.count_message').html(INPUT_MAX_LENGTH + '/' + INPUT_MAX_LENGTH).removeClass('count_red').addClass('count_grey');
        $('.tab__recommend_block').append(contactClone);

        if ($('.tab__recommend_form').length >= FORM_MAX_LENGTH) {
            $('.tab__recommend_add').hide();
        }
    });

    $('.tab__recommend_remove').on('click', function () {
        $(this).parents('.tab__recommend_form').remove();
        $('.tab__recommend_add').show();

        if ($('.tab__recommend_remove').length < MIN_ELEMENTS) {
            $('.tab__recommend_remove').hide();
        }
    });

    $('.recommends__next').on('click', function (e) {
        let recommendInput = $('.tab__recommend_form .form-control');

        recommendInput.removeClass('error');
        recommendInput.each(function () {
            if ($(this).val().length) {
                recommendInput.not(function () {
                    if (!$(this).val().length) {
                        $(this).addClass('error');
                    }
                });
                $(this).removeClass('error');
            }
        });

        if (!$('.tab__recommend_form .form-control').hasClass('error')) {
            addUniqName.bind($('._urecommend-name'))();
            addUniqName.bind($('._urecommend-position'))();
            addUniqName.bind($('._urecommend-organization'))();
            $('.content__tabs').hide();
            $('.messageBox__complete').show();
        } else {
            e.preventDefault();
        }
    });
});

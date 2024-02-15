/*global $, document, window, setTimeout, navigator, console, location*/
$(document).ready(function () {

    'use strict';

    //var usernameError = true,
    //    emailError = true,
    //    passwordError = true,
    //    passConfirm = true;


    var appfirstnameError = true,
        applastnameError = true,
        appemailError = true,
        appuserphoneError = true,
        apppasswordError = true,
        apppassConfirm = true,

    // Detect browser for css purpose
    if (navigator.userAgent.toLowerCase().indexOf('firefox') > -1) {
        $('.form form label').addClass('fontSwitch');
    }

    // Label effect
    $('input').focus(function () {

        $(this).siblings('label').addClass('active');
    });

    // Form validation
    $('input').blur(function () {

        // First Name
        if ($('.appfirstname').hasClass('appfirstname')) {
            if ($(this).val().length === 0) {
                $(this).siblings('span.error').text('Please Enter Your First Name').fadeIn().parent('.form-group').addClass('hasError');
                appfirstnameError = true;
            } else if ($(this).val().length > 1 && $(this).val().length <= 3) {
                $(this).siblings('span.error').text('First Name Must be at least 3 Characters').fadeIn().parent('.form-group').addClass('hasError');
                appfirstnameError = true;
            } else {
                $(this).siblings('.error').text('').fadeOut().parent('.form-group').removeClass('hasError');
                appfirstnameError = false;
            }
        }
        // Last Name
        if ($(this).hasClass('applastname')) {
            if ($(this).val().length === 0) {
                $(this).siblings('span.error').text('Please Enter Your Last Name').fadeIn().parent('.form-group').addClass('hasError');
                applastnameError = true;
            } else if ($(this).val().length > 1 && $(this).val().length <= 3) {
                $(this).siblings('span.error').text('Last Name Must at least 3 characters').fadeIn().parent('.form-group').addClass('hasError');
                applastnameError = true;
            } else {
                $(this).siblings('.error').text('').fadeOut().parent('.form-group').removeClass('hasError');
                applastnameError = false;
            }
        }
        // Email
        if ($(this).hasClass('appemail')) {
            if ($(this).val().length == '') {
                $(this).siblings('span.error').text('Please Enter Your Email address').fadeIn().parent('.form-group').addClass('hasError');
                appemailError = true;
            } else {
                $(this).siblings('.error').text('').fadeOut().parent('.form-group').removeClass('hasError');
                appemailError = false;
            }
        }

        // User Phone
        if ($(this).hasClass('appuserphone')) {
            if ($(this).val().length === 0) {
                $(this).siblings('span.error').text('Please Enter Your Phone Number').fadeIn().parent('.form-group').addClass('hasError');
                appuserphoneError = true;
            } else if ($(this).val().length > 1 && $(this).val().length <= 10) {
                $(this).siblings('span.error').text('Phone Number Must be at least 10 Digit').fadeIn().parent('.form-group').addClass('hasError');
                appfirstnameError = true;
            } else {
                $(this).siblings('.error').text('').fadeOut().parent('.form-group').removeClass('hasError');
                appuserphoneError = false;
            }
        }

        // PassWord
        if ($(this).hasClass('apppass')) {
            if ($(this).val().length < 6) {
                $(this).siblings('span.error').text('Pasword Must be at least 6 Charcters').fadeIn().parent('.form-group').addClass('hasError');
                apppasswordError = true;
            } else {
                $(this).siblings('.error').text('').fadeOut().parent('.form-group').removeClass('hasError');
                apppasswordError = false;
            }
        }

        // PassWord confirmation
        if ($('.apppass').val() !== $('.apppassConfirm').val()) {
            $('.apppassConfirm').siblings('.error').text('Passwords don\'t match').fadeIn().parent('.form-group').addClass('hasError');
            apppassConfirm = false;
        } else {
            $('.passConfirm').siblings('.error').text('').fadeOut().parent('.form-group').removeClass('hasError');
            apppassConfirm = false;
        }


        // label effect
        if ($(this).val().length > 0) {
            $(this).siblings('label').addClass('active');
        } else {
            $(this).siblings('label').removeClass('active');
        }
    });


    // form switch
    $('a.switch').click(function (e) {
        $(this).toggleClass('active');
        e.preventDefault();

        if ($('a.switch').hasClass('active')) {
            $(this).parents('.form-peice').addClass('switched').siblings('.form-peice').removeClass('switched');
        } else {
            $(this).parents('.form-peice').removeClass('switched').siblings('.form-peice').addClass('switched');
        }
    });


    // Form submit
    $('form.signup-form').submit(function (event) {
        event.preventDefault();

        if (appfirstnameError == true || applastnameError == true || appemailError == true || appuserphoneError == true || apppasswordError == true || apppassConfirm == true) {
            $('.appfirstname, .applastname .appemail, .appuserphone .apppass, .apppassConfirm').blur();
        } else {
            $('.signup, .login').addClass('switched');

            setTimeout(function () { $('.signup, .login').hide(); }, 700);
            setTimeout(function () { $('.brand').addClass('active'); }, 300);
            setTimeout(function () { $('.heading').addClass('active'); }, 600);
            setTimeout(function () { $('.success-msg p').addClass('active'); }, 900);
            setTimeout(function () { $('.success-msg a').addClass('active'); }, 1050);
            setTimeout(function () { $('.form').hide(); }, 700);
        }
    });

    // Reload page
    $('a.profile').on('click', function () {
        location.reload(true);
    });


});

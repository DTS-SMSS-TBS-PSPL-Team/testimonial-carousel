/*global $, document, window, setTimeout, navigator, console, location*/
$(document).ready(function () {

    'use strict';

    //var usernameError = true,
    //    emailError = true,
    //    passwordError = true,
    //    passConfirm = true;


    var firstnameError = true,
        lastnameError = true,
        emailError = true,
        userphoneError = true,
        passwordError = true,
        passConfirm = true,
        usertypenameError = true;

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
        if ($('.firstname').hasClass('firstname')) {
            if ($(this).val().length === 0) {
                $(this).siblings('span.error').text('Please Enter Your First Name').fadeIn().parent('.form-group').addClass('hasError');
                firstnameError = true;
            } else if ($(this).val().length > 1 && $(this).val().length <= 3) {
                $(this).siblings('span.error').text('First Name Must be at least 3 Characters').fadeIn().parent('.form-group').addClass('hasError');
                firstnameError = true;
            } else {
                $(this).siblings('.error').text('').fadeOut().parent('.form-group').removeClass('hasError');
                firstnameError = false;
            }
        }
        // Last Name
        if ($('.lastname').hasClass('lastname')) {
            if ($('.lastname').val().length === 0) {
                $('.lastname').siblings('span.error').text('Please Enter Your Last Name').fadeIn().parent('.form-group').addClass('hasError');
                lastnameError = true;
            } else if ($('.lastname').val().length > 1 && $('.lastnme').val().length <= 3) {
                $('.lastname').siblings('span.error').text('Last Name Must at least 3 characters').fadeIn().parent('.form-group').addClass('hasError');
                lastnameError = true;
            } else {
                $('.lastname').siblings('.error').text('').fadeOut().parent('.form-group').removeClass('hasError');
                lastnameError = false;
            }
        }
        // Email
        if ($(this).hasClass('email')) {
            if ($(this).val().length == '') {
                $(this).siblings('span.error').text('Please Enter Your Email address').fadeIn().parent('.form-group').addClass('hasError');
                emailError = true;
            } else {
                $(this).siblings('.error').text('').fadeOut().parent('.form-group').removeClass('hasError');
                emailError = false;
            }
        }

        // User Phone
        if ($(this).hasClass('userphone')) {
            if ($(this).val().length === 0) {
                $(this).siblings('span.error').text('Please Enter Your Phone Number').fadeIn().parent('.form-group').addClass('hasError');
                userphoneError = true;
            } else if ($(this).val().length > 1 && $(this).val().length <= 10) {
                $(this).siblings('span.error').text('Phone Number Must be at least 10 Digit').fadeIn().parent('.form-group').addClass('hasError');
                firstnameError = true;
            } else {
                $(this).siblings('.error').text('').fadeOut().parent('.form-group').removeClass('hasError');
                userphoneError = false;
            }
        }

        // PassWord
        if ($(this).hasClass('pass')) {
            if ($(this).val().length < 6) {
                $(this).siblings('span.error').text('Pasword Must be at least 6 Charcters').fadeIn().parent('.form-group').addClass('hasError');
                passwordError = true;
            } else {
                $(this).siblings('.error').text('').fadeOut().parent('.form-group').removeClass('hasError');
                passwordError = false;
            }
        }

        // PassWord confirmation
        if ($('.pass').val() !== $('.passConfirm').val()) {
            $('.passConfirm').siblings('.error').text('Passwords don\'t match').fadeIn().parent('.form-group').addClass('hasError');
            passConfirm = false;
        } else {
            $('.passConfirm').siblings('.error').text('').fadeOut().parent('.form-group').removeClass('hasError');
            passConfirm = false;
        }

        // User Type Name
        if ($(this).hasClass('usertypename')) {
            if ($(this).val().length === 0) {
                $(this).siblings('span.error').text('Please Enter Type of User (Admin or Super Admin)').fadeIn().parent('.form-group').addClass('hasError');
                usertypenameError = true;
            } else if ($(this).val().length > 1 && $(this).val().length <= 5) {
                $(this).siblings('span.error').text('User Type Name Must be at least 10 Character').fadeIn().parent('.form-group').addClass('hasError');
                usertypenameError = true;
            } else {
                $(this).siblings('.error').text('').fadeOut().parent('.form-group').removeClass('hasError');
                usertypenameError = false;
            }
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

        if (firstnameError == true || lastnameError == true || emailError == true || userphoneError == true || passwordError == true || passConfirm == true || usertypenameError == true) {
            $('.firstname, .lastname .email, .userphone .pass, .passConfirm, .usertypename').blur();
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

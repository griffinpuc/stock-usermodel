var typingTimer;
var doneTypingInterval = 500;
var $input = $('#inputPassword');
var $input2 = $('#inputPasswordCheck');
var $input3 = $('#inputEmail');
var $input4 = $('#inputUsername')

var emailVerif = false;
var passVerif1 = false;
var passVerifSame = false;
var usernameVerif = false;

//on keyup, start the countdown
$input.on('keyup', function () {
    typingTimer = setTimeout(doneTyping("inputPassword", "password-check"), doneTypingInterval);
});

//on keyup2, start the countdown
$input2.on('keyup', function () {
    typingTimer = setTimeout(doneTypingPassCheck("inputPasswordCheck", "password-double-check"), doneTypingInterval);
});

//on keyup3, start the countdown
$input3.on('keyup', function () {
    typingTimer = setTimeout(doneTypingEmail("inputEmail", "email-check"), doneTypingInterval);
});

//on keydown, clear the countdown
$input.on('keydown', function () {
    clearTimeout(typingTimer);
});

//user is "finished typing," do something
function doneTyping(elName, checkName) {
    var password = document.getElementById(elName).value;

    if (password.length < 8) {
        document.getElementById(checkName).className = "animated wobble far fa-circle";
        passVerif1 = false;
    }

    if (password.length >= 8) {
        document.getElementById(checkName).className = "animated bounce fa fa-check-circle";
        passVerif1 = true;
    }

}

//user is "finished typing," do something
function doneTypingUsername(elName, checkName) {
    var username = document.getElementById(elName).value;

    if (username.length >= 4) {
        document.getElementById(checkName).className = "animated bounce fa fa-check-circle";
        usernameVerif = true;
    }
    else {
        document.getElementById(checkName).className = "animated wobble far fa-circle";
        usernameVerif =  false;
    }

}

function doneTypingEmail(elName, checkName) {
    var email = document.getElementById(elName).value;

    if (/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email)) {
        document.getElementById(checkName).className = "animated bounce fa fa-check-circle";
        emailVerif = true;
    }
    else {
        document.getElementById(checkName).className = "animated wobble far fa-circle";
        emailVerif = false;
    }

}

function doneTypingPassCheck(elName, checkName) {
    var password = document.getElementById(elName).value;
    var origPassword = document.getElementById("inputPassword").value;

    if (password == origPassword) {
        document.getElementById(checkName).className = "animated bounce fa fa-check-circle";
        passVerifSame = true;
    }
    else {
        document.getElementById(checkName).className = "animated wobble far fa-circle";
        passVerifSame = false;
    }

}

function submitForm() {
    if (emailVerif & passVerif1 & passVerifSame) {

        var email = document.getElementById("inputEmail").value;
        var password = document.getElementById("inputPassword").value;

        document.getElementById("loginForm").submit();
    }

    else {
        alert("You suck");
    }
}
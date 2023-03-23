
var passInput1 = document.getElementById("NewPassWord");
    var letter1 = document.getElementById("letter1");
    var capital1 = document.getElementById("capital1");
    var number1 = document.getElementById("number1");
    var length1 = document.getElementById("length1");
    var special1 = document.getElementById("special1");

    // When the user clicks on the password field, show the message box

    passInput1.onfocus = function () {
        document.getElementById("ResetPassMessage").style.display = "block";
    }


    // When the user clicks outside of the password field, hide the message box
    passInput1.onblur = function () {
        document.getElementById("ResetPassMessage").style.display = "none";
    }


    // When the user starts to type something inside the password field
    passInput1.onkeyup = function () {
        // Validate lowercase letters
        var lowerCaseLetters1 = /[a-z]/g;
        if (passInput1.value.match(lowerCaseLetters1)) {
            letter1.classList.remove("invalid");
            letter1.classList.add("valid");
        } else {
            letter1.classList.remove("valid");
            letter1.classList.add("invalid");
        }

        // Validate capital letters
        var upperCaseLetters1 = /[A-Z]/g;
        if (passInput1.value.match(upperCaseLetters1)) {
            capital1.classList.remove("invalid");
            capital1.classList.add("valid");
        } else {
            capital1.classList.remove("valid");
            capital1.classList.add("invalid");
        }

        // Validate numbers
        var numbers1 = /[0-9]/g;
        if (passInput1.value.match(numbers1)) {
            number1.classList.remove("invalid");
            number1.classList.add("valid");
        } else {
            number1.classList.remove("valid");
            number1.classList.add("invalid");
        }

        // Validate length
        if (passInput1.value.length >= 8) {
            length1.classList.remove("invalid");
            length1.classList.add("valid");
        } else {
            length1.classList.remove("valid");
            length1.classList.add("invalid");
        }
        var specialCharacter1 = /[!@@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]/;
        if (passInput1.value.match(specialCharacter1)) {
            special1.classList.remove("invalid");
            special1.classList.add("valid");
        } else {
            special1.classList.remove("valid");
            special1.classList.add("invalid");
        }
    }


    var passInput = document.getElementById("passWord");
    var letter = document.getElementById("letter");
    var capital = document.getElementById("capital");
    var number = document.getElementById("number");
    var length = document.getElementById("length");
    var special = document.getElementById("special");

    // When the user clicks on the password field, show the message box

    passInput.onfocus = function () {
        document.getElementById("PassWordMessage").style.display = "block";
    }


    // When the user clicks outside of the password field, hide the message box
    passInput.onblur = function () {
        document.getElementById("PassWordMessage").style.display = "none";
    }


    // When the user starts to type something inside the password field
    passInput.onkeyup = function () {
        // Validate lowercase letters
        var lowerCaseLetters = /[a-z]/g;
        if (passInput.value.match(lowerCaseLetters)) {
            letter.classList.remove("invalid");
            letter.classList.add("valid");
        } else {
            letter.classList.remove("valid");
            letter.classList.add("invalid");
        }

        // Validate capital letters
        var upperCaseLetters = /[A-Z]/g;
        if (passInput.value.match(upperCaseLetters)) {
            capital.classList.remove("invalid");
            capital.classList.add("valid");
        } else {
            capital.classList.remove("valid");
            capital.classList.add("invalid");
        }

        // Validate numbers
        var numbers = /[0-9]/g;
        if (passInput.value.match(numbers)) {
            number.classList.remove("invalid");
            number.classList.add("valid");
        } else {
            number.classList.remove("valid");
            number.classList.add("invalid");
        }

        // Validate length
        if (passInput.value.length >= 8) {
            length.classList.remove("invalid");
            length.classList.add("valid");
        } else {
            length.classList.remove("valid");
            length.classList.add("invalid");
        }
        var specialCharacter = /[!@@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]/;
        if (passInput.value.match(specialCharacter)) {
            special.classList.remove("invalid");
            special.classList.add("valid");
        } else {
            special.classList.remove("valid");
            special.classList.add("invalid");
        }
    }

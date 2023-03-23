$("#msg").hide();
$("#noneAuthencation").hide();
function SignUp() {
    $("#ShowModal").modal();
    var messageArray = [
        $("#message1"),
        $("#message2"),
        $("#message3"),
        $("#passWordFormat"),
        $("#mailFormat"),
        $("#phoneFormat"),
        $("#passWordMismatched"),
    ];
    messageArray.every(hidden);
    function hidden(h) {
        return h.hide();
    }
}
function SaveForm() {
    var name = $("#user").val();
    var pass = $("#passWord").val();
    var email = $("#Email").val();
    var phoneNumber = $("#phonenumber").val();
    var reenterPass = $("#reenterpassword").val();
    if (name == "" || pass == "" || email == "") {

        $("#message2").show();
        setTimeout(() => {
            $("#message2").hide();
        }, 5000);
        return false;
    }
    if (pass != reenterPass) {
        $("#passWordMismatched").show();
        setTimeout(() => {
            $("#passWordMismatched").hide();
        }, 5000);
        return false;
    }

    var passFormat = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?!.*\s).{8,30}$/;
    var mailFormat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    var phoneFormat = /^\d{10}$/;
    if (!pass.match(passFormat)) {
        alert("Wrong Pass Format!");
        $("#passWordFormat").show();
        setTimeout(() => {
            $("#passWordFormat").hide();
        }, 5000);
        return false;
    }
    if (!email.match(mailFormat)) {

        alert("Wrong Mail Format!");

        $("#mailFormat").show();
        setTimeout(() => {
            $("#mailFormat").hide();
        }, 5000);
        return false;
    }
    if (!phoneNumber.match(phoneFormat)) {
        alert("Wrong Phone Format!");
        $("#phoneFormat").show();
        setTimeout(() => {
            $("#phoneFormat").hide();
        }, 5000);
        return false;
    }

    var data = $("#Registration").serialize();
    $.ajax({
        type: "post",
        data: data,
        url: "/Login/Register",
        success: function (result) {
            if (result == "Exist") {
                $("#message3").show();
                setTimeout(() => {
                    $("#message3").hide();
                }, 5000);
                $("#Registration")[0].reset();
            }
            else if (result == "notAdmin") {
                $("#message2").show();
                setTimeout(() => {
                    $("#message2").hide();
                }, 5000);
                $("#Registration")[0].reset();
            }
            else {
                $("#message1").show();
                setTimeout(() => {
                    $("#message1").hide();
                }, 5000);
                $("#Registration")[0].reset();
            }

        }
    });
}
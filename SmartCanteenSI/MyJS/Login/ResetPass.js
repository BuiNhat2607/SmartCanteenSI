function ForgotPassWord() {
    $("#ForgotPassword").modal();
    var forgotPassMessage = [
        $("#OTPSended"),
        $("#infoSuccess"),
        $("#mismatchedPass"),
        $("#lackOfInfo"),
        $("#wrongOTP"),
        $("#notFound")
    ];
    forgotPassMessage.every(hidden);
    function hidden(h) {
        return h.hide();
    }
}

var ResetPass = function () {

    var OTP = $("#OTP").val();
    var mail = $("#ResetEmail").val();
    var pass = $("#NewPassWord").val();
    var reenterpass = $("#ReenterPass").val();
    if (OTP == "" || mail == "" || pass == "" || reenterpass == "") {
        $("#lackOfInfo").show();
        setTimeout(() => {
            $("#lackOfInfo").hide();
        }, 5000);
        return false;
    }
    if (pass != reenterpass) {
        $("#mismatchedPass").show();
        setTimeout(() => {
            $("#mismatchedPass").hide();
        }, 5000);
        return false;
    }
    var passFormat = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?!.*\s).{8,30}$/;
    if (!pass.match(passFormat)) {
        alert("Wrong Pass Format!");
        $("#passWordFormat").show();
        setTimeout(() => {
            $("#passWordFormat").hide();
        }, 5000);
        return false;
    }
    var data = $("#ResetPass").serialize();
    $.ajax({
        type: "post",
        url: "/Login/ResetPass",
        data: data,
        success: function (kq) {
            if (kq == "NotValid") {
                $("#ResetPass")[0].reset();
                $("#notFound").show();
                setTimeout(() => {
                    $("#notFound").hide();
                }, 5000);
                return false;
            }
            if (kq == "WrongOTP") {
                $("#wrongOTP").show();
                setTimeout(() => {
                    $("#wrongOTP").hide();
                }, 5000);
                return false;
            }
            else {
                $("#ResetPass")[0].reset();
                $("#infoSuccess").show();
                setTimeout(() => {
                    $("#infoSuccess").hide();
                }, 5000);
            }
        }
    })
}
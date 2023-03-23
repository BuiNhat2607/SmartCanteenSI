
    $("#msg").hide();
    $("#noneAuthencation").hide();
    var Login = function () {
        var data = $("#loginForm").serialize();
    $.ajax({
        type: "post",
    url: "/Login/CheckAccount",
    data: data,
    success: function (result) {
                if (result == "Fail") {
        $("#loginForm")[0].reset();
    $("#msg").show();
                    setTimeout(() => {
        $("#msg").hide();
                    }, 5000);
                }
    else if (result == "notValid") {
        $("#loginForm")[0].reset();
    $("#noneAuthencation").show();
                    setTimeout(() => {
        $("#noneAuthencation").hide();
                    }, 5000);
                }
    else {
        window.location.href = "/HomePage/Index";
    $("#msg").hide();
    $("#noneAuthencation").hide();
                }
            }
        })
    }
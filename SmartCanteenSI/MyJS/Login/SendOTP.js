var GuiOTP = function () {
    var data = $("#ResetPass").serialize();
    $.ajax({
        type: "post",
        data: data,
        url: "/Login/SendOTP",
        success: function (Valid) {
            if (Valid == false) {
                $("#notFound").show();
                setTimeout(() => {
                    $("#notFound").hide();
                }, 5000);
            }
            else {
                $("#OTPSended").show();
                setTimeout(() => {
                    $("#OTPSended").hide();
                }, 5000);
            }
        }
    });
}
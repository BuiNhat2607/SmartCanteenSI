function SaveEdit() {
    var name = $("#FullName").val();
    var phone = $("#PhoneNumber").val();
    var mail = $("#Email").val();
    var nameFormat = /^[A-ZÀÁẠẢÃÂẦẤẬẨẪĂẰẮẶẲẴÈÉẸẺẼÊỀẾỆỂỄÌÍỊỈĨÒÓỌỎÕÔỒỐỘỔỖƠỜỚỢỞỠÙÚỤỦŨƯỪỨỰỬỮỲÝỴỶỸĐ\s][a-zàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹđ\s]*(?:[A-ZÀÁẠẢÃÂẦẤẬẨẪĂẰẮẶẲẴÈÉẸẺẼÊỀẾỆỂỄÌÍỊỈĨÒÓỌỎÕÔỒỐỘỔỖƠỜỚỢỞỠÙÚỤỦŨƯỪỨỰỬỮỲÝỴỶỸĐ][a-zàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹđ\s]*)*$/;
    var phoneFormat = /(84|0[3|5|7|8|9])+([0-9]{8})\b/;
    var mailFormat = /^\w+([\.-]?\w+)@\w+([\.-]?\w+)*(\.\w{2,3})+$/;

    if (!name.match(nameFormat)) {
        $("#nameFail").show();
        setTimeout(() => {
            $("#nameFail").hide();
        }, 5000);
        return false;
    }
    if (!phone.match(phoneFormat)) {
        $("#phonenumFail").show();
        setTimeout(() => {
            $("#phonenumFail").hide();
        }, 5000);
        return false;
    }

    if (!mail.match(mailFormat)) {
        $("#mailFail").show();
        setTimeout(() => {
            $("#mailFail").hide();
        }, 5000);
        return false;
    }
    var data = $("#editform").serialize();
    $.ajax({
        type: "post",
        data: data,
        url: "/User/Edit",
        success: function (result) {
            if (result == "Success") {
                alert("Cập nhật thành công!");
            }
            else if (result == "Error") {
                alert("Lỗi không xác định!");
            }
            else {
                alert("Thất bại!!!");
            }
        }
    })
}
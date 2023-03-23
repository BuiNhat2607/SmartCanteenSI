$("#nameFail").hide();
$("#nameSuccess").hide();
$("#phonenumFail").hide();
$("#phonenumSuccess").hide();
$("#mailFail").hide();
$("#mailSuccess").hide();
var nameInput = document.getElementById('FullName');
var phoneInput = document.getElementById('PhoneNumber');
var mailInput = document.getElementById('Email');
nameInput.onblur = function () {
    document.getElementById('nameFail').style.display = "none";
    document.getElementById('nameSuccess').style.display = "none";
}
phoneInput.onblur = function () {
    document.getElementById('phonenumFail').style.display = "none";
    document.getElementById('phonenumSuccess').style.display = "none";
}
mailInput.onblur = function () {
    document.getElementById('mailFail').style.display = "none";
    document.getElementById('mailSuccess').style.display = "none";
}
nameInput.onkeyup = function () {
    name = $("#FullName").val();
    var checkName = /^[A-ZÀÁẠẢÃÂẦẤẬẨẪĂẰẮẶẲẴÈÉẸẺẼÊỀẾỆỂỄÌÍỊỈĨÒÓỌỎÕÔỒỐỘỔỖƠỜỚỢỞỠÙÚỤỦŨƯỪỨỰỬỮỲÝỴỶỸĐ\s][a-zàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹđ\s]*(?:[A-ZÀÁẠẢÃÂẦẤẬẨẪĂẰẮẶẲẴÈÉẸẺẼÊỀẾỆỂỄÌÍỊỈĨÒÓỌỎÕÔỒỐỘỔỖƠỜỚỢỞỠÙÚỤỦŨƯỪỨỰỬỮỲÝỴỶỸĐ][a-zàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹđ\s]*)*$/;
    if (!name.match(checkName)) {
        $("#nameFail").show();
        $("#nameSuccess").hide();
    }
    else {
        $("#nameFail").hide();
        $("#nameSuccess").show();
    }
}
phoneInput.onkeyup = function () {
    sdt = $("#PhoneNumber").val();
    var checkPhoneNumber = /(84|0[3|5|7|8|9])+([0-9]{8})\b/;
    if (!sdt.match(checkPhoneNumber)) {
        $("#phonenumFail").show();
        $("#phonenumSuccess").hide();
    }
    else {
        $("#phonenumFail").hide();
        $("#phonenumSuccess").show();
    }
}
mailInput.onkeyup = function () {
    mail = $("#Email").val();
    var checkMail = /^\w+([\.-]?\w+)@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    if (!mail.match(checkMail)) {
        $("#mailFail").show();
        $("#mailSuccess").hide();
    }
    else {
        $("#mailFail").hide();
        $("#mailSuccess").show();
    }
}  
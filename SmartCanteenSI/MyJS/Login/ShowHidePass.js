
var regPass = document.getElementById("passWord")
var regPass2 = document.getElementById("reenterpassword");
var logPass = document.getElementById("logPassWord");
function ShowPass() {
    regPass.type = "text";
regPass2.type = "text";
logPass.type = "text";
}
function HidePass() {
    regPass.type = "password";
regPass2.type = "password";
logPass.type = "password";
}

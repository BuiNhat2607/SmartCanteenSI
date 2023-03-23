var day, month, year;

function SaveEdit() {
    var date = $('#BirthDay').val().split("-");
    console.log(date, $('#BirthDay').val())
    day = date[2];
    month = date[1];
    year = date[0];
    alert(day + month + year);
}
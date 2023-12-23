$(document).ready(function () {
    GetAllEmployees();

});

function GetAllEmployees() {

    var apiUrl = 'api/Home/GetAllEmployees';

    $.ajax({
        type: 'GET',
        dataType: "json",
        url: apiUrl,
        success: function (data, status, xhr) {
            console.log('data: ', data);
        },
        error: function (error) {
            console.log(error);
            alert('There was an error when processing your request');

        }
    });
}
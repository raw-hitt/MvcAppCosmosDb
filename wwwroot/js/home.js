$(document).ready(function () {
    GetAllEmployees();

});

function GetAllEmployees() {

    var apiUrl = 'api/Employees/GetAllEmployees';

    $.ajax({
        type: 'GET',
        dataType: "json",
        url: apiUrl,
        success: function (datas, status, xhr) {

            console.log('data: ', datas);
            var jsonData = JSON.parse(datas.data);

            var htmlContent = '<ul>';
            for (var key in jsonData[0]) {
                htmlContent += '<li><strong>' + key + ':</strong> ' + jsonData[0][key] + '</li>';
            }
            htmlContent += '</ul>';
            $('#employees').html(htmlContent);

        },
        error: function (error) {
            console.log(error);
            alert('There was an error when processing your request');

        }
    });
}
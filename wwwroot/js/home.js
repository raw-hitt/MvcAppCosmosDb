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

            
            var jsonData = JSON.parse(datas.data);
            console.log('data: ', jsonData);

            var htmlContent = '<table><tr>';
            for (var key in jsonData[0]) {
                htmlContent += '<th><strong>' + key + ':</strong> </th>';
            }
            htmlContent += '</tr>';



            for (var key in jsonData[0]) {
                htmlContent += '<tr>';
                for (var key in jsonData[0]) {
                    htmlContent += '<td>' + jsonData[0][key] + '</td>';
                }
                htmlContent += '</tr>';
            }

            htmlContent += '</table>';
            $('#employees').html(htmlContent);

        },
        error: function (error) {
            console.log(error);
            alert('There was an error when processing your request');

        }
    })
}
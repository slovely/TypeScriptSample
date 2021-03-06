﻿$(function () {
    $('#btnGetPeople').click(getPeople);
});

function getPeople() {
    $.ajax({
        url: "api/person",
        method: 'get'
    }).done(function (response) {
        var details = '<ul>';
        for (var i = 0; i < response.length; i++) {
            details += "<li>" + response[i].Name + "</li>"; //If 'Name' gets changed on the server, this code will fail
        }
        details += '</ul>';
        $('#serverResponse').html(details);
    }).fail();
}
//# sourceMappingURL=app.js.map

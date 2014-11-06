
$(() => {
    $('#btnGetPeople').click(getPeople);
});
 

function getPeople() {
    $.ajax({
        url: "api/person",
        method: 'get',
    }).done((response: Array<TypeScriptSample.Models.Person>) => {
        var details = '<ul>';
        for (var i = 0; i < response.length; i++) {
            details += "<li>" + response[i].Name + "</li>"; //If 'Name' gets changed on the server, this code will fail
        }
        details += '</ul>';
        $('#serverResponse').html(details);
    }).fail();
}
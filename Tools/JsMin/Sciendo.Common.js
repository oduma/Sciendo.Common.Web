$(document).ajaxError(function (evt, xhr) {
    try {
        var json = $.parseJSON(xhr.responseText);
        if (json.originator === "") {
            alert(json.errorMessage);
        }
        else {
            $('#' + json.originator).text('Error: ' + json.errorMessage);
        }
    } catch (e) {
        alert('something bad happened');
    }
});

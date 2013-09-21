var components = namespace("Sciendo.Common.Components");

components.DisplaySearchNoFormat = function (data, searchBaseId) {
    if (data.length === 1)
        $('#' + 'display_area_' + searchBaseId).text(data[0].Name);
    else {
        $("<ul id='" + 'display_area_' + searchBaseId + "_ul'/>").appendTo($('#' + 'display_area_' + searchBaseId));
        $.each(data, function (key, item) {
            $('<li>', { text: item.Name }).appendTo($('#' + 'display_area_' + searchBaseId + '_ul'));
        });
    }

};

components.DisplaySearchFormat = function (data, searchBaseId, formatData) {
    if (data.length === 1)
        $('#' + 'display_area_' + searchBaseId).text(formatData(data[0]));
    else {
        $("<ul id='" + 'display_area_' + searchBaseId + "_ul'/>").appendTo($('#' + 'display_area_' + searchBaseId));
        $.each(data, function (key, item) {
            $('<li>', { text: formatData(item) }).appendTo($('#' + 'display_area_' + searchBaseId + '_ul'));
        });
    }

};

components.SearchClient = function (apiUrl, searchBaseid, serverSideId, formatData) {
    $('#' + 'search_action_' + searchBaseid).click(function () {
        var datain = eval("(" + "{ "+ serverSideId + " : $('#' + 'search_value_' + searchBaseid).val(), originator: 'display_area_' + searchBaseid }"+")");
        $.getJSON(apiUrl, datain, function (data, textStatus, jhxqr) {
            if (formatData == null)
                components.DisplaySearchNoFormat(data, searchBaseid);
            else
                components.DisplaySearchFormat(data, searchBaseid, formatData);
        })
    });
};

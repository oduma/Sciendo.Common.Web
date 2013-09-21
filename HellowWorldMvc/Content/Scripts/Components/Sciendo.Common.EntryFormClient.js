var components = namespace("Sciendo.Common.Components");
components.BuildModelForPost = function(modelValues) {
    var jsonModelValues = eval("(" + modelValues + ")");
    var model = "{";
    $.each(jsonModelValues, function(key, item) {
        model += item.Name + ": '" + $('#' + item.SupportingTagId).val() + "',";
    });
    model = model.substring(0, model.length - 1);
    model += "}";
    return model;
};

components.EntryFormClient = function (apiUrl, entryFormBaseId,modelValues,successCallback,failCallBack) {
    $('#' + 'entryForm_action_' + entryFormBaseId).click(function () {
        var datain = components.BuildModelForPost(modelValues);

        $.ajax({
            url: apiUrl,
            cache: false,
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            data: datain,
            success: function(data, textStatus, xhr) {
                successCallback(data);
            },
            fail: function(xhr, textStatus, err) {
                failCallBack(xhr, textStatus, err);
            }
        });
    });
};
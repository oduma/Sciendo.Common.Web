var components = namespace("Sciendo.Common.Components");

var parallelExecuters = [];

var asynchUls = [];


components.AsynchUl = function (level, apiUrl, asynchUlBaseId, controllerParams, successCallback, failCallBack) {
    this.apiUrl = apiUrl;
    this.asynchUlBaseId = asynchUlBaseId;
    this.controllerParams = controllerParams;
    this.successCallback = successCallback;
    this.failCallBack = failCallBack;
    this.level = level;
};

components.AsynchUl.prototype.QueueAnAsynchUlRequest = function () {
    var dataIn = { "controllerParams": this.controllerParams, "callingElementId": this.asynchUlBaseId };
    if (parallelExecuters.length == this.level) {
        parallelExecuters.push(new ParaJax());
    }
    parallelExecuters[this.level].addRequest($.get, this.apiUrl, dataIn, 'json');
    parallelExecuters[this.level].addOnCompleteHandler(this.successCallback);
};

components.AsynchUl.prototype.AddItemToAsynchUl = function (items, id, value, subItems) {
    var ulWrapper = '<ul id="asynch_ul_' + value + '">';
    ulWrapper += this.AddItemsToAsynchUl(subItems) + '</ul>';

    items.push('<li id="' + id + '">' + value + ulWrapper + '</li>');
};

components.AsynchUl.prototype.AddItemsToAsynchUl = function (subItems) {
    var items = [];
    var currentAsynchUl = this;
    $.each(subItems, function (i, item) {
        if (item.goDeeper) {
            items.push('<li id="' + item.id + '">' + item.label + '<ul id="asynch_ul_' + item.id + '"></ul></li>');
            components.AddNewAsynchUl(parallelExecuters.length, currentAsynchUl.apiUrl, item.id, item.value, currentAsynchUl.successCallback, currentAsynchUl.failCallBack);
        }
        else {
            items.push('<li id="' + item.id + '">' + item.label + '</li>');
        }
    }); // close each()
    return items.join('');
};

$(document).ready(function () {
    parallelExecuters[0].dispatchAll();
});

components.AddNewAsynchUl = function (level, apiUrl, asynchUlBaseId, controllerParams, successCallback, failCallBack) {
    asynchUls.push(new components.AsynchUl(level, apiUrl, asynchUlBaseId, controllerParams, successCallback, failCallBack));
    asynchUls[asynchUls.length - 1].QueueAnAsynchUlRequest();
};

components.AsynchDispatch = function () {
    parallelExecuters[parallelExecuters.length - 1].dispatchAll();

};

components.FindComponent = function(id) {
    var retValue;
    $.each(asynchUls, function(i, asynchUl) {
        if (asynchUl.asynchUlBaseId === id) {
            retValue = asynchUl;
        }
    });
    return retValue;
};
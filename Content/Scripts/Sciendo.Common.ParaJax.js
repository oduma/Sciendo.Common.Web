var ParaJax = function () {
    this.requests = [];
    this.results = [];
    this.resultsProcessed = [];
};

ParaJax.prototype.addOnCompleteHandler = function (onComplete) {
    this.onComplete = onComplete;
};
ParaJax.prototype.addRequest = function (method, url, data, format) {
    this.requests.push({
        "method": method,
        "url": url,
        "data": data,
        "format": format,
        "completed": false
    });
};

ParaJax.prototype.dispatchAll = function () {
    var self = this;
    $.each(self.requests, function (i, request) {
        if (this.resultsProcessed==null || !(this.resultsProcessed.length > i && this.resultsProcessed[i])) {
            request.method(request.url, request.data, function(r) {
                return function(data) {
                    r.completed = true;
                    self.results.push(data);
                    self.resultsProcessed.push(false);
                    self.checkAndComplete();
                };
            }(request));
        }
    });
};

ParaJax.prototype.allRequestsCompleted = function () {
    var i = 0;
    while (request = this.requests[i++]) {
        if (request.completed === false) {
            return false;
        } else if (!this.resultsProcessed[i - 1]) {
            this.resultsProcessed[i - 1] = true;
            this.onComplete(this.results[i - 1]);
        }
    }
    return true;
};

ParaJax.prototype.checkAndComplete = function () {
    if (this.allRequestsCompleted()) {
        //this.onComplete(this.results);
    }
};

angular.module('appServices').service('attachmentsService',
    function ($http, $q, appHelperConstant) {
        return {
            create: function (formData) {
                var jsonData = JSON.stringify(formData);
                var deferred = $q.defer();

                $http.post(appHelperConstant.apiBaseURL + 'attachments', jsonData)
                    .then(function success(response) {
                        deferred.resolve(response.data);
                    }, function error(response) {
                        alert("Error!");
                        deferred.resolve(null);
                    });

                return deferred.promise;
            },
            read: function (id) {
                var deferred = $q.defer();

                $http.get(appHelperConstant.apiBaseURL + 'attachments/' + id).
                    then(function success(response) {
                        deferred.resolve(response);
                    }, function error(response) {
                        deferred.resolve(null);
                    });

                return deferred.promise;
            },
            readByTask: function (filterObj) {
                var deferred = $q.defer();

                $http.get(appHelperConstant.apiBaseURL + 'attachments?taskId=' + filterObj.taskId).
                    then(function success(response) {
                        deferred.resolve(response.data);
                    }, function error(response) {
                        deferred.resolve(null);
                    });

                return deferred.promise;
            },
            upload: function (file) {
                return $http({
                    url: appHelperConstant.apiBaseURL + 'attachments',
                    method: 'POST',
                    data: file,
                    headers: { 'Content-Type': undefined }, //this is important
                    transformRequest: angular.identity //also important
                });
            },
            delete: function (id) {
                var deferred = $q.defer();

                $http.delete(appHelperConstant.apiBaseURL + 'attachments?id=' + id)
                    .then(function success(response) {
                        deferred.resolve(response.data);
                    }, function error(response) {
                        alert("Error!");
                        deferred.resolve(null);
                    });

                return deferred.promise;
            }
        }
    });
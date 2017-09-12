angular.module('appServices').service('preferencesService',
    function ($http, $q, appHelperConstant) {
        return {
            read: function () {
                var deferred = $q.defer();

                $http.get(appHelperConstant.apiBaseURL + 'preferences').
                    then(function success(response) {
                        deferred.resolve(response.data);
                    }, function error(response) {
                        deferred.resolve(null);
                    });

                return deferred.promise;
            },
            update: function (formData) {
                var jsonData = JSON.stringify(formData);
                var deferred = $q.defer();

                $http.put(appHelperConstant.apiBaseURL + 'preferences', jsonData)
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
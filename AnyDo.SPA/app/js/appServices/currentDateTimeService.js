angular.module('appServices').service('currentDateTimeService',
    function ($http, $q, appHelperConstant) {
        return {
            read: function () {
                var deferred = $q.defer();

                $http.get(appHelperConstant.apiBaseURL + 'currentDateTime').
                    then(function success(response) {
                        deferred.resolve(response.data);
                    }, function error(response) {
                        deferred.resolve(null);
                    });

                return deferred.promise;
            }
        }
    });

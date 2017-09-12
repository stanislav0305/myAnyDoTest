angular.module('appServices').service('currentUserService',
    function ($http, $q, appHelperConstant) {
        return {
            read: function () {
                var deferred = $q.defer();

                $http.get(appHelperConstant.apiBaseURL + 'currentUser').
                    then(function success(response) {
                        deferred.resolve(response.data);
                    }, function error(response) {
                        deferred.resolve(null);
                    });

                return deferred.promise;
            }
        }
    });
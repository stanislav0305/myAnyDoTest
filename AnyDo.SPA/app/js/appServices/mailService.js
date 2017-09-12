angular.module('appServices').service('mailService',
    function ($http, $q, appHelperConstant) {
        return {
            create: function (formData) {
                var jsonData = JSON.stringify(formData);
                var deferred = $q.defer();

                $http.post(appHelperConstant.apiBaseURL + 'mail', jsonData)
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

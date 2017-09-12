angular.module('appServices').service('subTasksService',
    function ($http, $q, appHelperConstant) {
        return {
            create: function (formData) {
                var jsonData = JSON.stringify(formData);
                var deferred = $q.defer();

                $http.post(appHelperConstant.apiBaseURL + 'subTasks', jsonData)
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

                $http.get(appHelperConstant.apiBaseURL + 'subTasks/' + id).
                    then(function success(response) {
                        deferred.resolve(response.data);
                    }, function error(response) {
                        deferred.resolve(null);
                    });

                return deferred.promise;
            },
            readByTask: function (filterObj) {
                var deferred = $q.defer();

                $http.get(appHelperConstant.apiBaseURL + 'subTasks?taskId=' + filterObj.taskId).
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

                $http.put(appHelperConstant.apiBaseURL + 'subTasks/' + formData.id, jsonData)
                    .then(function success(response) {
                        deferred.resolve(response.data);
                    }, function error(response) {
                        alert("Error!");
                        deferred.resolve(null);
                    });

                return deferred.promise;
            },
            delete: function (id) {
                var deferred = $q.defer();

                $http.delete(appHelperConstant.apiBaseURL + 'subTasks?id=' + id)
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
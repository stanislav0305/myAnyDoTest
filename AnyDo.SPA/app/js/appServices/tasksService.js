angular.module('appServices').service('tasksService',
    function ($http, $q, appHelperConstant) {
        return {
            create: function (formData) {
                var jsonData = JSON.stringify(formData);
                var deferred = $q.defer();

                $http.post(appHelperConstant.apiBaseURL + 'tasks', jsonData)
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

                $http.get(appHelperConstant.apiBaseURL + 'tasks/' + id).
                    then(function success(response) {
                        deferred.resolve(response.data);
                    }, function error(response) {
                        deferred.resolve(null);
                    });

                return deferred.promise;
            },
            readByTaskCategory: function (filterObj) {
                var deferred = $q.defer();

                $http.get(appHelperConstant.apiBaseURL + 'tasks?taskCategoryId=' + filterObj.taskCategoryId).
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

                $http.put(appHelperConstant.apiBaseURL + 'tasks/' + formData.id, jsonData)
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

                $http.delete(appHelperConstant.apiBaseURL + 'tasks?id=' + id)
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
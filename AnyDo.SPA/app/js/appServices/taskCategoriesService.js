angular.module('appServices').service('taskCategoriesService',
    function ($http, $q, appHelperConstant) {
        return {
            read: function () {
                var deferred = $q.defer();

                $http.get(appHelperConstant.apiBaseURL + 'taskCategories').
                    then(function success(response) {
                        deferred.resolve(response.data);
                    }, function error(response) {
                        deferred.resolve(null);
                    });

                return deferred.promise;
            },
            create: function (formData) {
                var jsonData = JSON.stringify(formData);
                var deferred = $q.defer();

                $http.post(appHelperConstant.apiBaseURL + 'taskCategories', jsonData)
                    .then(function success(response) {
                        deferred.resolve(response.data);
                    }, function error(response) {
                        alert("Error!");
                        deferred.resolve(null);
                    });

                return deferred.promise;
            },
            update: function (formData) {
                var jsonData = JSON.stringify(formData);
                var deferred = $q.defer();

                $http.put(appHelperConstant.apiBaseURL + 'taskCategories/' + formData.id, jsonData)
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

                $http.delete(appHelperConstant.apiBaseURL + 'taskCategories?id=' + id)
                    .then(function success(response) {
                        deferred.resolve(response.data);
                    }, function error(response) {
                        alert("Error!");
                        deferred.resolve(null);
                    });

                return deferred.promise;
            },
            updateSorting: function (taskCategoryItemsSorted) {
                var jsonData = JSON.stringify(taskCategoryItemsSorted);

                $http.put(appHelperConstant.apiBaseURL + 'taskCategories', jsonData)
                    .then(function success(response) {
                    }, function error(response) {
                        alert("Error!");
                    });
            }
        }
    });
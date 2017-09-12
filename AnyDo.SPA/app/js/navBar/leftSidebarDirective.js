angular.module('navBar').directive('leftSidebar',
    function (preferencesService) {
        return {
            restrict: "E",
            templateUrl: 'app/views/navBar/leftSidebar.html',
            link: function ($scope) {
                UIkit.accordion('#settings-accordion', {});

                $scope.preferences = {
                    preference: {
                        id: 0,
                        timeFormat: '12h',
                        dateFormat: 'DD/MM/YY',
                        weekStartDay: 1
                    }
                };

                function initPreferences() {
                    var perfPromisObj = preferencesService.read();
                    perfPromisObj.then(function (preferences) {
                        if (preferences !== null) {
                            $scope.preferences = preferences;
                        }
                    });
                }

                initPreferences();



                $scope.savePreferences = function () {

                    var perfPromisObj = preferencesService.update($scope.preferences.preference);
                    perfPromisObj.then(function () {
                        $scope.taskForCreateTimeOptions = "{format: '" + $scope.preferences.timeFormat + "'}";
                        alert("Saved");
                    });
                }

            }
        }
    });

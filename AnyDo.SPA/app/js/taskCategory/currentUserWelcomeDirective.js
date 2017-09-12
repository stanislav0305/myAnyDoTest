angular.module('taskCategory').directive('currentUserWelcome',
    function (currentUserService) {
        return {
            restrict: "E",
            templateUrl: 'app/views/taskCategory/currentUserWelcome.html',
            link: function ($scope) {

                $scope.currentUser = {
                    firstName: '...'
                };

                function initCurrentUser() {
                    var currentUserPromiseObj = currentUserService.read();
                    currentUserPromiseObj.then(function (currentUser) {
                        $scope.currentUser = currentUser;
                    });
                }

                initCurrentUser();
            }
        }
    });

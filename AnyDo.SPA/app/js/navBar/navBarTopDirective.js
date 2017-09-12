angular.module('navBar').directive('navBarTop',
    function (currentDateTimeService, appHelperConstant) {
        return {
            restrict: "E",
            templateUrl: 'app/views/navBar/navBarTopTemplate.html',
            link: function ($scope) {

                $scope.today = '';

                function todayInit() {

                    var todayPromiseObj = currentDateTimeService.read();
                    todayPromiseObj.then(function (today) {
                        $scope.today = today;
                    });

                }

                todayInit();
                $scope.ukTooltipOptions = appHelperConstant.ukTooltipOptions;
            }
        }
    });

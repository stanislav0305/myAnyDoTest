angular.module('shareAndAssign').directive('invintationSend',
    function (mailService) {
        return {
            restrict: "E",
            templateUrl: 'app/views/shareAndAssign/invintationSend.html',
            link: function ($scope) {

                $scope.invintationMail = {
                    mailTo: '',
                    message: '',
                    clear: function () {
                        this.mailTo = '';
                        this.message = '';
                    }
                };

                $scope.sendInvintation = function () {
                    var createPromiseObj = mailService.create($scope.invintationMail);
                    createPromiseObj.then(function (data) {
                        if (data !== null) {
                            alert("Sended!");
                            $scope.invintationMail.clear();                         
                        }
                    });

                }
            }
        }
    });

angular.module('subTask').directive('subTaskCreate',
    function (subTasksService) {
        return {
            restrict: "E",
            templateUrl: 'app/views/subTask/create.html',
            link: function ($scope) {

                $scope.subTaskForCreate = {
                    title: '',
                    clear: function () {
                        this.title = '';
                    }
                };

                $scope.createSubTask = function () {

                    $scope.subTaskForCreate.taskId = $scope.taskForEdit.id;
                
                    var createPromiseObj = subTasksService.create($scope.subTaskForCreate);

                    createPromiseObj.then(function (data) {
                       if (data !== null) {
                            alert("Saved!");

                            $scope.subTaskForCreate.clear();
                            $scope.subTasks.addItem(data);
                            $scope.taskForEdit.subTaskCount++;
                            $scope.showingManager.showEditTaskForm();
                        }
                    });
                }
            }
        }
    });

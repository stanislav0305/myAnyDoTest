angular.module('subTask').directive('subTaskEdit',
    function (subTasksService) {
        return {
            restrict: "E",
            templateUrl: 'app/views/subTask/edit.html',
            link: function ($scope) {

                $scope.subTaskForEdit = {
                    id: 0,
                    title: '',
                    init: function (subTask) {
                        this.id = subTask.id;
                        this.title = subTask.title;
                    },
                    clear: function () {
                        this.id = 0;
                        this.title = '';
                    }
                };

                $scope.subTaskEditClick = function (subTask) {
                    $scope.subTaskForEdit.init(subTask);
                    $scope.showingManager.showEditSubTaskForm();
                }

                $scope.editSubTask = function () {

                    $scope.subTaskForEdit.taskId = $scope.taskForEdit.id;

                    var editPromiseObj = subTasksService.update($scope.subTaskForEdit);
                    editPromiseObj.then(function (data) {
                        if (data !== null) {
                            alert("Saved!");
                            $scope.subTasks.editItem(data);
                            $scope.showingManager.showEditTaskForm();
                        }
                    });
                }
            }
        }
    });

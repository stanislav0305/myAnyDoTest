angular.module('subTask').directive('subTaskDelete',
    function (subTasksService) {
        return {
            restrict: "E",
            templateUrl: 'app/views/subTask/delete.html',
            link: function ($scope) {

                $scope.subTaskForDelete = {
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

                $scope.subTaskDeleteClick = function (subTask) {
                    $scope.subTaskForDelete.init(subTask);
                    $scope.showingManager.showDeleteSubTaskForm();
                }

                $scope.deleteSubTask = function (id) {

                    var editPromiseObj = subTasksService.delete(id);
                    editPromiseObj.then(function (data) {
                        if (data !== null) {
                            alert("Deleted!");
                            $scope.subTasks.removeItemById(id);
                            $scope.subTaskForDelete.clear();
                            $scope.taskForEdit.subTaskCount--;
                            $scope.showingManager.showEditTaskForm();
                        }
                    });
                }
            }
        }
    });
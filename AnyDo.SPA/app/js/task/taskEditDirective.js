angular.module('task').directive('taskEdit',
    function (preferencesService, tasksService) {
        return {
            restrict: "E",
            templateUrl: 'app/views/task/edit.html',
            link: function ($scope) {

                UIkit.tab('#task-detail-tabs', { connect: '#task-detail-tab-contents' });

                $scope.taskForEdit = {
                    id: 0,
                    title: '',
                    priority: false,
                    makeUpTo: new Date(),
                    notes: '',
                    subTaskCount: 0,
                    attachmentCount: 0,
                    init: function (task) {
                        this.id = task.id * 1;
                        this.title = task.title;
                        this.priority = task.priority;
                        this.makeUpTo = new Date(task.makeUpTo);
                        this.notes = task.notes;
                        this.subTaskCount = task.subTaskCount;
                        this.attachmentCount = task.attachmentCount;
                    },
                    clear: function () {
                        this.title = '';
                        this.priority = false;
                        this.makeUpTo = new Date();
                        this.notes = '';
                        this.subTaskCount = 0;
                        this.attachmentCount = 0;
                    }
                };

                $scope.taskEditClick = function (task) {
                    $scope.taskForEdit.init(task);
                    $scope.subTasks.loadAll(task.id);
                    $scope.attachments.loadAll(task.id);
                    $scope.showingManager.showEditTaskForm();
                }

                $scope.editTask = function () {

                    $scope.taskForEdit.taskCategoryId = $scope.taskCategoryForEdit.id;
                    var editPromiseObj = tasksService.update($scope.taskForEdit);

                    editPromiseObj.then(function (data) {
                        if (data !== null) {
                            alert("Saved!");
                            $scope.tasks.editItem(data);
                        }
                    });
                } 
            }
        }
    });

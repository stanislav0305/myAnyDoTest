angular.module('task').directive('taskEdit',
    function (preferencesService, tasksService) {
        return {
            restrict: "E",
            templateUrl: 'app/views/task/edit.html',
            link: function ($scope) {

                UIkit.tab('#task-detail-tabs', { connect: '#task-detail-tab-contents' });

                $scope.taskCategoryIdOld = 0;
                $scope.taskForEdit = {
                    id: 0,
                    title: '',
                    taskCategoryId: 0,
                    priority: false,
                    makeUpTo: new Date(),
                    notes: '',
                    subTaskCount: 0,
                    attachmentCount: 0,
                    init: function (task) {
                        this.id = task.id * 1;
                        this.title = task.title;
                        this.taskCategoryId = task.taskCategoryId;
                        this.priority = task.priority;
                        this.makeUpTo = new Date(task.makeUpTo);
                        this.notes = task.notes;
                        this.subTaskCount = task.subTaskCount;
                        this.attachmentCount = task.attachmentCount;
                    },
                    clear: function () {
                        this.title = '';
                        this.taskCategoryId = 0;
                        this.priority = false;
                        this.makeUpTo = new Date();
                        this.notes = '';
                        this.subTaskCount = 0;
                        this.attachmentCount = 0;
                    }
                };

                $scope.taskEditClick = function (task) {
                    $scope.taskForEdit.init(task);
                    $scope.taskCategoryIdOld = $scope.taskForEdit.taskCategoryId;

                    $scope.subTasks.loadAll(task.id);
                    $scope.attachments.loadAll(task.id);
                    $scope.showingManager.showEditTaskForm();
                }

                $scope.editTask = function () {

                    var editPromiseObj = tasksService.update($scope.taskForEdit);
                    editPromiseObj.then(function (data) {
                        if (data !== null) {
                            alert("Saved!");
                            $scope.tasks.editItem(data);

                            if ($scope.taskCategoryIdOld !== data.taskCategoryId) {

                                $scope.taskCategories.itemIncTaskCoutById(data.taskCategoryId);
                                $scope.taskCategories.itemDecTaskCoutById($scope.taskCategoryIdOld);

                                if (data.taskCategoryId != $scope.taskCategoryForEdit.id) {
                                    $scope.taskCategoryForEdit.taskCount--;
                                    $scope.tasks.loadAll($scope.taskCategoryForEdit.id);
                                }

                                $scope.taskCategoryIdOld = 0;
                            }
                        }
                    });
                } 
            }
        }
    });

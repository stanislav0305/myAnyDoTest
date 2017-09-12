angular.module('task').directive('taskCreate',
    function (preferencesService, tasksService) {
        return {
            restrict: "E",
            templateUrl: 'app/views/task/create.html',
            link: function ($scope) {

                $scope.taskForCreate = {
                    title: '',
                    priority: false,
                    makeUpTo: new Date(),
                    clear: function () {
                        this.title = '';
                        this.priority = false;
                        this.makeUpTo = new Date();
                    }
                };
               
                $scope.createTask = function () {

                    $scope.taskForCreate.taskCategoryId = $scope.taskCategoryForEdit.id;
                    var createPromiseObj = tasksService.create($scope.taskForCreate);

                    createPromiseObj.then(function (data) {
                        if (data !== null) {
                            alert("Saved!");

                            $scope.taskForCreate.clear();
                            $scope.tasks.addItem(data);

                            $scope.taskCategoryForEdit.taskCount++;
                            $scope.taskCategories.editItem($scope.taskCategoryForEdit);
                            $scope.taskCategories.mainItemIncTaskCout();

                            $scope.showingManager.showEditTaskCaregoryForm();
                        }
                    });
                }
            }
        }
    });

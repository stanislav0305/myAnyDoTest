angular.module('task').directive('taskCreate',
    function (preferencesService, tasksService) {
        return {
            restrict: "E",
            templateUrl: 'app/views/task/create.html',
            link: function ($scope) {

                $scope.taskForCreate = {
                    title: '',
                    taskCategoryId: 0,
                    priority: false,
                    makeUpTo: new Date(),
                    clear: function () {
                        this.title = '';
                        this.taskCategoryId = 0;
                        this.priority = false;
                        this.makeUpTo = new Date();
                    }
                };


                

                $scope.taskCreateClick = function () {
                    $scope.taskForCreate.clear();

                    selectNewTaskCategory();

                    $scope.showingManager.showCreateTaskForm();
                }

                $scope.taskCreateByCategoryIdClick = function (categoryId) {
                    $scope.taskForCreate.clear();

                    selectNewTaskCategory(categoryId);

                    $scope.showingManager.showCreateTaskForm();
                }

                $scope.taskCreateMomorrowClick = function () {
                    $scope.taskForCreate.clear();

                    selectNewTaskCategory();
                    selectNewTaskMakeUpToDate('tomorrow');

                    $scope.showingManager.showCreateTaskForm();
                }

                $scope.taskCreateUpcommingClick = function () {
                    $scope.taskForCreate.clear();

                    selectNewTaskCategory();
                    selectNewTaskMakeUpToDate('upcomming');

                    $scope.showingManager.showCreateTaskForm();
                }

                $scope.taskCreateSomedayClick = function () {
                    $scope.taskForCreate.clear();

                    selectNewTaskCategory();
                    selectNewTaskMakeUpToDate('someday');

                    $scope.showingManager.showCreateTaskForm();
                }

                $scope.taskCreateHighPriorityClick = function () {
                    $scope.taskForCreate.clear();

                    selectNewTaskCategory();
                    selectNewTaskPriority(true);

                    $scope.showingManager.showCreateTaskForm();
                }



                function selectNewTaskCategory(categoryId) {

                    if (categoryId !== undefined) {
                        $scope.taskForCreate.taskCategoryId = categoryId;
                        return;
                    }

                    if ($scope.taskCategoryForEdit.isMain) {
                        var tc = $scope.taskCategories.isNotMainOnly();

                        if (!tc.length) {
                            alert("There are no categories. Please create a category and then you be can create task.");
                            return;
                        }

                        $scope.taskForCreate.taskCategoryId = tc[0].id;
                    }
                    else {
                        $scope.taskForCreate.taskCategoryId = $scope.taskCategoryForEdit.id;
                    }
                }

                function selectNewTaskMakeUpToDate(makeUpToInitMode) {

                    switch (makeUpToInitMode) {
                        case 'today': {
                            $scope.taskForCreate.makeUpTo = new Date();
                            break;
                        }
                        case 'tomorrow': {
                            var tomorrowDate = new Date();
                            tomorrowDate.setDate(tomorrowDate.getDate() + 1);
                            $scope.taskForCreate.makeUpTo = tomorrowDate;
                            break;
                        }
                        case 'upcomming': {
                            var date = new Date();
                            date.setDate(date.getDate() + 2);
                            $scope.taskForCreate.makeUpTo = date;
                            break;
                        }
                        case 'someday': {
                            var date = new Date();
                            date.setDate(date.getDate() + 6);
                            $scope.taskForCreate.makeUpTo = date;
                            break;
                        }
                        default: {
                            break;
                        }
                    }

                }

                function selectNewTaskPriority(priority) {
                    $scope.taskForCreate.priority = priority;
                }


                $scope.createTask = function () {

                    var createPromiseObj = tasksService.create($scope.taskForCreate);

                    createPromiseObj.then(function (data) {
                        if (data !== null) {
                            alert("Saved!");

                            $scope.tasks.addItem(data);

                            $scope.taskCategoryForEdit.taskCount++;
                            $scope.taskCategories.itemIncTaskCoutById($scope.taskForCreate.taskCategoryId);
                            $scope.taskCategories.mainItemIncTaskCout();

                            $scope.taskForCreate.clear();

                            $scope.showingManager.showEditTaskCaregoryForm();
                        }
                    });
                }
            }
        }
    });

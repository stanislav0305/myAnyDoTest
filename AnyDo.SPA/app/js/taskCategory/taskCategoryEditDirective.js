angular.module('taskCategory').directive('taskCategoryEdit',
    function (taskCategoriesService) {
        return {
            restrict: "E",
            templateUrl: 'app/views/taskCategory/edit.html',
            link: function ($scope) {

                $scope.taskCategoryForEdit = {
                    id: 0,
                    title: '',
                    taskCount: 0,
                    init: function (taskCategory) {
                        this.id = taskCategory.id * 1;
                        this.title = taskCategory.title;
                        this.taskCount = taskCategory.taskCount;
                    },
                    clear: function () {
                        this.id = 0;
                        this.title = '';
                        this.taskCount = 0;
                    }
                };

                $scope.taskCategoryEditClick = function (taskCategory) {
                    $scope.taskCategoryForEdit.init(taskCategory);
                    $scope.tasks.loadAll(taskCategory.id);
                    $scope.showingManager.showEditTaskCaregoryForm();
                    UIkit.modal("#task-category-edit-modal").show();
                }

                $scope.editTaskCategory = function () {

                    var editPromiseObj = taskCategoriesService
                        .update($scope.taskCategoryForEdit);

                    editPromiseObj.then(function (response) {
                        if (response != null) {
                            $scope.taskCategories.editItem($scope.taskCategoryForEdit);
                            alert('saved!');
                        }
                    });

                }

            }
        }
    });

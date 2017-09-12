angular.module('taskCategory').directive('taskCategoryDelete',
    function (taskCategoriesService) {
        return {
            restrict: "E",
            templateUrl: 'app/views/taskCategory/delete.html',
            link: function ($scope, element, attrs) {

                $scope.taskCategoryForDelete = {
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

                $scope.taskCategoryDeleteClick = function (taskCategory) {
                    if (taskCategory.taskCount > 0) {
                        alert("This task category have " + taskCategory.taskCount + "tasks. It can't be removed");
                        return;
                    }

                    $scope.taskCategoryForDelete.init(taskCategory);
                    UIkit.modal("#task-category-delete-modal").show();
                };

                $scope.deleteTaskCategory = function () {

                    var deletePromiseObj = taskCategoriesService
                        .delete($scope.taskCategoryForDelete.id);

                    deletePromiseObj.then(function (response) {
                        if (response != null) {
                            $scope.taskCategories.removeItemById($scope.taskCategoryForDelete.id);
                            $scope.taskCategoryForDelete.clear();
                            UIkit.modal("#task-category-delete-modal").hide();
                        }
                    });

                }

            }
        }
    });

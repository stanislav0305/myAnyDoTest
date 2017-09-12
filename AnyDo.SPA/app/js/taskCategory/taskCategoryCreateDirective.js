angular.module('taskCategory').directive('taskCategoryCreate',
    function (taskCategoriesService) {
        return {
            restrict: "E",
            templateUrl: 'app/views/taskCategory/create.html',
            link: function ($scope) {

                $scope.taskCategoryForCreate = {
                    title: '',
                    taskCount: 0,
                    clear: function () {
                        this.title = '';
                        this.taskCount = 0;
                    }
                };

                $scope.createTaskCategory = function () {
                    var createPromiseObj = taskCategoriesService.create($scope.taskCategoryForCreate);

                    createPromiseObj.then(function (data) {
                        if (data != null) {
                            var modal = UIkit.modal("#task-category-create-modal");
                            modal.hide();
                            $scope.taskCategoryForCreate.clear();
                            $scope.taskCategories.addItem(data);
                        }
                    });
                }
            }
        }
    });

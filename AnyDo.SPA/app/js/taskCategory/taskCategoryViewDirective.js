angular.module('taskCategory').directive('taskCategoryView',
    function (taskCategoriesService) {
        return {
            restrict: "E",
            templateUrl: 'app/views/taskCategory/view.html',
            link: function ($scope) {

                $scope.taskCategories = {
                    items: [],
                    loadAll: function () {
                        var taskCategoryPromisObj = taskCategoriesService.read();

                        taskCategoryPromisObj.then(function (taskCategories) {
                            $scope.taskCategories.items = taskCategories;
                        });
                    },
                    addItem: function (item) {
                        this.items.push(item);
                    },
                    editItem: function (item) {
                        for (var i = 0; i < this.items.length; i++) {
                            if (this.items[i].id === item.id) {
                                this.items[i].title = item.title;
                                this.items[i].taskCount = item.taskCount;
                                break;
                            }
                        }
                    },
                    mainItemIncTaskCout: function (item) {
                        for (var i = 0; i < this.items.length; i++) {
                            if (this.items[i].isMain) {
                                this.items[i].taskCount++;
                                break;
                            }
                        }
                    },
                    mainItemDecTaskCout: function (item) {
                        for (var i = 0; i < this.items.length; i++) {
                            if (this.items[i].isMain) {
                                this.items[i].taskCount--;
                                break;
                            }
                        }
                    },
                    removeItemById: function (id) {
                        this.items = this.items.filter(function (item) {
                            return item.id !== id;
                        });
                    }
                };


                function initTaskCategoryGrid() {

                    $scope.taskCategories.loadAll();

                    UIkit.sortable('#task-category-grid', { handleClass: 'uk-sortable-handle' });
                    var taskCategoryGrid = angular.element(document.querySelector("#task-category-grid"));

                    taskCategoryGrid.on('change.uk.sortable', function (event, sortableObj, draggedElement) {

                        var htmlItems = sortableObj.find('.task-category-grid-item');
                        var taskCategoryItemsSorted = [];
                        angular.forEach(htmlItems, function (item, key) {
                            var ngItem = angular.element(item);
                            var id = ngItem.attr('data-id');

                            taskCategoryItemsSorted.push({
                                id: id * 1,
                                orderNumber: key
                            });
                        });

                        taskCategoriesService.updateSorting(taskCategoryItemsSorted);
                    });
                }

                initTaskCategoryGrid();

            }
        }
    });
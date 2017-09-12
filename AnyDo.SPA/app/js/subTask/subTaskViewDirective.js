angular.module('subTask').directive('subTaskView',
    function (subTasksService) {
        return {
            restrict: "E",
            templateUrl: 'app/views/subTask/view.html',
            link: function ($scope) {

                $scope.subTasks = {
                    items: [],
                    loadAll: function (taskId) {
                        var filterObj = {
                            taskId: taskId
                        };

                        var subTaskPromisObj = subTasksService.readByTask(filterObj);

                        subTaskPromisObj.then(function (subTasks) {
                            $scope.subTasks.items = subTasks;
                        });
                    },
                    addItem: function (item) {
                        this.items.push(item);
                    },
                    editItem: function (item) {

                        for (var i = 0; i < this.items.length; i++) {
                            if (this.items[i].id === item.id) {
                                this.items[i].title = item.title;
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
            }
        }
    });

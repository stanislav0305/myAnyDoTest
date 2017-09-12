angular.module('task').directive('taskView',
    function (tasksService) {
        return {
            restrict: "E",
            templateUrl: 'app/views/task/view.html',
            link: function ($scope) {

                $scope.tasks = {
                    items: [],
                    loadAll: function (taskCategoryId) {
                        var filterObj = {
                            taskCategoryId: taskCategoryId
                        };

                        var taskPromisObj = tasksService.readByTaskCategory(filterObj);

                        taskPromisObj.then(function (tasks) {
                            $scope.tasks.items = tasks;
                        });
                    },
                    addItem: function (item) {
                        this.items.push(item);
                    },
                    editItem: function (item) {

                        for (var i = 0; i < this.items.length; i++) {
                            if (this.items[i].id === item.id) {
                                this.items[i].title = item.title;
                                this.items[i].priority = item.priority;
                                this.items[i].makeUpTo = new Date(item.makeUpTo);
                                this.items[i].notes = item.notes;
                                this.items[i].subTaskCount = item.subTaskCount;
                                this.items[i].attachmentCount = item.attachmentCount;
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

                UIkit.tab('#task-view-mode-tabs', { connect: '#task-view-mode-tab-contents' });
            }
        }
    });

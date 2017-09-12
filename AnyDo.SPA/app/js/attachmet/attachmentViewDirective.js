angular.module('attachment').directive('attachmentView',
    function (appHelperConstant, attachmentsService) {
        return {
            restrict: "E",
            templateUrl: 'app/views/attachment/view.html',
            link: function ($scope) {

                $scope.attachments = {
                    items: [],
                    loadAll: function (taskId) {
                        var filterObj = {
                            taskId: taskId
                        };

                        var attachmentsPromisObj = attachmentsService.readByTask(filterObj);

                        attachmentsPromisObj.then(function (subTasks) {
                            $scope.attachments.items = subTasks;
                        });
                    },
                    addItem: function (item) {
                        this.items.push(item);
                    },
                    removeItemById: function (id) {
                        this.items = this.items.filter(function (item) {
                            return item.id !== id;
                        });
                    }
                };

                $scope.apiBaseURL = appHelperConstant.apiBaseURL;
            }
        }
    });

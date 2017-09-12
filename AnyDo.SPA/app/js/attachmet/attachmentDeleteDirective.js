angular.module('attachment').directive('attachmentDelete',
    function (attachmentsService) {
        return {
            restrict: "E",
            templateUrl: 'app/views/attachment/delete.html',
            link: function ($scope, element, attrs) {

                $scope.attachmentForDelete = {
                    id: 0,
                    fileNameFull: '',
                    fileSizeInBites: 0,
                    init: function (attachment) {
                        this.id = attachment.id;
                        this.fileNameFull = attachment.fileNameFull;
                        this.fileSizeInBites = attachment.fileSizeInBites;
                    },
                    clear: function () {
                        this.id = 0;
                        this.fileNameFull = '';
                        this.fileSizeInBites = 0;
                    }
                };

                $scope.attachmentDeleteClick = function (attachment) {
                    $scope.attachmentForDelete.init(attachment);
                    $scope.showingManager.showAttachmentDeleteForm();
                }

                $scope.deleteAttachment = function (id) {
                    var deletePromiseObj = attachmentsService.delete(id);

                    deletePromiseObj.then(function (response) {
                        $scope.attachments.removeItemById($scope.attachmentForDelete.id);
                        $scope.taskForEdit.attachmentCount--;
                        $scope.attachmentForDelete.clear();

                        alert("Deleted");

                        $scope.showingManager.showEditTaskForm();
                    });
                }



            }
        }
    });

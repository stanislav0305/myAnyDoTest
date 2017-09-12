angular.module('attachment').directive('attachmentCreate',
    function (attachmentsService) {
        return {
            restrict: "E",
            templateUrl: 'app/views/attachment/create.html',
            link: function ($scope, $upload) {

                $scope.attachmentCreateClick = function () {
                    $scope.showingManager.showAttachmentCreateForm();
                }

                $scope.uploadFile = function () {

                    var fileInput = document.getElementById('fileInput');
                    if (fileInput.files.length === 0) {
                        alert('Please, select file!');
                        return;
                    }

                    var file = fileInput.files[0];

                    var formData = new FormData();
                    formData.append("taskId", $scope.taskForEdit.id);
                    formData.append("file", file);

                    attachmentsService.upload(formData)
                        .then(function (response) {

                            if (response.data) {
                                alert('Success, file uploaded');
                                $scope.attachments.addItem(response.data);
                                $scope.taskForEdit.attachmentCount++;
                            } else
                                alert('File uload error');

                            $scope.showingManager.showEditTaskForm();
                        }).catch(function (response) {
                            alert('File not uloaded!');
                        });
                }
            }
        }
    });

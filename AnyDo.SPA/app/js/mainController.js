angular.module('app')
    .controller('mainController', function ($scope) {

        $scope.showingManager = {
            editTaskCategory: {
                formVisible: true,
                formShow: function () {
                    this.formVisible = true;
                },
                formHide: function () {
                    this.formVisible = false;
                }
            },
            createTaskForm: {
                formVisible: false,
                formShow: function () {
                    this.formVisible = true;
                },
                formHide: function () {
                    this.formVisible = false;
                }
            },
            editTaskForm: {
                formVisible: false,
                formShow: function () {
                    this.formVisible = true;
                },
                formHide: function () {
                    this.formVisible = false;
                }
            },
            createSubTaskForm: {
                formVisible: false,
                formShow: function () {
                    this.formVisible = true;
                },
                formHide: function () {
                    this.formVisible = false;
                }
            },
            editSubTaskForm: {
                formVisible: false,
                formShow: function () {
                    this.formVisible = true;
                },
                formHide: function () {
                    this.formVisible = false;
                }
            },
            deleteSubTaskForm: {
                formVisible: false,
                formShow: function () {
                    this.formVisible = true;
                },
                formHide: function () {
                    this.formVisible = false;
                }
            },
            attachmentCreateForm: {
                formVisible: false,
                formShow: function () {
                    this.formVisible = true;
                },
                formHide: function () {
                    this.formVisible = false;
                }
            },
            attachmentDeleteForm: {
                formVisible: false,
                formShow: function () {
                    this.formVisible = true;
                },
                formHide: function () {
                    this.formVisible = false;
                }
            },

            showEditTaskCaregoryForm: function () {
                this.createTaskForm.formHide();
                this.editTaskForm.formHide();
                this.createSubTaskForm.formHide();
                this.editSubTaskForm.formHide();
                this.deleteSubTaskForm.formHide();
                this.attachmentCreateForm.formHide();
                this.attachmentDeleteForm.formHide();

                this.editTaskCategory.formShow();
            },
            showCreateTaskForm: function () {
                this.editTaskCategory.formHide();
                this.editTaskForm.formHide();
                this.createSubTaskForm.formHide();
                this.editSubTaskForm.formHide();
                this.deleteSubTaskForm.formHide();
                this.attachmentCreateForm.formHide();
                this.attachmentDeleteForm.formHide();

                this.createTaskForm.formShow();
            },
            showEditTaskForm: function () {
                this.editTaskCategory.formHide();
                this.createTaskForm.formHide();
                this.createSubTaskForm.formHide();
                this.editSubTaskForm.formHide();
                this.deleteSubTaskForm.formHide();
                this.attachmentCreateForm.formHide();
                this.attachmentDeleteForm.formHide();

                this.editTaskForm.formShow();
            },
            showCreateSubTaskForm: function () {
                this.editTaskCategory.formHide();
                this.editTaskForm.formHide();
                this.editSubTaskForm.formHide();
                this.createTaskForm.formHide();
                this.deleteSubTaskForm.formHide();
                this.attachmentCreateForm.formHide();
                this.attachmentDeleteForm.formHide();

                this.createSubTaskForm.formShow();
            },
            showEditSubTaskForm: function () {
                this.editTaskCategory.formHide();
                this.createTaskForm.formHide();
                this.createSubTaskForm.formHide();
                this.editTaskForm.formHide();
                this.deleteSubTaskForm.formHide();
                this.attachmentCreateForm.formHide();
                this.attachmentDeleteForm.formHide();

                this.editSubTaskForm.formShow();
            },
            showDeleteSubTaskForm: function () {
                this.editTaskCategory.formHide();
                this.createTaskForm.formHide();
                this.createSubTaskForm.formHide();
                this.editTaskForm.formHide();
                this.editSubTaskForm.formHide();
                this.attachmentCreateForm.formHide();
                this.attachmentDeleteForm.formHide();

                this.deleteSubTaskForm.formShow();
            },
            showAttachmentCreateForm: function () {
                this.editTaskCategory.formHide();
                this.createTaskForm.formHide();
                this.createSubTaskForm.formHide();
                this.editTaskForm.formHide();
                this.editSubTaskForm.formHide();
                this.attachmentDeleteForm.formHide();
                this.deleteSubTaskForm.formHide();

                this.attachmentCreateForm.formShow();
            },
            showAttachmentDeleteForm: function () {
                this.editTaskCategory.formHide();
                this.createTaskForm.formHide();
                this.createSubTaskForm.formHide();
                this.editTaskForm.formHide();
                this.editSubTaskForm.formHide();
                this.deleteSubTaskForm.formHide();
                this.attachmentCreateForm.formHide();

                this.attachmentDeleteForm.formShow();
            }
        }

    });

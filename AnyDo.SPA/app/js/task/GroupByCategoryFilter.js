angular.module('task')
    .filter('groupByCategory', function () {
        return function (collection, taskCategories) {

            var result = [];
            if (collection === null) return result;
            

            for (var i = 0; i < collection.length; i++) {
                var taskCategoryId = collection[i]['taskCategoryId'];
                var category = taskCategories.getById(taskCategoryId);
                
                if (result.indexOf(category) === -1) {
                    result.push(category);
                }
            }
            return result;
        }
    });
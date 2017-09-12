angular.module('task')
    .filter('isSomeday', function ($filter) {
        return function (tasks) {
            var fromDate = new Date();
            fromDate = new Date(fromDate.getFullYear(), fromDate.getMonth(), fromDate.getDate(), 0, 0, 0);

            var toDate = new Date();
            toDate.setDate(toDate.getDate() + 5);
            toDate = new Date(toDate.getFullYear(), toDate.getMonth(), toDate.getDate(), 0, 0, 0);

            result = [];
            for (var i = 0, len = tasks.length; i < len; i++) {
                makeUpTo = new Date(tasks[i].makeUpTo);
                makeUpTo = new Date(makeUpTo.getFullYear(), makeUpTo.getMonth(), makeUpTo.getDate(), 0, 0, 0);

                if (fromDate > makeUpTo || makeUpTo > toDate) {
                    result.push(tasks[i]);
                }
            }
            return result; 
        };
    });
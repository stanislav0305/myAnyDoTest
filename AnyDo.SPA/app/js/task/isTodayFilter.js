angular.module('task')
    .filter('isToday', function ($filter) {
        return function (tasks) {
            var today = $filter('date')(new Date(), 'yyyy-MM-dd');

            var filtredTasks = tasks.filter(function (item) {
                var date = $filter('date')(item.makeUpTo, 'yyyy-MM-dd');
                return (today === date); 
            });

            return filtredTasks;
        };
    });
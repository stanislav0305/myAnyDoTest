angular.module('task')
    .filter('isTomorrow', function ($filter) {
        return function (tasks) {
            var tomorrowDate = new Date();
            tomorrowDate.setDate(tomorrowDate.getDate() + 1);
            var tomorrow = $filter('date')(tomorrowDate, 'yyyy-MM-dd');

           
            var filtredTasks = tasks.filter(function (item) {
                var date = $filter('date')(item.makeUpTo, 'yyyy-MM-dd');
                return (tomorrow === date);
            });

            return filtredTasks;
        };
    });
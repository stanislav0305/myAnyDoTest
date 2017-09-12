
angular.module('navBar')
    .filter('navBarTopDateFormat', function ($filter) {
        return function (date) {
            var dayOfWeek = $filter('date')(date, 'EEEE');
            var month = $filter('date')(date, 'MMMM');
            var dayOfMonth = $filter('date')(date, 'd');

            return dayOfWeek + ', ' + month + ' ' + dayOfMonth;
    };
});
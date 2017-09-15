angular.module('task')
    .filter('dateToPrefString', function ($filter) {
        return function (date, prefFormat) {
            var format = prefFormat == 'DD/MM/YY' ? 'dd/MM/yy' : 'MM/dd/yy';
            return $filter('date')(date, format);;
        };
    });
angular.module('app').config(function ($routeProvider) {

    $routeProvider
        .when("/",
        {             
            templateUrl: "app/views/index.html",
            controller: "mainController"
        })
        .when("/app/views/taskCategory/index.html",
        {
            templateUrl: "app/views/index.html",
            controller: "mainController"
        })
        .otherwise({
            templateUrl: "/",
            controller: "mainController"
        });
});
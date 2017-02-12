var app = angular.module("Imibuza", ["ngRoute"]);
angular.module("ngMaterial", ["ng", "ngAnimate", "ngAria"]);

app.config(function($routeProvider, $locationProvider) {
    $routeProvider.when("/", {
        templateUrl: "Home/One",
        controller: "HomeController"
    });
    $locationProvider.html5Mode(true);
});

app.controller("HomeController", function ($scope, $location) {

});
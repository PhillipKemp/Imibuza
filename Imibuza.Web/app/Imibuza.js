var app = angular.module("Imibuza", ["ngRoute"]);
angular.module("ngMaterial", ["ng", "ngAnimate", "ngAria"]);

app.config(function($routeProvider, $locationProvider) {
    $routeProvider.when("/", {
        templateUrl: "Home/One",
        controller: "HomeController"
    });

    $routeProvider.when("/YouAreNowCreatingAQuiz", {
        templateUrl: "Home/Two",
        controller: "CreateQuizController"
    });

    $routeProvider.when("/ReadySetGoQuiz", {
        templateUrl: "Home/Three",
        controller: "DoQuizController"
    });

    $locationProvider.html5Mode(true);
});

app.controller("HomeController", function ($scope, $location) {
    $scope.createQuiz = function createQuiz() {
        $location.path("/YouAreNowCreatingAQuiz");
    };

    $scope.doQuiz = function doQuiz() {
        $location.path("/ReadySetGoQuiz");
    }
});

app.controller("CreateQuizController", function ($scope, $http) {
    $scope.newQuestion = {
        question : "",
        correctAnswer : "",
        firstWrongAnswer : "",
        secondWrongAnswer : "",
        thirdWrongAnswer : ""
    }

    $scope.categories = [
        {name : "Biology"},
        {name : "Archeology"},
        {name : "Technology"}
    ];

    $scope.addAnother = function () {
        $http.post("Home/CreateQuestion", { model: $scope.newQuestion }).error(function (response) {

        });
    }

    $scope.addOne = function () {
        $http.post("Home/CreateQuestion", { model: $scope.newQuestion }).error(function (response) {

        });
    }
});

app.controller("DoQuizController", function ($scope, $location) {

});
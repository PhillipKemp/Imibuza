var app = angular.module("Imibuza",
    [
        "ngRoute",
        "ngSanitize",
        "directives",
        "ui.router",
        "angular-timeline"
    ]
);



app.config(function($routeProvider, $locationProvider) {
    $routeProvider.when("/", {
        templateUrl: "Home/One",
    });

    $routeProvider.when("/YouAreNowCreatingAQuiz", {
        templateUrl: "Home/Two",
    });

    $routeProvider.when("/ReadySetGoQuiz", {
        templateUrl: "Home/Three",
    });

    $locationProvider.html5Mode(true);
});

app.controller("HomeController", function ($scope, $location, $http) {
    $scope.createQuiz = function createQuiz() {
        $location.path("/YouAreNowCreatingAQuiz");
    };

    $scope.doQuiz = function doQuiz() {
        $location.path("/ReadySetGoQuiz");
    }

    $scope.events = [];

    $scope.strengths = [];
    $scope.weaknesses = [];

    $scope.init = function() {
        $http.post("Dashboard/GetTimeline", {}).then(function (response) {
            $scope.events = response.data.Entries;
        });

        $http.post("Dashboard/GetProfile", {}).then(function (response) {
            $scope.strengths = response.data.Strengths;
            $scope.weaknesses = response.data.Weaknesses;
        });

    }

    $scope.init();
});

app.controller("CreateQuizController", function ($scope, $http, $location) {

    $scope.loading = false;
    $scope.categories = [];

    $scope.newQuestion = {
        question: "",
        correctAnswer: "",
        firstWrongAnswer: "",
        secondWrongAnswer: "",
        thirdWrongAnswer: "",
        selectedCategory: ""
    };

    $scope.reset = function() {
        $scope.newQuestion = {
            question: "",
            correctAnswer: "",
            firstWrongAnswer: "",
            secondWrongAnswer: "",
            thirdWrongAnswer: "",
            selectedCategory: ""
        };
    }

    $scope.addAnother = function () {
        $http.post("Question/Create", { model: $scope.newQuestion }).then(function (response) {
            $scope.reset();
        });
    }

    $scope.addOne = function () {
        $http.post("Question/Create", { model: $scope.newQuestion }).then(function (response) {
            $location.path("/");
        });
    }

    $scope.init = function() {
        $http.post("Question/GetCategories", {}).then(function (response) {
            $scope.categories = response.data;
        });
    }

    $scope.init();
});

app.controller("DoQuizController",
    function ($scope, $location, $http, $timeout) {
        $scope.loading = true;
        $scope.quiz = {};
        $scope.result = "";

        $scope.reset = function () {
            $scope.loading = true;
            $timeout(function () {
                $http.post("Question/GetNext", {}).then(function (response) {
                    $scope.quiz = response.data;
                    $scope.loading = false;
                });
            }, 1000);


           
        }

        $scope.submitAnswer = function (data) {
            $scope.loading = true;
            $http.post("Question/SubmitAnswer", { Id: $scope.quiz.Id, Answer: data }).then(function (response) {

                $scope.reset();
            });
        }

        $scope.cancel = function() {
            $location.path("/");
        }

        $scope.initController = function () {
            $scope.reset();
        }

        $scope.initController();
    });

angular.module("directives", []).directive("selection",
    function() {
        return {
            restrict: 'E',
            scope: {
                answer: '=',
                source: '=',
                submit: "&"
            },

            template: "<div class='option'>{{answer}}</div>",
            link: function (scope, element, attrs) {
                element.bind('click', function (e) {
                    scope.submit();
                });

            },
            controller: function($scope) {
                //console.log($scope.answer.text);
            }
        }
    });
   

//template = '<div  ng-click="$parent.toggleAnswers(answer)">{{answer.text}}</div>';




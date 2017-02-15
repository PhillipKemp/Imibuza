var app = angular.module("Imibuza",
    [
        "ngRoute",
        "directives"
    ]
);



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
        var result = $http.post("Home/CreateQuestion", { model: $scope.newQuestion }).then(function (response) {

            var x = response;

        });
    }

    $scope.addOne = function () {
        var result = $http.post("Home/CreateQuestion", { model: $scope.newQuestion }).then(function (response) {

            var x = response;

        });
    }

    $scope.init = function() {
        
    }

    $scope.init();
});

app.controller("DoQuizController",
    function ($scope, $location, $http) {

        $scope.quiz = {
            category : "Politics",
            question : "Who was the 10th US president?",
            answers : [
            { text: "Donald Trump", checked: false },
            { text: "Aliens", checked: false },
            { text: "Bill Bob Thornton", checked: false },
            { text: "ALloy Wheels", checked: false }]
        }

        $scope.result = "";

        $scope.reset = function() {
            var result = $http.post("Question/GetNext", {}).then(function (response) {

              

            });
        }

        $scope.submitAnswer = function () {
            var result = $http.post("Question/SubmitAnswer", {}).then(function (response) {
                //if (response)
                    //$scope.result = "Correct!";
                //else
                    //$scope.result = "Wrong!";
            });
        }

        $scope.cancel = function() {
            $location.path("/");
        }

        $scope.init = function () {
            alert("init");
        }

        $scope.init();
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

            template: "<div class='option'>{{answer.text}}</div>",
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




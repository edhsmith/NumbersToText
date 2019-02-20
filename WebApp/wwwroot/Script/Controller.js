var app = angular.module("AKQA",[]);

var mainController = function ($scope, $http) {

    $scope.enteredName = "";
    $scope.enteredNumber = "";
    $scope.numberWords = "ZERO DOLLAR AND ZERO CENT";

    $scope.Load = function () {

        if ($scope.myForm.txtAmount.$error.pattern) return;
        var enteredNumber = $scope.enteredNumber;

        if (enteredNumber != "") {
            var uri = "http://localhost:53817/api/Numbers/ToWords?number=" + enteredNumber.toString();

            $http.get(uri).then(
                function (response) {
                    $scope.numberWords = response.data;
                },
                function (response) {
                    $scope.status = response.status;
                    $scope.statusClass = "alert alert-danger";
                }
            );
        }
        else {
            $scope.numberWords = "ZERO DOLLAR AND ZERO CENT";
        }
    };    
}


app.controller("mainController", mainController);
var app = angular.module("AKQA",[]);

var mainController = function ($scope, $http) {

    $scope.enteredName = "";
    $scope.enteredNumber = 0;

    $scope.checkNumber = function () {
        var exp = "^\d\d{0,}(\.?\d{0,2})";
        
    }


    $scope.Load = function () {
        $scope.status = "Calling Web Service";
        $scope.statusClass = "alert alert-primary";
        

        $http.get("/api/PetOwner/GetAll?token=AAAB34059607NBF").then(
            function (response) {
                $scope.status = response.status;
                var data = response.data;
                $scope.statusClass = "alert alert-primary";

                if (data.constructor == Array) {
                    var male = [];
                    var female = [];
                    var owner ;
                    for (var i = 0; i < data.length; i++) {
                        owner = data[i];

                        if (owner.gender == "Male") {
                            if (owner.pets != null) {
                                for (var j = 0; j < owner.pets.length; j++) {
                                    male.push(owner.pets[j].name);
                                }
                            }
                        } else {
                            if (owner.pets != null) {
                                for (var j = 0; j < owner.pets.length; j++) {
                                    female.push(owner.pets[j].name);
                                }
                            }
                        }
                    }
                    $scope.male = male.sort();
                    $scope.female = female.sort();
                }
            },
            function (response) {
                $scope.status = response.status;
                $scope.statusClass = "alert alert-danger";
            }

        );


    };

    
}


app.controller("mainController", mainController);
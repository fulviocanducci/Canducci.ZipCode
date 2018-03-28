var app = angular.module('app', ['ngRoute']);
var focus = function (element) {
    document.getElementById(element).focus();
}
app.config(function ($routeProvider, $locationProvider) {
    $routeProvider
        .when('/', {
            templateUrl: 'template/zipcode.html',
            controller: 'zipCodeCtrl'
        })
        .when('/address', {
            templateUrl: 'template/address.html',
            controller: 'addressCtrl'
        })
        .otherwise({
            redirectTo: '/'
        });
});

app.controller("zipCodeCtrl", ["$scope", "$location", "$http", function ($scope, $location, $http) {
    $scope.zip = "19200000";    
    $scope.modelInit = function () {
        return {
            'cep': '',
            'logradouro': '',
            'bairro': '',
            'localidade': '',
            'uf': '',
            'ibge': '',
            'complemento': '',
            'gia': ''
        };
    };
    $scope.find = function () {
        $http({
            url: '/zipcode',
            method: "POST",
            data: { 'zip': $scope.zip },
        }).then(function (response) {
            $scope.model = response.data;
            console.log($scope.model);
        }, function (response) {
            console.log('Error');
            console.log(response);
        });
    };
    $scope.clear = function () {
        $scope.model = $scope.modelInit();
        $scope.zip = '';
    }
    $scope.clear();
}]);

app.controller("addressCtrl", ["$scope", "$location", "$http", function ($scope, $location, $http) {
    
}]);
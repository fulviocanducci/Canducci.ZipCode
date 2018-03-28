var app = angular.module('app', ['ngRoute']);
var focus = function (element) {
    document.getElementById(element).focus();
}
app.run(function ($rootScope, $http) {
    $rootScope.ufs = [];
    $rootScope.ufLoad = function () {
        $http({
            url: '/uftolist',
            method: "POST",
            data: { },

        }).then(function (response) {
            $rootScope.ufs = response.data;  
            console.log($rootScope.ufs);
        }, function (response) {
            console.log('Error');
            console.log(response);
        });
    }
    $rootScope.ufLoad();
});

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
        focus("zip")
    }
    $scope.clear();
}]);

app.controller("addressCtrl", ["$scope", "$location", "$http", "$rootScope", function ($scope, $location, $http, $rootScope) {
    $scope.model = {};
    $scope.items = [];
    $scope.modelInit = function () {
        $scope.model = { 'uf': { "name": "SP", "value": "SP" }, 'city': '', 'address': '' };
    }
    $scope.modelInit();
    $scope.clear = function () {
        $scope.modelInit();
        focus("uf");
    }
    $scope.find = function () {
        $http({
            url: '/addresscode',
            method: "POST",
            data: { 'uf': $scope.model.uf.value, 'city': $scope.model.city, 'address': $scope.model.address },

        }).then(function (response) {
            $scope.items = response.data;
            console.log($scope.items);
        }, function (response) {
            console.log('Error');
            console.log(response);
        });
    };
}]);
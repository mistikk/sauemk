(function () {
    'use strict';

    angular
        .module('app')
        .controller('Account.Login.Controller', Login);

    Login.$inject = ['$scope', '$http'];

    function Login($scope, $http) {
        
        $scope.title = 'Login';
        var data;
        var accessToken;
        $scope.login = function () {
            console.info("user ", $scope.username);
            console.info("pass ", $scope.password);
            data = "grant_type=password&username=" + $scope.username + "&password=" + $scope.password;
            $http.post('http://localhost:17522/token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {
                accessToken = response.access_token;
                $scope.token = response.access_token;
                console.info("yesss", response);

            }).error(function (err, status) {
                console.info("noo", err);
            });
            
        }
        $scope.getValues = function () {
            console.log(getHeaders());
            $http.get('http://localhost:17522/api/values/', { headers: getHeaders() }).success(function (response) {
                $scope.values = response;
                console.info("yesss", response);

            }).error(function (err, status) {
                console.info("noo", err);
                console.info("header", getHeaders());
            });
        }
        function getHeaders() {
            if (accessToken) {
                return { "Authorization": "Bearer " + accessToken };
            }
        }
        activate();
    
        function activate() { }
    }
})();

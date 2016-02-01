(function () {
    'use strict';

    angular
        .module('app')
        .controller('Account.Login.Controller', Login);

    Login.$inject = ['$scope', '$http'];

    function Login($scope, $http) {
        $scope.title = 'Login';
        $scope.login = function () {
            console.info("user ", $scope.username);
            console.info("pass ", $scope.password);
            var data = {
                grant_type: 'password',
                username: $scope.username,
                password: $scope.password
            };
            console.info("data ", data);
            $http.post('http://localhost:17522/token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {

                console.info("yesss", response);

            }).error(function (err, status) {
                console.info("noo", err);
            });
            //$http({
            //    method: 'POST',
            //    url: 'http://localhost:17522/token',
            //    data: data
            //}).then(function successCallback(response) {
            //    console.log("yess");
            //}, function errorCallback(response) {
            //    console.log("nooooooooo");
            //});
            $scope.token = "sa";
        }
        activate();
    
        function activate() { }
    }
})();

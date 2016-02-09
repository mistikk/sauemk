(function () {
    'use strict';

    angular
        .module('app')
        .controller('Account.Login.Controller', Login);

    Login.$inject = ['$scope', '$location', 'authService', 'ngAuthSettings'];

    function Login($scope, $location, authService, ngAuthSettings) {

        $scope.loginData = {
            userName: "",
            password: "",
            useRefreshTokens: true
        };

        $scope.message = "";

        $scope.login = function () {

            authService.login($scope.loginData).then(function (response) {

                $location.path('/home');

            },
             function (err) {
                 $scope.message = err.error_description;
             });
        };
    }
})();

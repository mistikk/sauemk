(function () {
    'use strict';

    angular
        .module('app')
        .controller('Shared.LoginPartial.Controller', LoginPartial);

    LoginPartial.$inject = ['$scope', 'authService', '$location', 'localStorageService', '$timeout'];

    function LoginPartial($scope, authService, $location, localStorageService, $timeout) {

        $scope.authentication = {
            isAuth: false,
            username: ""
        }

        if (authService.authentication.isAuth == true) {
            $scope.authentication.isAuth = true;
            $scope.authentication.username = authService.authentication.userName;
        }

        

        $scope.logOff = function () {
            authService.logOut();
            $scope.authentication.isAuth = false;
            $location.path('/home');
        }

        $scope.register = function () {
            $location.path('/register');
        }

        $scope.login = function () {
            $location.path('/login');
        }

    }
})();

(function () {
    'use strict';

    angular
        .module('app')
        .controller('Shared.LoginPartial.Controller', LoginPartial);

    LoginPartial.$inject = ['$scope', 'authService', '$location'];

    function LoginPartial($scope, authService, $location) {
        
        $scope.logOff = function () {
            authService.logOut.then(function (response) {
                $location.path('/home');
            },
             function (err) {
                 sweetAlert("Hata..", "Beklenilmeyen bir hata oluştu...", "error");
             });
        }

        $scope.register = function () {
            $location.path('/register');
        }

        $scope.login = function () {
            $location.path('/login');
        }

    }
})();

(function () {
    'use strict';

    angular
        .module('app')
        .controller('Account.Login.Controller', Login);

    Login.$inject = ['$scope', '$location', 'authService', 'ngAuthSettings'];

    function Login($scope, $location, authService, ngAuthSettings) {

        $scope.loginData = {
            userName: "",
            Password: "",
            useRefreshTokens: true
        };

        $scope.message = "";

        $scope.login = function () {
            $scope.loading = true;
            authService.login($scope.loginData).then(function (response) {
                $location.path('/home');
                $scope.loading = false;
            },
             function (err) {
                 sweetAlert("Hata..", "Kullanıcı adı yada şifre hatalı..", "error");
                 $scope.loading = false;
             });
        };
    }
})();

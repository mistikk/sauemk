(function () {
    'use strict';

    angular
        .module('app')
        .controller('Account.Login.Controller', Login);

    Login.$inject = ['$scope', '$location', 'authService', 'ngAuthSettings', '$timeout'];

    function Login($scope, $location, authService, ngAuthSettings, $timeout) {
        
        $scope.loginData = {
            userName: "",
            password: "",
            useRefreshTokens: false
        };

        $scope.login = function () {

            authService.login($scope.loginData).then(function (response) {
                startTimer();
                console.log("Başarılı!");
                console.log(response)
            },
             function (err) {
                 console.log("Hatalı!");
                 $scope.message = err.error_description;
             });
        };
        var startTimer = function () {
            var timer = $timeout(function () {
                $timeout.cancel(timer);
                console.log($location.host());
                $location.path('/home/index');
                console.log("sa");
            }, 2000);
        }
    }

    
})();

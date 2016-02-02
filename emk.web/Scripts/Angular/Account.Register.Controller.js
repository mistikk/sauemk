(function () {
    'use strict';

    angular
        .module('app')
        .controller('Account.Register.Controller', Register);

    Register.$inject = ['$scope', '$location', '$timeout', 'authService'];

    function Register($scope, $location, $timeout, authService) {
        $scope.savedSuccessfully = false;
        $scope.message = "";

        $scope.registration = {
            Email: "",
            password: "",
            confirmPassword: ""
        };

        $scope.register = function () {

            authService.saveRegistration($scope.registration).then(function (response) {

                $scope.savedSuccessfully = true;
                $scope.message = "User has been registered successfully, you will be redicted to login page in 2 seconds.";
                startTimer();
            },
             function (response) {
                 var errors = [];
                 for (var key in response.data.modelState) {
                     for (var i = 0; i < response.data.modelState[key].length; i++) {
                         errors.push(response.data.modelState[key][i]);
                     }
                 }
                 $scope.message = "Failed to register user due to:" + errors.join(' ');
             });
        };

        var startTimer = function () {
            var timer = $timeout(function () {
                $timeout.cancel(timer);
                $location.path('/index');
                console.log("sa");
            }, 2000);
        }
    }
})();

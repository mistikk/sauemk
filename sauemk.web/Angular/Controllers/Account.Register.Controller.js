(function () {
    'use strict';

    angular
        .module('app')
        .controller('Account.Register.Controller', Register);

    Register.$inject = ['$scope', '$location', '$http'];

    function Register($scope, $location, $http) {
        $scope.regisData = {
            Email: "",
            Password: "",
            ConfirmPassword: ""
        };
        $scope.loading = false
        $scope.register = function () {
            $scope.loading = true;
            $http.post('account/register', $scope.regisData).then(function (response) {
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

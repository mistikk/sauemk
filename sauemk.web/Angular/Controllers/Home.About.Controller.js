(function () {
    'use strict';

    angular
        .module('app')
        .controller('Home.About.Controller', About);

    About.$inject = ['$scope', '$http'];

    function About($scope, $http) {
        $scope.title = 'Mehmet Çükürük';

        $scope.Cukuruk = function (sa) {

            $scope.message = "Tıklama demedim mi sana. bak bunu yazmışın => " + sa;
        };

        $scope.getNumber = function () {

            $http.get('home/numbers').then(function (response) {
                $scope.numbers = response.data;
            });
        };
    }
})();

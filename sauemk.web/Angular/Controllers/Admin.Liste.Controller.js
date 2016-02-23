(function () {
    'use strict';

    angular
        .module('app')
        .controller('Admin.Liste.Controller', Admin);

    Admin.$inject = ['$scope', '$location', '$http']; 

    function Admin($scope, $location, $http) {

        $scope.control = function () {
            $http.get('admin/control');
        }

        $scope.etkinlikEkle = function () {
            $location.path('etkinlikekle');
        };
    }
})();

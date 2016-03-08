(function () {
    'use strict';

    angular
        .module('app')
        .controller('Admin.Liste.Controller', Admin);

    Admin.$inject = ['$scope', '$location']; 

    function Admin($scope, $location) {

        $scope.etkinlikEkle = function () {
            $location.path('etkinlikekle');
        };
    }
})();

(function () {
    'use strict';

    angular
        .module('app')
        .controller('Shared.Layout.Controller', Layout);

    Layout.$inject = ['$scope', '$location']; 

    function Layout($scope, $location) {
        $scope.goEtkinlikPage = function () {
            $location.path('/etkinlik');
        }
    }
})();

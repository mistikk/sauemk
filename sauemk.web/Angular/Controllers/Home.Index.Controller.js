(function () {
    'use strict';

    angular
        .module('app')
        .controller('Home.Index.Controller', Home);

    Home.$inject = ['$scope', '$location']; 

    function Home($scope, $location) {
        // slider settings object set to scope.

        $scope.goRegister = function () {
            console.log("ss");
            $location.path('/register');
        };
    };
})();

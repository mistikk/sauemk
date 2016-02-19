(function () {
    'use strict';

    angular
        .module('app')
        .controller('Admin.Index.Controller', Admin);

    Admin.$inject = ['$scope', '$http']; 

    function Admin($scope, $http) {

        $scope.control = function () {
            $http.get('admin/control');
        }

    }
})();

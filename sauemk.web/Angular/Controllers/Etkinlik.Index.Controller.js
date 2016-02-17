(function () {
    'use strict';

    angular
        .module('app')
        .controller('Etkinlik.Index.Controller', Etkinlik);

    Etkinlik.$inject = ['$scope']; 

    function Etkinlik($scope) {
        $scope.title = 'Etkinlik';

        activate();

        function activate() { }
    }
})();

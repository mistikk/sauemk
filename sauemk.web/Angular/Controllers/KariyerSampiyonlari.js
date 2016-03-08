(function () {
    'use strict';

    angular
        .module('app')
        .controller('KariyerSampiyonlari', KariyerSampiyonlari);

    KariyerSampiyonlari.$inject = ['$scope']; 

    function KariyerSampiyonlari($scope) {
        $scope.title = 'KariyerSampiyonlari';

        activate();

        function activate() { }
    }
})();

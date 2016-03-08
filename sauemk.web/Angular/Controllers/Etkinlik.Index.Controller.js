(function () {
    'use strict';

    angular
        .module('app')
        .controller('Etkinlik.Index.Controller', Etkinlik);

    Etkinlik.$inject = ['$scope', '$http']; 

    function Etkinlik($scope, $http) {
        
        $scope.getEtkinlik = function () {
            $http.get("etkinlik/getetkinlik").then(function (response) {
                $scope.gecmisEtkinlik = response.data.gecmis.data
                $scope.gelecekEtkinlik = response.data.gelecek.data
                $scope.buHaftaEtkinlik = response.data.buHafta.data
                console.log(response.data.buHafta.data);
                console.log(response.data.gecmis);
                console.log(response.data.gelecek);
            });
        }
    }
})();

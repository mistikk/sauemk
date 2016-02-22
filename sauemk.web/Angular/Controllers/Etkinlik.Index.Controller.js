(function () {
    'use strict';

    angular
        .module('app')
        .controller('Etkinlik.Index.Controller', Etkinlik);

    Etkinlik.$inject = ['$scope', '$http', '$location']; 

    function Etkinlik($scope, $http, $location) {
        
        $scope.getEtkinlik = function () {
            $http.get("etkinlik/getetkinlik").then(function (response) {
                $scope.gecmisEtkinlik = response.data.gecmis.data
                $scope.gelecekEtkinlik = response.data.gelecek.data
                $scope.buHaftaEtkinlik = response.data.buHafta.data
                console.log(response.data.buHafta.data);
                console.log(response.data.gecmis);
                console.log(response.data.gelecek);
            });
        };

        $scope.goEtkinlik = function (id) {
            $location.path('/etkinlik/'+ id);
        };
    }
})();

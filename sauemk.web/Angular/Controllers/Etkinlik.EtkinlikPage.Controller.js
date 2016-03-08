(function () {
    'use strict';

    angular
        .module('app')
        .controller('Etkinlik.EtkinlikPage.Controller', Etkinlik);

    Etkinlik.$inject = ['$scope', '$routeParams', '$http', 'authService'];

    function Etkinlik($scope, $routeParams, $http, authService) {

        var date = new Date();
        $scope.buttonShow = true;
        $scope.etkinlik = "";
        $scope.buttonMessage = "Katıl";
        $scope.buttonClass = "btn-info"
        $scope.requestData = {
            userName: authService.authentication.userName,
            etkinlikId: $routeParams.id
        }

        $scope.getDetail = function () {
            $http.get("etkinlik/Etkinlik/" + $scope.requestData.etkinlikId).then(function (response) {
                $scope.etkinlik = response.data.data;
                var etkinlikTarihi = new Date($scope.etkinlik.Tarihi);
                if (etkinlikTarihi < date) {
                    $scope.buttonShow = false;
                }
            });
        };
        
        $scope.etkinlikKayit = function () {
            $scope.buttonMessage = "";
            $scope.loading = true;
            $http.post("etkinlik/EtkinlikKayit/", $scope.requestData).then(function (response) {
                console.log(response.data.data);
                $scope.loading = false;
                $scope.buttonClass = "btn-success"
                $scope.buttonMessage = "Kayıt Edildi";
            });
        };
    }
})();

(function () {
    'use strict';

    angular
        .module('app')
        .controller('Etkinlik.HizliKayit.Controller', HizliKayit);

    HizliKayit.$inject = ['$scope', '$http'];

    function HizliKayit($scope, $http) {
        $scope.regisData = {
            Email: "",
            Name: "",
            Surname: "",
            Phone: "",
            EtkinlikId: 6
        };

        $scope.loading = false
        $scope.register = function () {

            $scope.loading = true;
            $http.post('etkinlik/HizliKaydet', $scope.regisData).then(function (response) {
                $scope.loading = false;
                swal("Good job!", "Kişi Başarıyla Kaydedildi", "success")
                $scope.regisData.Email = "";
                $scope.regisData.Name = "";
                $scope.regisData.Surname = "";
                $scope.regisData.Phone = "";
            },
             function (err) {
                 sweetAlert("Hata..", "Kullanıcı adı yada şifre hatalı..", "error");
                 $scope.loading = false;
                 $scope.regisData.Email = "";
                 $scope.regisData.Name = "";
                 $scope.regisData.Surname = "";
                 $scope.regisData.Phone = "";
             });
        };
    };
})();

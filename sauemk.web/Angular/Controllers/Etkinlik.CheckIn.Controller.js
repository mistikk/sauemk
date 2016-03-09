(function () {
    'use strict';

    angular
        .module('app')
        .controller('Etkinlik.CheckIn.Controller', CheckIn);

    CheckIn.$inject = ['$scope', '$http', 'authService', '$routeParams'];

    function CheckIn($scope, $http, authService, $routeParams) {

        $scope.btnClass = "btn-info"
        $scope.searchData = {
            Name: "",
            Surname: ""
        };
        
        $scope.loading = false;
        $scope.search = function () {
            $scope.loading = true;
            $http.post('etkinlik/SearchUser', $scope.searchData).then(function (response) {
                $scope.loading = false;
                $scope.users = response.data.data;
                console.log($scope.users);
                $scope.searchData.Name = "";
                $scope.searchData.Surname = "";
            },
             function (err) {
                 sweetAlert("Hata..", "Kayıt bulunamadı", "error");
                 $scope.loading = false;
                 $scope.searchData.Name = "";
                 $scope.searchData.Surname = "";
             });
        };

        $scope.requestData = {
            userName: "",
            etkinlikId: 6,
            checkin: true
        };
        
        $scope.checkin = function (email) {
            $scope.requestData.userName = email;
            console.log($scope.requestData);
            $scope.loading = true;
            $http.post("etkinlik/EtkinlikCheckin/", $scope.requestData).then(function (response) {
                swal("Good job!", "Kişi Başarıyla Kaydedildi", "success")
                $scope.loading = false;
                $scope.btnClass = "btn-success"
                $scope.buttonMessage = "Kayıt Edildi";
            },
             function (err) {
                 sweetAlert("Hata..", "Bilinmeyen bir hata oluştu", "error");
                 $scope.loading = false;
             });
        };
    }
})();

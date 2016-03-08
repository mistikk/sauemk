(function () {
    'use strict';

    var app = angular.module('app', ['ngRoute', 'LocalStorageModule']);

    app.config(function ($routeProvider) {

        $routeProvider.when("/home", {
            controller: "",
            templateUrl: "Home/Master"
        });
        $routeProvider.when("/login", {
            controller: "Account.Login.Controller",
            templateUrl: "Account/Login"
        });
        $routeProvider.when("/register", {
            controller: "Account.Register.Controller",
            templateUrl: "Account/Register"
        });
        $routeProvider.when("/about", {
            controller: "Home.About.Controller",
            templateUrl: "Home/About"
        });

        $routeProvider.when("/etkinlik", {
            controller: "Etkinlik.Index.Controller",
            templateUrl: "Etkinlik/Index"
        });

        $routeProvider.when("/admin", {
            controller: "Admin.Liste.Controller",
            templateUrl: "Admin/Liste"
        });

        $routeProvider.when("/etkinlikekle", {
            controller: "Admin.EtkinlikEkle.Controller",
            templateUrl: "Admin/EtkinlikEkle"
        });

        $routeProvider.otherwise({ redirectTo: "/home" });

    });

    var serviceBase = 'http://localhost:4242/';
    //var serviceBase = 'http://ngauthenticationapi.azurewebsites.net/';
    app.constant('ngAuthSettings', {
        apiServiceBaseUri: serviceBase,
        clientId: 'ngAuthApp'
    });

    app.config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptorService');
    });

    app.run(['authService', function (authService) {
        authService.fillAuthData();
    }]);


})();
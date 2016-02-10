(function () {
    'use strict';

    var app = angular.module('app', ['ngRoute', 'LocalStorageModule']);

    app.config(function ($routeProvider) {

        console.log("sa");

        $routeProvider.when("/login", {
            controller: "Account.Login.Controller",
            templateUrl: "Account/Login"
        });
        $routeProvider.when("/register", {
            controller: "",
            templateUrl: "Account/Register"
        });
        $routeProvider.when("/about", {
            controller: "Home.About.Controller",
            templateUrl: "Home/About"
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
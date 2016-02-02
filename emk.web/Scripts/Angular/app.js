(function () {
    'use strict';

    var app = angular.module('app', ['ngRoute', 'LocalStorageModule']);

    var serviceBase = 'http://localhost:17522/';

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

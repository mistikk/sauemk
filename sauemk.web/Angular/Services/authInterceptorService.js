(function () {
    'use strict';

    angular
        .module('app')
        .factory('authInterceptorService', authInterceptorService);

    authInterceptorService.$inject = ['$q', '$injector', '$location', 'localStorageService'];

    function authInterceptorService($q, $injector, $location, localStorageService) {
        var authInterceptorServiceFactory = {};

        var _request = function (config) {

            config.headers = config.headers || {};

            var authData = localStorageService.get('authorizationData');
            console.info("authData", authData);
            if (authData) {
                config.headers.Authorization = 'Bearer ' + authData.token;
            }
            console.info("config", config);
            return config;
        }

        var _responseError = function (rejection) {
            console.log("1");
            if (rejection.status === 403) {
                console.log("2");
                var authService = $injector.get('authService');
                var authData = localStorageService.get('authorizationData');
                console.log("3");
                //if (authData) {
                //    if (authData.useRefreshTokens) {
                //        $location.path('/refresh');
                //        return $q.reject(rejection);
                //    }
                //}
                console.log("4");
                authService.logOut();
                $location.path('/login');
            }
            return $q.reject(rejection);
        }

        authInterceptorServiceFactory.request = _request;
        authInterceptorServiceFactory.responseError = _responseError;

        return authInterceptorServiceFactory;
    }
})();
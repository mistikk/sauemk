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

            if (authData) {
                config.headers.Authorization = 'Bearer ' + authData.token;
            }

            return config;
        }
        var _response = function (response) {
            if (response.data.error == "BadRequest") {
                response.status = 400;
                response.statusText = "BadRequest";
                return $q.reject(response);
            }
            if (response.data.error == "Model is not valid") {
                response.status = 411;
                response.statusText = "Model is not valid";
                return $q.reject(response);
            }
            if (response.data.error == "Unauthorized") {
                response.status = 401;
                response.statusText = "Unauthorized";
                var authService = $injector.get('authService');
                var authData = localStorageService.get('authorizationData');
                authService.logOut();
                $location.path('/login');
                return $q.reject(response);
            }
            return response
        }

        var _responseError = function (rejection) {

            if (rejection.status === 403) {

                var authService = $injector.get('authService');
                var authData = localStorageService.get('authorizationData');
                authService.logOut();
                $location.path('/login');
            }
            return $q.reject(rejection);
        }

        authInterceptorServiceFactory.request = _request;
        authInterceptorServiceFactory.responseError = _responseError;
        authInterceptorServiceFactory.response = _response;

        return authInterceptorServiceFactory;
    }
})();
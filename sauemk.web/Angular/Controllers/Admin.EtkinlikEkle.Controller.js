(function () {
    'use strict';

    angular
        .module('app')
        .controller('Admin.EtkinlikEkle.Controller', EtkinlikEkle);

    EtkinlikEkle.$inject = ['$scope', '$log'];

    function EtkinlikEkle($scope, $log) {

    	$('.datepicker').datepicker();
    	var self = this;

    	self.dzAddedFile = function (file) {
    		console.log("1");
    		$log.log(file);
    	};

    	self.dzError = function (file, errorMessage) {
    		$log.log(errorMessage);
    		console.log("2");
    	};

    	$scope.sa = function () {
    		console.log("sa");
    		console.log($scope.file);
    	}

    	self.dropzoneConfig = {
    		parallelUploads: 3,
    		maxFileSize: 30
    	};
    }
})();

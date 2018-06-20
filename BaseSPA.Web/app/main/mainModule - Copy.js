﻿(function(window, angular) {
  'use-strict';
  angular.module('mainModule', ['ui.router', 'blogsModule', 'postsModule'])
    .config(function ($stateProvider/*, $perddio*/) {
        var mainState = {
          name: 'home',
          url: '/home',
          views: {
            'header': { templateUrl: 'app/header/header.html' },
            'main': { templateUrl: 'app/main/main.html', controller: 'mainCtrl' }
          }
        }

			$stateProvider.state(mainState);
		  //$perddio.state(mainState);
	  })
    .controller('mainCtrl', function ($scope, $state) {
			$scope.$state = $state;
		  //$scope.$ciccio = $state;
      });
})(window, window.angular)
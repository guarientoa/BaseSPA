(function(window, angular) {
  'use-strict';
	angular.module('mainModule', ['ui.router', 'surveyModule', 'questionModule'])//, 'answerModule'])
    .config(function ($stateProvider) {
			$stateProvider
				.state('home',
			  {
				  url: '/home',
				  views: {
					  'header': { templateUrl: 'app/header/header.html' },
					  'main': { templateUrl: 'app/main/main.html', controller: 'mainCtrl' }
				  }
			  });
	  })
    .controller('mainCtrl', function ($scope, $state) {
			$scope.$state = $state;
      });
})(window, window.angular)
(function (window, angular) {
  'use-strict';
  angular.module('surveyModule', ['ui.router'])
    .config(function ($stateProvider) {
        $stateProvider
          .state('home.survey',
          {
            url: '/survey',
						//templateUrl: 'app/main/blogs/blogs.html',
            views: {
							'content': { templateUrl: 'app/main/survey/surveys.html', controller: 'surveysCtrl' }/*,
	            'main': { templateUrl: 'app/main/main.html', controller: 'mainCtrl' }*/
            }
            //controller: 'blogsCtrl'
          })
          .state('home.survey.detail',
          {
						url: '/survey/:id',
						views: {
							'content': { templateUrl: 'app/main/survey/survey.html', controller: 'surveysDetailCtrl' }
						}
          });
      })
    .factory('surveysService', function ($http) {
      return {
        list: function () {
          return $http.get("/odata/Surveys");
        },
        detail: function (id) {
          return $http.get("/odata/Surveys(Id'" + id + "')");
        },
        create: function (survey) {
          var req = {
            method: 'POST',
            url: '/odata/Surveys',
            headers: {
              'Content-Type': 'application/json'
            },
            data: survey
          };

          return $http(req);
        },
				save: function (survey) {
          var req = {
            method: 'PATCH',
						url: '/odata/Surveys(Id\'' + survey.Id + '\')',
            headers: {
              'Content-Type': 'application/json'
            },
						data: survey
          };

          return $http(req);
        },
        delete: function (id) {
          return $http.delete("/odata/Surveys(Id'" + id + "')");
        }
      }
    })
		.controller('surveysCtrl', function ($scope, $state, surveysService) {

      $scope.new = function() {
				$state.go("home.survey", { id: null });
      };

      $scope.detail = function(id) {
				$state.go("home.survey", { id: id });
      };

		  surveysService.list().then(function (result) {
        $scope.Surveys = result.data.value;
      });
    })
		.controller('surveysDetailCtrl', function ($scope, $state, $stateParams, surveysService) {

      $scope.save = function () {
				if ($scope.Survey.Id === undefined) {
					surveysService.create($scope.Survey).then(function (result) {
						$scope.Survey = result.data;
          });
        } else {
					surveysService.save($scope.Survey).then(function () {});
        };
      };

      $scope.delete = function() {
				surveysService.delete($scope.Survey.Id).then(function() {
					$state.go("home.survey");
        });
      }

      $scope.close = function () {
				$state.go("home.survey");
      };

      if ($stateParams.id === '') {
				$scope.Survey = { Title: '', Subtitle: '', Description: '' }  
      } else {
	      surveysService.detail($stateParams.id).then(function (result) {
					$scope.Survey = result.data;
        });  
      }
    });
})(window, window.angular);
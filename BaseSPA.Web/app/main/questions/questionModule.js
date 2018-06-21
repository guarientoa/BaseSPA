(function (window, angular) {
  'use-strict';
  angular.module('questionModule', ['ui.router', 'surveyModule', 'uiModule'])
    .config(['$stateProvider',
		  function ($stateProvider) {
				$stateProvider
					.state('home.question',
          {
						url: '/questions',
						views: {
							'content': { templateUrl: 'app/main/questions/questions.html', controller: 'questionsCtrl' }
						}
          })
          .state('home.questiondetail',
            {
							url: '/questions/:id',
							views: {
								'content': { templateUrl: 'app/main/questions/question.html', controller: 'questionsDetailCtrl' }
							}
            });
			}])
    .factory('questionsService', function ($http) {
      return {
        list: function () {
					return $http.get("/odata/Questions?$expand=Survey");
        },
        detail: function (id) {
          return $http.get("/odata/Questions(guid'" + id + "')");
        },
        create: function (question) {
          var req = {
            method: 'POST',
            url: '/odata/Questions',
            headers: {
              'Content-Type': 'application/json'
            },
            data: question
          };

          return $http(req);
        },
        save: function (question) {
          var req = {
            method: 'PATCH',
            url: '/odata/Questions(guid\'' + question.Id + '\')',
            headers: {
              'Content-Type': 'application/json'
            },
            data: question
          };

          return $http(req);
        },
        delete: function (id) {
          return $http.delete("/odata/Questions(guid'" + id + "')");
        }
      }
    })
    .controller('questionsCtrl', function ($scope, $state, questionsService) {
        $scope.new = function () {
          $state.go("home.questiondetail", { id: null });
        };

        $scope.detail = function (id) {
          $state.go("home.questiondetail", { id: id });
        };

        questionsService.list().then(function (result) {
          $scope.Questions = result.data.value;
        });
      })
		.controller('questionsDetailCtrl', function ($scope, $state, $stateParams, questionsService, surveysService) {

      $scope.save = function () {
        if ($scope.Question.Id === undefined) {
					questionsService.create($scope.Question).then(function (result) {
						$scope.Question = result.data;
          });
        } else {
					questionsService.save($scope.Question).then(function () { });
        };
      };

      $scope.delete = function () {
				questionsService.delete($scope.Question.Id).then(function () {
          $state.go("home.question");
        });
      }

      $scope.close = function () {
        $state.go("home.question");
      };

		  surveysService.list().then(function (result) {
				$scope.Surveys = result.data.value;
      });

      if ($stateParams.id === '') {
				$scope.Question = { QuestionText: '', Type: '' }
      } else {
        questionsService.detail($stateParams.id).then(function (result) {
					$scope.Question = result.data;
        });
      }
    });
})(window, window.angular);
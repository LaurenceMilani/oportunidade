
(function () {
    //Cria um Module 
    // será usado ['ng-Route'] quando implementarmos o roteamento
    var app = angular.module('MinutoSegurosApp', ['ngRoute', 'ngResource', 'ngSanitize','loadingStatus']);
    //Cria um Controller
    // aqui $scope é usado para compartilhar dados entre a view e o controller

    app.config(['$resourceProvider', function ($resourceProvider) {
        
        $resourceProvider.defaults.stripTrailingSlashes = false;
    }]);
    
    app.controller('HomeController', function ($scope, $resource, $http, $sanitize) {
        $scope.Mensagem = "Teste Minuto Seguros";

        $http.get('api/Feed/AvaliarFeed').success(function (data) {
            
            $scope.FeedInfo = data;

            console.log(data);
        });

        $scope.renderHtml = function (html_code) {
            return $sce.trustAsHtml(html_code);
        };


        //<p ng-bind-html="renderHtml(value.button)"></p> 


    });
})();
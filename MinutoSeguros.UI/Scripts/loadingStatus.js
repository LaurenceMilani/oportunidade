angular.module('loadingStatus', [])

.config(function ($httpProvider) {
    $httpProvider.interceptors.push('loadingStatusInterceptor');
})

.directive('loadingStatusMessage', function () {
    return {
        link: function ($scope, $element, attrs) {
            var show = function () {
                //console.log('loading show1');
                //$element.css('display', 'block');
                //$('#idDivLoading').show();
                $element.show();
            };
            var hide = function () {
                //console.log('loading hide1');
                //$element.css('display', 'none');
                //$('#idDivLoading').hide();
                $element.hide();
            };
            
            $scope.$on('loadingStatusActive', show);
            $scope.$on('loadingStatusInactive', hide);
            hide();
        }
    };
})

.factory('loadingStatusInterceptor', function ($q, $rootScope) {
    var activeRequests = 0;
    var started = function () {
        //console.log('teste S ' + activeRequests);
        if (activeRequests == 0) {            
            $rootScope.$broadcast('loadingStatusActive');
        }
        activeRequests++;
    };
    var ended = function () {
        //console.log('teste E ' + activeRequests);
        activeRequests--;
        if (activeRequests == 0) {
            $rootScope.$broadcast('loadingStatusInactive');
        }
    };
    return {
        request: function (config) {
            started();
            return config || $q.when(config);
        },
        response: function (response) {
            ended();
            return response || $q.when(response);
        },
        responseError: function (rejection) {
            ended();
            return $q.reject(rejection);
        }
    };
});
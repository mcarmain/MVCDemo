(function () {
    //=============================
    var app = angular.module('app', ['ngRoute']);
    var config = function ($routeProvider) {
        $routeProvider
            .when("/list",{templateUrl:"/client/views/list.html"})
            .when("/details/:id",
            {templateUrl:"/client/views/details.html" }).otherwise({redirectTo:"/list"});
    };
    app.config(config);
    
    app.controller('ListCtrl', function ($scope) {
        $scope.message = 'Hello World!';
    });
     //=============================
})();





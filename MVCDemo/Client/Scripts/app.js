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
        $scope.movies = [
            { Id: '1',Title:'Gone with the Wind',ReleaseYr:'1930',Runtime:'90' },
            { Id: '2',Title:'Ghostbusters', ReleaseYr: '1982', Runtime: '90' }
        ];
    }); 


    var DetailsController = function ($scope, $http, $routeParams) {
        var id = $routeParams.id;
        $http.get("/api/movie/" + id).success(function (data) { $scope.movie = data; });
    };
    app.controller('DetailsController',DetailsController);
     //=============================
})();





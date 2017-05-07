(function (app) {
var DetailsController = function ($scope, $http, $routeParams) {
    var id = $routeParams.id;
    $http.get("/api/movie/" + id).success(function (data) {
        $scope.movie = data;
    });
    app.controller(" DetailsController", DetailsController);
}(angular.module("app")));

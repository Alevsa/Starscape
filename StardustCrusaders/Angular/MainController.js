app.controller("MainController", function($scope)
{
    $scope.teamShown = false;
    $scope.ToggleTeamView = function()
    {
        $scope.teamShown = !$scope.teamShown;
    };
    $scope.gamesShown = false;
    $scope.ToggleGameView = function()
    {
        $scope.gamesShown = !$scope.gamesShown;
    };
});
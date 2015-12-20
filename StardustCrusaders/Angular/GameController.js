app.controller("GameController", function($scope) 
{
    var path = "GamePages/";
    
    $scope.Games =
    [
        {     name: "Space"
            , visible: false
            , url: "GamePages/Placeholder.html"
        }    
      , {     name: "Starscape"
            , visible: false
            , url: "GamePages/Placeholder.html"
        }
    ];
    
    $scope.ToggleGame = function(index)
    {
        for (var i = 0; i < $scope.Games; i++)
        {
            if (i === index)
            {
                $scope.Games[i].shown = true;
            }
            else
            {
                $scope.Games[i].shown = false;   
            }
        }  
    };
});
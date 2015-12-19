app.controller("TeamController", function($scope) 
{
    $scope.team =
    {
        Alex :
        {
            name : "Alex"
          , bio : "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam aliquet ac risus vel porta. Ut et tempor mauris. Aliquam molestie congue diam in sagittis. Integer et tellus ante. Morbi at volutpat magna. Integer laoreet, turpis vel mollis feugiat, elit tellus auctor lacus, sit amet dapibus massa eros tristique nunc. Sed sed enim vitae mauris egestas commodo. Nunc consequat vel risus eu tincidunt. Aenean nec turpis ut dui convallis tincidunt eget eu metus. Vestibulum consectetur mi feugiat tellus accumsan interdum. Aenean efficitur, lectus eu porta volutpat, lacus nisi egestas lorem, eget tristique elit risus a nisi.Nam viverra tortor nisl, a auctor ex efficitur ac. Proin maximus dignissim magna et auctor. Nam bibendum, justo pulvinar vulputate" 
          , imageUrl : "placeholder.gif"
        }
      , Sam :
        {
            name : "Sam"
          , bio : "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam aliquet ac risus vel porta. Ut et tempor mauris. Aliquam molestie congue diam in sagittis. Integer et tellus ante. Morbi at volutpat magna. Integer laoreet, turpis vel mollis feugiat, elit tellus auctor lacus, sit amet dapibus massa eros tristique nunc. Sed sed enim vitae mauris egestas commodo. Nunc consequat vel risus eu tincidunt. Aenean nec turpis ut dui convallis tincidunt eget eu metus. Vestibulum consectetur mi feugiat tellus accumsan interdum. Aenean efficitur, lectus eu porta volutpat, lacus nisi egestas lorem, eget tristique elit risus a nisi.Nam viverra tortor nisl, a auctor ex efficitur ac. Proin maximus dignissim magna et auctor. Nam bibendum, justo pulvinar vulputate" 
          , imageUrl : "placeholder.gif"
        }
      , Evgenny :
        {
            name : "Evgenny"
          , bio : "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam aliquet ac risus vel porta. Ut et tempor mauris. Aliquam molestie congue diam in sagittis. Integer et tellus ante. Morbi at volutpat magna. Integer laoreet, turpis vel mollis feugiat, elit tellus auctor lacus, sit amet dapibus massa eros tristique nunc. Sed sed enim vitae mauris egestas commodo. Nunc consequat vel risus eu tincidunt. Aenean nec turpis ut dui convallis tincidunt eget eu metus. Vestibulum consectetur mi feugiat tellus accumsan interdum. Aenean efficitur, lectus eu porta volutpat, lacus nisi egestas lorem, eget tristique elit risus a nisi.Nam viverra tortor nisl, a auctor ex efficitur ac. Proin maximus dignissim magna et auctor. Nam bibendum, justo pulvinar vulputate" 
          , imageUrl : "placeholder.gif"
        }
        /*
      , MrTest :
        {
            name : "Test"
          , bio : "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam aliquet ac risus vel porta. Ut et tempor mauris. Aliquam molestie congue diam in sagittis. Integer et tellus ante. Morbi at volutpat magna. Integer laoreet, turpis vel mollis feugiat, elit tellus auctor lacus, sit amet dapibus massa eros tristique nunc. Sed sed enim vitae mauris egestas commodo. Nunc consequat vel risus eu tincidunt. Aenean nec turpis ut dui convallis tincidunt eget eu metus. Vestibulum consectetur mi feugiat tellus accumsan interdum. Aenean efficitur, lectus eu porta volutpat, lacus nisi egestas lorem, eget tristique elit risus a nisi.Nam viverra tortor nisl, a auctor ex efficitur ac. Proin maximus dignissim magna et auctor. Nam bibendum, justo pulvinar vulputate" 
          , imageUrl : "placeholder.gif"
        }
      , MrTest1 :
        {
            name : "Test"
          , bio : "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam aliquet ac risus vel porta. Ut et tempor mauris. Aliquam molestie congue diam in sagittis. Integer et tellus ante. Morbi at volutpat magna. Integer laoreet, turpis vel mollis feugiat, elit tellus auctor lacus, sit amet dapibus massa eros tristique nunc. Sed sed enim vitae mauris egestas commodo. Nunc consequat vel risus eu tincidunt. Aenean nec turpis ut dui convallis tincidunt eget eu metus. Vestibulum consectetur mi feugiat tellus accumsan interdum. Aenean efficitur, lectus eu porta volutpat, lacus nisi egestas lorem, eget tristique elit risus a nisi.Nam viverra tortor nisl, a auctor ex efficitur ac. Proin maximus dignissim magna et auctor. Nam bibendum, justo pulvinar vulputate" 
          , imageUrl : "placeholder.gif"
        }
      , MrTest2 :
        {
            name : "Test"
          , bio : "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam aliquet ac risus vel porta. Ut et tempor mauris. Aliquam molestie congue diam in sagittis. Integer et tellus ante. Morbi at volutpat magna. Integer laoreet, turpis vel mollis feugiat, elit tellus auctor lacus, sit amet dapibus massa eros tristique nunc. Sed sed enim vitae mauris egestas commodo. Nunc consequat vel risus eu tincidunt. Aenean nec turpis ut dui convallis tincidunt eget eu metus. Vestibulum consectetur mi feugiat tellus accumsan interdum. Aenean efficitur, lectus eu porta volutpat, lacus nisi egestas lorem, eget tristique elit risus a nisi.Nam viverra tortor nisl, a auctor ex efficitur ac. Proin maximus dignissim magna et auctor. Nam bibendum, justo pulvinar vulputate" 
          , imageUrl : "placeholder.gif"
        }
        */
    };
    $scope.Debug = function()
    {
        console.log($scope.team);
    };
});
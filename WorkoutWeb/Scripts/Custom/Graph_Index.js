// Load the Visualization API and the piechart package.
google.load('visualization', '1.0', { 'packages': ['corechart'] });




var app = angular.module("graphApp", []);

app.controller("graphCtrl", function ($scope, $http) {

  //Variables
  $scope.pie = {};
  $scope.pies = [];
  $scope.chkPie = false;
  $scope.category = 1;
  $scope.updateMode = false;
  $scope.loadMode = false;
  $scope.status = "";

 

  function drawPie(data) {
    var t = "";
    if ($scope.category == 1) {
      t  = "Fruits";
    }
    else {
      t  = "Presidents";

    }
    var tdata = new google.visualization.DataTable();

    tdata.addColumn('string', 'Fruits');
    tdata.addColumn('number', 'Sales');
    for (var i = 0; i < data.length; i++) {
      tdata.addRow([data[i].Name, data[i].Value]);
    };
    //either pie or column
    if (!$scope.chkPie) {
      new google.visualization.ColumnChart(document.getElementById('myGraph')).
        draw(tdata, { title: t, is3D: true });
    }
    else {
      new google.visualization.PieChart(document.getElementById('myGraph')).
      draw(tdata, { title: t, is3D: true });

    }

  };

  $scope.$watch('chkPie', function (old, n) {
    $scope.updateScreen();
  });


  $scope.$watch('category', function (old, n) {
    console.log($scope.category);
    $scope.updateScreen();
  });
  
  $scope.updateScreen = function () {
    $scope.loadMode = true;
    $http({ method: "GET", url: "Graph/GetPieData/" + $scope.category }).
      success(function (data) {
        $scope.pies = data;
        drawPie(data);
        console.dir(data);
        $scope.loadMode = false;
      });
  };


  $scope.save = function () {
    $scope.loadMode = true;
    console.dir($scope.pie);
    $scope.pie.Category = $scope.category;
    $http({ method: 'POST', url: 'Graph/PostPieData', data: $scope.pie }).
        success(function (data, status, headers, config) {
          console.log("Success");
          console.dir(data);
          $scope.status = "Submitted..";
          $scope.pie = {};
          $scope.updateScreen();

        }).
error(function (data, status, headers, config) {
  console.log("Error");
  console.dir(data);
  $scope.status = data;

});
  };
  $scope.edit = function () {
    console.log(this.p);
    $scope.updateMode = true;
    $scope.pie = this.p;
  };

  $scope.cancelUpdate = function () {
    $scope.pie = {};
    $scope.updateMode = false;
  };

  $scope.update = function () {
    $scope.loadMode = true;

    console.log("Updating..");
    console.dir($scope.pie);
    $http({ method: "PUT", url: "Graph/UpdatePie/" + $scope.pie.PieValueId, data: $scope.pie }).
        success(function (data) {
          $scope.pie = {};
          $scope.updateMode = false;
          $scope.updateScreen();
          $scope.status = "Updated..";


        });

  };

  $scope.delete = function (id) {
    bootbox.confirm("Delete " + this.p.Name + " ?", function (result) {
      if (result) {
        $scope.loadMode = true;

        console.log(id);
        $http({ method: "DELETE", url: "Graph/DelPie/" + id }).
          success(function (data) {
            $scope.status = "Deleted..";
            $scope.updateScreen();

          });
      }
    });

  };

  $scope.updateScreen();

});

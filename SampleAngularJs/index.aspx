<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SampleAngularJs.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Angular.js Samples</title>
    <script src="Scripts/angular.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div data-ng-app="myApp" data-ng-controller="myCtrl">
            <%--    ng-model

            The ng-app directive tells AngularJS that the <div> element is the "owner" of an AngularJS application.
            The ng-model directive binds the value of the input field to the application variable name.
            The ng-bind directive binds the innerHTML of the <p> element to the application variable name.
            --%>
            <div style="margin-bottom: 10px; font-weight: bold; font-size: 18px;">1. ng-model</div>
            <p>Name:
                <input type="text" data-ng-model="name" value=" " /></p>
            <p>{{name}}</p>
            <p data-ng-bind="name"></p>

            <%--    ng-init
            The ng-init directive initializes AngularJS application variables.            
            --%>

            <div style="margin-bottom: 10px; font-weight: bold; font-size: 18px;">2. ng-init</div>
            <p>Name Init:
                <input type="text" data-ng-init="nameinit='angular.js'" value=" " /></p>
            <p data-ng-bind="nameinit"></p>

            <%-- Expressions
        AngularJS expressions are written inside double braces: {{ expression }}.
        AngularJS will "output" data exactly where the expression is written: --%>
            <div style="margin-bottom: 10px; font-weight: bold; font-size: 18px;">3. Expressions  { { expression } }</div>
            <p>Addition of 10 and 20: {{10 + 20 }}</p>

            <%-- modules and controller
            AngularJS modules define AngularJS applications.
            AngularJS controllers control AngularJS applications.
            The ng-app directive defines the application, the ng-controller directive defines the controller.
            --%>
            <div style="margin-bottom: 10px; font-weight: bold; font-size: 18px;">4. modules and controller </div>
            <p>First Name:
                <input type="text" data-ng-model="firstName" value=" " /></p>
            <p>Last Name:
                <input type="text" data-ng-model="lastName" value=" " /></p>

            Full Name: {{ firstName + " " + lastName}}

            <%--    https://www.w3schools.com/angular/angular_expressions.asp   --%>

        </div>
    </form>

    <script type="text/javascript">
        var app = angular.module('myApp', []);
        app.controller('myCtrl', function ($scope) {
            $scope.firstName = "Gunaseelan";
            $scope.lastName = "Ramasamy";
        });
    </script>
</body>
</html>

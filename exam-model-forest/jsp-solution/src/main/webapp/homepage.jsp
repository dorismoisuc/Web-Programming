
<%@ page import="model.Asset" %>
<%@ page import="java.util.List" %>
<%@ page import="controller.AppController" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Assets</title>
    <link rel="stylesheet" href="main.css">
    <script src="jquery-2.0.3.js"></script>
    <script language="javascript">
        // function showAssets(assets) {
        //     let content = "<table border='1'><tr><th>Id</th><th>Name</th><th>Description</th><th>Value</th></tr>";
        //     for (let asset of assets) {
        //         let color = "";
        //         if (asset.value > 10) {
        //             color = "style=\"background-color:#FF0000\"";
        //         }
        //         content += "<tr " + color + "><td>" + asset.id + "</td>" +
        //             "<td>" + asset.name + "</td>" +
        //             "<td>" + asset.description + "</td>" +
        //             "<td>" + asset.value + "</td>" +
        //             "</tr>";
        //     }
        //     console.log(content);
        //     content += "</table>";
        //     $("#all-assets").html(content);
        // }
        $(document).ready(function () {
            if (JSON.parse(sessionStorage["currentUser"]) !== null) {
                // Array.prototype.pushArray = function (arr) {
                //     this.push.apply(this, arr);
                // };
                //let assets = [];
                // $(function () {
                //     $.getJSON(
                //         "/asset", {action: "getAssets", userId: id}, function (data, status) {
                //             console.log(data);
                //             assets.pushArray(data["assets"]);
                //             //showAssets(assets);
                //         }
                //     )
                // });
                let id = JSON.parse(sessionStorage["currentUser"])["userId"];
                let newAssets = [];
                $("#send-button").click(function () {
                    $.post(
                        "/asset",
                        {action: "addAssets", newAssetsToAdd: JSON.stringify(newAssets)},
                        function (data) {
                            location.reload();
                        }
                    );
                    newAssets = [];
                    $("#assets-array").val("");
                });
                $("#push-button").click(function () {
                    newAssets.push({
                        userId: id,
                        name: $("#name").val(),
                        description: $("#description").val(),
                        value: $("#value").val()
                    });
                    $("#name").val("");
                    $("#description").val("");
                    $("#value").val("");
                    let content = "<h4>Assets to add:<br>";
                    for (let tempAsset of newAssets) {
                        content += "<b>" + tempAsset["name"] + ",</b> "
                    }
                    content += "</h4>";
                    $("#assets-array").html(content);
                });
            } else {
                location.href = "login.jsp";
            }
        });
    </script>

</head>
<body>
<h1>Home</h1>

<section id="all-assets">
    <%
        int userId = (int) session.getAttribute("userId");
        List<Asset> assets = AppController.getAssetsOfUser(userId);

        String content = "<table><tr><th>Id</th><th>Name</th><th>Description</th><th>Value</th></tr>";
        for (Asset asset: assets){
            String color = "";
            if (asset.getValue() > 10) {
                color = "style=\"background-color:#FF0000\"";
            }
            content += "<tr " + color + "><td>" + asset.getId() + "</td>" +
                    "<td>" + asset.getName() + "</td>" +
                    "<td>" + asset.getDescription() + "</td>" +
                    "<td>" + asset.getValue() + "</td>" +
                    "</tr>";
        }
        content += "</table>";
        out.println(content);
    %>
</section>
<br>

<form>
    <label for="Name">Name:</label>
    <input type="text" id="name" name="name"><br><br>
    <label for="Description">Description:</label>
    <input type="text" id="description" name="description"><br><br>
    <label for="Value">Value:</label>
    <input type="text" id="value" name="value"><br><br>
    <button type="button" id="push-button">Push</button>
    <button type="button" id="send-button">Send</button>

</form>

<section id="assets-array">
</section>

</body>
</html>

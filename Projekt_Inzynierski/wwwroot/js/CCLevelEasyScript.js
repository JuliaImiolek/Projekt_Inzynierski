var createdTime;
var clickedTime;
var reactionTime;
var testName = "Easy";
var list = [];

function randomcolor() {
    var max = 200;
    var min = 50;
    var green = Math.floor(Math.random() * (max - min + 1)) + min;
    var color = "rgba(255," + green + ",100,1.0)";
    return color;
}

function makebox() {

    var time = Math.random();
    time = time * 5000; //speed

    setTimeout(function () {
        if (Math.random() >= 0.5) {
            document.getElementById('box').style.borderRadius = "75px";
            document.getElementById('box').style.border = "5px solid black";
        } else {
            document.getElementById('box').style.borderRadius = "0px";
            document.getElementById('box').style.border = "5px solid black";
        }

        var min = 0;
        var max = document.documentElement.clientHeight - 500;
        var top = Math.floor(Math.random() * (max - min + 1)) + min;

        min = 0;
        max = document.documentElement.clientWidth - 400;

        if (document.documentElement.clientWidth > document.documentElement.clientHeight) {
            var dynamicBound = document.documentElement.clientWidth / 8;
            console.log("width:" + dynamicBound);
        } else {
            var dynamicBound = document.documentElement.clientHeight / 8;
            console.log("height:" + dynamicBound);
        }

        dynamicBound = dynamicBound + "px";
        document.documentElement.style.setProperty("--bound", dynamicBound);

        var left = Math.floor(Math.random() * (max - min + 1)) + min;


        document.getElementById('box').style.top = top + "px";
        document.getElementById('box').style.left = left + "px";

        document.getElementById('box').style.backgroundColor = randomcolor();
        document.getElementById('box').style.display = "block";
        createdTime = Date.now();
    }, time);


}

function gameStart() {
    var a = 0;
    document.getElementById("userAge").style.display = 'none';
    document.getElementById("userDevice").style.display = 'none';
    document.getElementById("text").style.display = 'none';
    document.getElementById('box').onclick = function () {
        this.style.display = "none";
        clickedTime = Date.now();
        reactionTime = (clickedTime - createdTime) / 1000;
        document.getElementById('time').innerHTML = reactionTime;
        list[a] = reactionTime;
        a++;
        makebox();
    }
    makebox();
}

document.getElementById("SaveGame").onclick = function () {

    var min = 10000;
    for (var i = 0; i < list.length; i++) {

        if (min >= list[i]) {
            min = list[i];
        }
    }
    var userAge = document.getElementById("userAge").value;
    var userDevice = document.getElementById("userDevice").value;
    console.log(userAge);
    reactionSpan = min * 1000;
    $.ajax({
        url: '@Url.Action("AddRecordToReactionTest", "ReactionTest")',
        type: 'POST',
        data: {
            "span": reactionSpan,
            "testName": testName,
            "userAge": userAge,
            "userDevice": userDevice
        },
        success: function (response) {
            var Data = JSON.parse(response);
            alert("Your best reaction time has been saved!");
        },
        failure: function () {
            var Data = JSON.parse(response);
            alert(response);
        },
        error: function () {
            var Data = JSON.parse(response);
            alert(response);
        }

    });
};
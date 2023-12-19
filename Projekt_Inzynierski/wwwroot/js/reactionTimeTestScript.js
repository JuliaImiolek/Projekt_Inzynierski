var createdTime;
var clickedTime;
var reactionTime;
var testName = "Reaction time test";
var list = [];

function makebox() {

    var time = Math.random();
    time = time * 10000; //speed nowy folder

    setTimeout(function () {
        document.getElementById('box').style.borderRadius = "0x";
        document.getElementById('box').style.border = "5px solid black";



        if (document.documentElement.clientWidth > document.documentElement.clientHeight) {
            var dynamicBound = document.documentElement.clientWidth / 4;

        } else {
            var dynamicBound = document.documentElement.clientHeight / 10;
        }

        dynamicBound = dynamicBound + "px";
        document.documentElement.style.setProperty("--bound", dynamicBound);



        document.getElementById('box').style.backgroundColor = 'rgb(0, 255, 13)';
        document.getElementById('box').style.display = "block";


        createdTime = Date.now();
    }, time);


}

function gameStart() {
    var a = 0;
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
    reactionSpan = min * 1000;
    $.ajax({
        url: '/Controllers/PerceptionController',
        type: 'POST',
        data: {
            "span": reactionSpan,
            "testName": testName
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
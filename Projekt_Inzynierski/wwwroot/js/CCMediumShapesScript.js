var clickedInt = 0;
var clicked = document.getElementById("correct");
var createdTime;
var clickedTime;
var reactionTime;
var testName = "Medium shapes"
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
    time = time * 1000; //speed

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
            var dynamicBound = document.documentElement.clientWidth / 60;

        } else {
            var dynamicBound = document.documentElement.clientHeight / 60;

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

var countdown = 30;
function timer() {
    document.getElementById("stoper").innerHTML = countdown;
    if (countdown == 0) {
        clearInterval(timer);

        var min = 10000;
        for (var i = 0; i < list.length; i++) {

            if (min >= list[i]) {
                min = list[i];
            }
        }
        alert("Congratulations! Score: " + clickedInt + " Best Reaction time: " + min + "s");

        reactionSpan = min * 1000;

        var data = {
            span: reactionSpan,
            testName: testName,
            numOfClick: clickedInt,
            isWinner: false
        };
        fetch('https://localhost:44393/Coordination/AddRecordToReactionTest', {
            method: 'POST',
            headers:
            {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data)
        }).then(function (response) {
            if (response.ok) {
                alert("Your best reaction time has been saved!" + response);
                return response.json();
            }
            return Promise.reject(response);
        }).then(data => {
            console.log('Success:');
        }).catch(function (error) {
            console.warn('Errorerror' + error);
        });

        location.reload();
    }
    countdown--;
}

function gameStart() {
    setInterval(timer, 1000);
    var a = 0;
    document.getElementById("text").style.display = 'none';
    document.getElementById('box').onclick = function () {
        this.style.display = "none";
        clickedTime = Date.now();
        reactionTime = (clickedTime - createdTime) / 1000;
        document.getElementById('time').innerHTML = reactionTime;
        list[a] = reactionTime;
        a++;
        clickedInt++;
        if (countdown > 0) {
            makebox();
        }
        clicked.innerHTML = clickedInt;
    }
    makebox();
}
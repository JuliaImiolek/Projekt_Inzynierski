const cards = document.querySelectorAll('.memory-card');
var testName = "Memory";
var flippedCards = 0
let hasFlippedCard = false;
let lockBoard = false;
let firstCard, secondCard;
var startedTime;
var endTime;
var gameTime;
var numOfClick = 0;

function flipCard() {
    if (lockBoard) return;
    if (this === firstCard) return;
    numOfClick++;
    this.classList.add('flip');
    if (numOfClick === 1) {
        startedTime = Date.now();
    }
    if (!hasFlippedCard) {
        // first click
        hasFlippedCard = true;
        firstCard = this;

        return;
    }

    // second click
    secondCard = this;

    checkForMatch();
}
function checkForMatch() {
    let isMatch = firstCard.dataset.framework === secondCard.dataset.framework;

    if (isMatch) {
        disableCards();
        flippedCards = flippedCards + 2;
        if (flippedCards === 12) {
            endTime = Date.now();
            gameTime = (endTime - startedTime) / 1000;
            document.getElementById('time').innerHTML = gameTime;
            document.getElementById('numOfClick').innerHTML = numOfClick;
            alert("Congratulations!");
            $.ajax({
                url: '@Url.Action("AddRecordToReactionTest", "ReactionTest")',
                type: 'POST',
                data: {
                    "span": gameTime,
                    "testName": testName,
                    "numOfClick": numOfClick
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
            })
        }
    } else {
        unflipCards();
    }
}

function disableCards() {
    firstCard.removeEventListener('click', flipCard);
    secondCard.removeEventListener('click', flipCard);
    resetBoard();
}

function unflipCards() {
    lockBoard = true;

    setTimeout(() => {
        firstCard.classList.remove('flip');
        secondCard.classList.remove('flip');

        resetBoard();
    }, 1000);
}

function resetBoard() {
    [hasFlippedCard, lockBoard] = [false, false];
    [firstCard, secondCard] = [null, null];
}

(function shuffle() {
    cards.forEach(card => {
        let randomPos = Math.floor(Math.random() * 12);
        card.style.order = randomPos;
    });
})();

cards.forEach(card => card.addEventListener('click', flipCard));
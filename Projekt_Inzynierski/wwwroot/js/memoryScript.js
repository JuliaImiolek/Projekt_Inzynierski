const cards = document.querySelectorAll('.memory-card');
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
            var span = endTime - startedTime;
            document.getElementById('time').innerHTML = gameTime;
            document.getElementById('numOfClick').innerHTML = numOfClick;
            alert("Congratulations!");
            var data = {
                span: span,
                testName: "Memory",
                numOfClick: numOfClick,
                isWinner: false
            };

            fetch('https://localhost:44393/Memory/AddRecordToReactionTest', {
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
                    console.log('Success:' );
                }).catch(function (error) {
                    console.warn('Errorerror' + error );
             });
             

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
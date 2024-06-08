using match_src;
namespace match_test
{
    public class GameTest
    {
        Game game;

        [Test]
        public void Initialise_Game()
        {
            game = new Game(1, 1);
            Assert.IsNotNull(game);

            Assert.That(game.Deck.Cards.Count, Is.EqualTo(52));
            Assert.IsNotNull(game.PlayerA);
            Assert.IsNotNull(game.PlayerB);
            Assert.IsNull(game.TopOfPile);
            Assert.That(game.PileOfCards.Count, Is.EqualTo(0));
        }

        [Test]
        public void DrawCard_test()
        {
            game = new Game(1, 1);
            Assert.IsNotNull(game);

            Assert.That(game.Deck.Cards.Count, Is.EqualTo(52));
            Assert.IsNull(game.TopOfPile);

            game.DrawCard();
            Assert.That(game.Deck.Cards.Count, Is.EqualTo(0));
        }

        [Test]
        public void CardMatch_BySuit_test()
        {
            game = new Game(1, 1);
            Card matchingCard = new Card(Card.Value.Ten, Card.Suit.Heart);
            Card notMatchingCard = new Card(Card.Value.Ace, Card.Suit.Diamond);
            game.TopOfPile = new Card(Card.Value.Ace, Card.Suit.Heart);
            Assert.IsTrue(game.CardMatch(matchingCard));
            Assert.IsFalse(game.CardMatch(notMatchingCard));
        }

        [Test]
        public void CardMatch_ByValue_test()
        {
            game = new Game(1, 2);
            Card matchingCard = new Card(Card.Value.Ace, Card.Suit.Diamond);
            Card notMatchingCard = new Card(Card.Value.Ten, Card.Suit.Heart);
            game.TopOfPile = new Card(Card.Value.Ace, Card.Suit.Heart);
            Assert.IsTrue(game.CardMatch(matchingCard));
            Assert.IsFalse(game.CardMatch(notMatchingCard));
        }

        [Test]
        public void CardMatch_ByValueAndSuit_test()
        {
            game = new Game(1, 3);
            Card matchingCard = new Card(Card.Value.Ace, Card.Suit.Diamond);
            Card notMatchingCard1 = new Card(Card.Value.Ten, Card.Suit.Diamond);
            Card notMatchingCard2 = new Card(Card.Value.Ace, Card.Suit.Heart);
            game.TopOfPile = new Card(Card.Value.Ace, Card.Suit.Diamond);
            Assert.IsTrue(game.CardMatch(matchingCard));
            Assert.IsFalse(game.CardMatch(notMatchingCard1));
            Assert.IsFalse(game.CardMatch(notMatchingCard2));
        }

        [Test]
        public void PlayerCallMatch_test()
        {
            game = new Game(1, 1);
            Player playerA = new Player("Alice");
            Player playerB = new Player("Bob");
            Player player = game.PlayersCallMatch();
            Assert.NotNull(player);
        }

        [Test]
        public void WinsRound_test()
        {
            //Arrange
            game = new Game(1, 1);
            Player player = new Player("Alice");
            List<Card> cards = new List<Card>();
            cards.Add(new Card(Card.Value.Jack, Card.Suit.Diamond));
            cards.Add(new Card(Card.Value.Ten, Card.Suit.Heart));
            cards.Add(new Card(Card.Value.Two, Card.Suit.Heart));
            game.TopOfPile = new Card(Card.Value.Queen, Card.Suit.Diamond);
            Card drawnCard = new Card(Card.Value.King, Card.Suit.Diamond);
            game.PileOfCards = cards;
            game.PlayerA = player;
            //Act
            Assert.That(game.PileOfCards.Count, Is.EqualTo(3));
            Assert.NotNull(game.TopOfPile);

            game.winsRound(player, drawnCard);

            //Assert
            Assert.That(player.NumberOfCards, Is.EqualTo(4));
            Assert.Null(game.TopOfPile);
            Assert.That(game.PileOfCards.Count, Is.EqualTo(0));
        }

        [Test]
        public void checkWinner_Win_Test()
        {
            game = new Game(1, 1);
            Player playerA = new Player("Alice");
            playerA.GainCards(60);
            Player playerB = new Player("Bob");
            playerB.GainCards(59);
            game.PlayerA = playerA;
            game.PlayerB = playerB;
            Assert.That(game.checkWinner(), Is.EqualTo(playerA));
        }

        [Test]
        public void checkWinner_Draw_Test()
        {
            game = new Game(1, 1);
            Player playerA = new Player("Alice");
            playerA.GainCards(60);
            Player playerB = new Player("Bob");
            playerB.GainCards(60);
            game.PlayerA = playerA;
            game.PlayerB = playerB;
            Assert.IsNull(game.checkWinner());
        }
    }
}
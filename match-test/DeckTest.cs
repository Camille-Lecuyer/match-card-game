using System.ComponentModel.DataAnnotations;
using match_src;
namespace match_test
{
    public class DeckTest
    {

        [Test]
        public void Initialise_1PackDeck()
        {
            Deck deck = new Deck(1);
            Assert.IsNotNull(deck);
            Assert.IsTrue(deck.Cards.Count == 52);
        }

        [Test]
        public void Initialise_5PacksDeck()
        {
            Deck deck = new Deck(5);
            Assert.IsNotNull(deck);
            Assert.IsTrue(deck.Cards.Count == 260);
        }

        [Test]
        public void Draw_test()
        {
            Deck deck = new Deck(1);
            Assert.IsNotNull(deck);
            var cardDrawn = deck.Draw();
            Assert.IsNotNull(cardDrawn);
            Assert.IsTrue(cardDrawn is Card);
        }

        [Test]
        public void isEmpty_test()
        {
            Deck deck = new Deck(1);
            Assert.IsNotNull(deck);
            for(int i = 0; i < 52; i++)
            {
                deck.Draw();
            }
            Assert.That(deck.Cards.Count, Is.EqualTo(0));
            Assert.IsTrue(deck.IsEmpty());
        }
    }
}
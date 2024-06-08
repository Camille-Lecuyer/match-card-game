using System.ComponentModel.DataAnnotations;
using match_src;
namespace match_test
{
    public class CardTest
    {
        [Test]
        public void ToString_test()
        {
            Card card = new Card(Card.Value.Ace, Card.Suit.Diamond);
            Assert.IsTrue(card.ToString().Equals("Diamond - Ace"));
        }

        [Test]
        public void Initialise_Card()
        {
            Card newCard = new Card(Card.Value.Ace, Card.Suit.Heart);
            Assert.That(newCard.CardValue, Is.EqualTo(Card.Value.Ace));
            Assert.That(newCard.CardSuit, Is.EqualTo(Card.Suit.Heart));
        }
    }
}
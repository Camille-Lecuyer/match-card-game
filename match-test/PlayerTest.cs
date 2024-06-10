using System.ComponentModel.DataAnnotations;
using match_src;
namespace match_test
{
    public class PlayerTest
    {
        [Test]
        public void Initialise_Player()
        {
            Player player = new Player("Alice");
            Assert.IsNotNull(player);
            Assert.That(player.Name, Is.SameAs("Alice"));
            Assert.That(player.NumberOfCards, Is.EqualTo(0));
        }

        [Test]
        public void GainCards_Test()
        {
            Player player = new Player("Alice");
            Assert.That(player.NumberOfCards, Is.EqualTo(0));
            player.GainCards(10);
            Assert.That(player.NumberOfCards, Is.EqualTo(10));
            player.GainCards(56);
            Assert.That(player.NumberOfCards, Is.EqualTo(66));
        }
    }
}
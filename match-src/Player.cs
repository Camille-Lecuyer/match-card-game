namespace match_src
{
    internal class Player
    {
        public int NumberOfCards { get; set; }
        private Random Random;
        public string Name { get; set; }

        public Player(string name) 
        {
            Name = name;
            NumberOfCards = 0;
            Random = new Random();
        }

        public int CallMatch()
        {
            return Random.Next(100);
        }

        public void GainCards(int numberOfCards)
        {
            NumberOfCards += numberOfCards;
        }

    }
}

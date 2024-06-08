namespace match_src
{
    internal class Deck
    {
        private List<Card> Cards;
        private Random Random = new Random();

        public Deck(int numberOfDecks)
        {
            Cards = new List<Card>();
            GenerateDeck(numberOfDecks);
            Shuffle();
        }

        private void Shuffle()
        {
            int numberOfCards = Cards.Count;
            //Fisher-Yates shuffle algorithm
            for(int i = numberOfCards - 1; i > 1; i--)
            {
                int rdn = Random.Next(numberOfCards);
                Card tempCard = Cards[i];
                Cards[i] = Cards[rdn];
                Cards[rdn] = tempCard;
            }
        }

        private void GenerateDeck(int numberOfDecks) 
        {
            for (int i = 0; i < numberOfDecks; i++)
            {
                foreach (Card.Suit suit in Enum.GetValues(typeof(Card.Suit)))
                {
                    foreach (Card.Value value in Enum.GetValues(typeof(Card.Value)))
                    {
                        Cards.Add(new Card(value, suit));
                    }
                }
            }
        }

        public Card Draw()
        {
            if (Cards.Count == 0)
            {
                throw new InvalidOperationException("No cards left in the deck");
            }

            Card drawnCard = Cards[0];
            Cards.RemoveAt(0);
            return drawnCard;
        }

        public bool IsEmpty()
        {
            return Cards.Count == 0;
        }
    }
}

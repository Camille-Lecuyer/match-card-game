namespace match_src
{
    internal class Game
    {
        int NumberOfDecks;
        int MatchCondition;
        Deck Deck;
        Card? TopOfPile;
        List<Card> PileOfCards;
        Player PlayerA;
        Player PlayerB;

        public Game(int numberOfDecks, int matchCondition)
        {
            NumberOfDecks = numberOfDecks;
            MatchCondition = matchCondition;
            Deck = new Deck(numberOfDecks);
            PileOfCards = new List<Card>();
            PlayerA = new Player("A");
            PlayerB = new Player("B");
        }

        public void StartGame()
        {
            DrawCards();
            Player winningPlayer = checkWinner();
            if (winningPlayer != null) { 
                Console.WriteLine($"Player {winningPlayer.Name} has won! They had {winningPlayer.NumberOfCards} cards in their pile"); 
            }
            else {
                Console.WriteLine($"It's a draw! Both players have {PlayerA.NumberOfCards} cards");                
            }
        }

        private void DrawCards()
        {
            while (!Deck.IsEmpty())
            {
                Card drawnCard = Deck.Draw();
                Console.WriteLine($"The card {drawnCard.ToString()} has been drawn");

                if (TopOfPile != null && CardMatch(drawnCard))
                {
                    Player winningPlayer = PlayersCallMatch();
                    winsRound(winningPlayer, drawnCard);
                }
                else
                {
                    TopOfPile = drawnCard;
                    PileOfCards.Add(drawnCard);
                }
            }
        }

        private bool CardMatch(Card card)
        {
            if (MatchCondition == 1) return TopOfPile.CardSuit == card.CardSuit;
            else if (MatchCondition == 2) return TopOfPile.CardValue == card.CardValue;
            else return TopOfPile.CardValue == card.CardValue && TopOfPile.CardSuit == card.CardSuit;
        }    

        private Player PlayersCallMatch()
        {
            int playerACall = PlayerA.CallMatch();
            int playerBCall = PlayerB.CallMatch();
            Player winningPlayer = playerACall > playerBCall ? PlayerA : PlayerB;
            Console.WriteLine($"{winningPlayer.Name} has called Match first!");

            return playerACall > playerBCall ? PlayerA : PlayerB;
        }

        private void winsRound(Player winningPlayer, Card drawnCard)
        {
            TopOfPile = null;
            PileOfCards.Add(drawnCard);
            Console.WriteLine($"{winningPlayer.Name} has added {PileOfCards.Count} cards to the {winningPlayer.NumberOfCards} cards already in their pile!");
            winningPlayer.GainCards(PileOfCards.Count);
            PileOfCards = new List<Card>();
        }

        private Player checkWinner()
        {
            if(PlayerA.NumberOfCards > PlayerB.NumberOfCards)
            {
                return PlayerA;
            }else if (PlayerA.NumberOfCards < PlayerB.NumberOfCards)
            {
                return PlayerB;
            }
            else { return null; }
        }
    }
}

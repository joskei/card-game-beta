using cardGameApp.Common;

namespace cardGameApp.Models;

public class Deck
{
    private List<Card> cards;

    public Deck()
    {
        cards = new List<Card>();

        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (CardType cType in Enum.GetValues(typeof(CardType)))
            {
                cards.Add(new Card(suit, cType));
            }
        }
    }

    public void Shuffle()
    {
        Random random = new Random();
        int n = cards.Count;

        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            Card card = cards[k];
            cards[k] = cards[n];
            cards[n] = card;
        }
    }

    public Card Draw()
    {
        if (cards.Count == 0)
        {
            throw new InvalidOperationException("The deck is empty.");
        }

        Card card = cards[0];
        cards.RemoveAt(0);
        return card;
    }
}
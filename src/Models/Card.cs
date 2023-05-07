using cardGameApp.Common;

namespace cardGameApp.Models;

public class Card
{
  public Suit Suit { get; set; }
  public CardType CType { get; set; }

  public Card(Suit suit, CardType cardType)
  {
    Suit = suit;
    CType = cardType;
  }

  public override string ToString()
  {
    return $"{CType} of {Suit}";
  }
}
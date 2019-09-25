using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHandModel : MonoBehaviour
{
    public List<int> cardHand;
    public List<int> usedCardHand;
    public bool isPlayingDeck;
    public int cardHandCount { get { if (cardHand == null) { return 0; } else { return cardHand.Count; } } }

    // Start is called before the first frame update
    void Start()
    {
        cardHand = new List<int>();
        usedCardHand = new List<int>();
        if (isPlayingDeck)
        {
            CreateNewDeck(1);
        }
    }

    //create a new 52 card deck.
    void CreateNewDeck(int numberOfDecks)
    {
        for (int i = 0; i < numberOfDecks; i++)
        {
            for (int ii = 0; ii < 52; ii++)
            {
                cardHand.Add(ii);
            }
        }

        ShuffleCards();
    }

    //shuffle cards
    public void ShuffleCards()
    {
        int n = cardHandCount;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            int temp = cardHand[k];
            cardHand[k] = cardHand[n];
            cardHand[n] = temp;
        }

    }

    //remove top card from hand and play it. returns value of top card.
    public int PlayCard()
    {
        usedCardHand.Add(cardHand[0]);
        cardHand.RemoveAt(0);
        return usedCardHand[-1];
    }

    //remove top card from deck. returns top card.
    public int Pop()
    {
        int temp = cardHand[0];
        cardHand.RemoveAt(0);
        return temp;
    }

    //add card to hand from playing deck.
    public void Push(int card)
    {
        cardHand.Add(card);
    }

    //clear the hand of all cards
    public void ClearHand()
    {
        cardHand.Clear();
    }
}

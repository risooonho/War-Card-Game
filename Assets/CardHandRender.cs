using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHandRender : MonoBehaviour
{
    public Vector3 startingPosition;
    CardHandModel cardHand;
    List<int> usedCards;
    List<int> renderedCards;
    public float cardOffset;
    public GameObject CardPrefab;

    // Start is called before the first frame update
    void Start()
    {
        cardHand = GetComponent<CardHandModel>();
        renderedCards = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        cardHand.usedCardHand = cardHand.cardHand;
        showCards();
    }

    //method to show cards.
    void showCards()
    {
        int cardOffsetIndex = 0;

        foreach (int card in cardHand.usedCardHand)
        {
            if (!renderedCards.Contains(card))
            {
                float coX = cardOffsetIndex * cardOffset;
                float coZ = cardOffsetIndex * -0.1f;
                Vector3 temp = startingPosition + new Vector3(coX, 0f, coZ);
                renderCard(temp, card);
                cardOffsetIndex++;
                renderedCards.Add(card);
            }

        }
    }

    //clear all cards

    //if card stack has cards, get cards and use 'renderCard' method. if it's the playingDeck, fan it slightly.

    //method to render card at a position on screen.
    void renderCard(Vector3 position, int cardIndex)
    {
        GameObject Card = (GameObject)Instantiate(CardPrefab);
        Card.transform.position = position;
        CardModel cardModel = Card.GetComponent<CardModel>();
        Card.name = "CardObj";
        Card.transform.parent = cardHand.transform;
        cardModel.cardIndex = cardIndex;
        if (cardHand.isPlayingDeck)
        {
            cardModel.showCardFace = false;
        }
        else
        {
            cardModel.showCardFace = true;
        }
    }
}

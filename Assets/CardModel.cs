using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardModel : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public Sprite[] cardFrontFaces;
    private Sprite cardBackFace;

    public int cardIndex; //use as cardFrontFaces[cardIndex]
    public int cardValue; //2-9,10,11
    public bool showCardFace;


    // Start is called before the first frame update
    void Start()
    {
        //set sprite renderer component
        spriteRenderer = GetComponent<SpriteRenderer>();
        cardBackFace = spriteRenderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        changeCardFace(showCardFace);
    }

    //method to show card face
    public void changeCardFace(bool showCardFace)
    {
        if (showCardFace)
        {
            //set card face
            spriteRenderer.sprite = cardFrontFaces[cardIndex];
            //set card value
            cardValue = cardIndex % 13;
            if (cardValue == 12) { cardValue = 11; } //aces get 11
            else if (cardValue < 12 && cardValue > 7) { cardValue = 10; } //10,J,Q,K get 10
            else { cardValue = cardValue + 2; } // 2-9
        }
        else
        {
            spriteRenderer.sprite = cardBackFace;
            cardValue = 0;
        }
    }
}

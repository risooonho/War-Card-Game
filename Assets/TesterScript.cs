using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesterScript : MonoBehaviour
{
    public CardHandModel playingDeck;
    public CardHandModel leftPlayer;
    public CardHandModel rightPlayer;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(DealCardsEach());
    }

    IEnumerator DealCardsEach()
    {
        int numCards = 2;
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < numCards; i++)
        {
            leftPlayer.Push(playingDeck.Pop());
            rightPlayer.Push(playingDeck.Pop());
        }
    }
}
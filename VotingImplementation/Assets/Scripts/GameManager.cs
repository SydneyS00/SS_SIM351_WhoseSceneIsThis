using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    //VARIABLES

    //This will contain all of our cards in our pile
    public List<CardBehavior> deck = new List<CardBehavior>();
    public List<CardBehavior> discardPile = new List<CardBehavior>(); 

   //This will contain the cards in our hand
    public Transform[] cardSlots;
    public bool[] availableCardsSlots;

    //This will display the number of cards that we have in the deck
    public TextMeshProUGUI deckSizeText;
    public TextMeshProUGUI discardPileText;

    //Our different canvas variables
    public GameObject voteCanvas;
    //public GameObject settingsCanvas; 

    public void DrawCard()
    {
        if(deck.Count >= 1)
        {
            CardBehavior randCard = deck[Random.Range(0, deck.Count)];

            //To place cards in our hands check our current hand
            for(int i = 0; i < availableCardsSlots.Length; i++)
            {
                if (availableCardsSlots[i] == true)
                {
                    //activated the card we want to draw
                    randCard.gameObject.SetActive(true);
                    randCard.handIndex = i; 
                    Debug.Log("Drew a Card"); 

                    //place card in the set position
                    randCard.transform.position = cardSlots[i].position;
                    availableCardsSlots[i] = false;
                    deck.Remove(randCard);
                    return;
                }
            }
        }
    }

    private void Update()
    {
        //Update the deck and discard pile numbers
        deckSizeText.text = deck.Count.ToString();
        discardPileText.text = discardPile.Count.ToString();

        //We need to check BOTH the deck pile and the slots 
        //If these are both empty then we will pull up the voting screen.
        //Variables to check - discardPile and deck.Count
        
        if(deck.Count == 0 && discardPile.Count == 9)
        {
            EnableVote(); 
        }

    }

    //Enable our voting canvas
    void EnableVote()
    {
        //This will enable our canvas where we can vote 
        voteCanvas.SetActive(true); 
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBehavior : MonoBehaviour
{
    public bool hasBeenPlayed;
    public int handIndex;

    private GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>(); 
    }

    private void OnMouseDown()
    {
        if (hasBeenPlayed == false)
        {
            transform.position += Vector3.up * 5;
            hasBeenPlayed = true;
            gm.availableCardsSlots[handIndex] = true;

            Invoke("MoveToDiscardPile", 2f);
        }
    }

    void MoveToDiscardPile()
    {
        gm.discardPile.Add(this);
        gameObject.SetActive(false);

        Debug.Log("Card discarded"); 
    }

    //We need to implement a behavior that ends the game 
    //  when we are out of cards entirely 

    
}

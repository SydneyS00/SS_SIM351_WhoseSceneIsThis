using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBoard : MonoBehaviour, IInteractable
{
    //This is the scripts for the WHITEBOARD
    //The WHITEBOARD is where all of the players will place their evidence and 
    //  vote at the end of each round. 

    [SerializeField] private string _prompt;
    public string InteractionPrompt { get; }

    string IInteractable.InteractionPropmt => _prompt;

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Accessing the white board!");
        return true;

        //We would also be doing the things that our desk needs 
        //  to do here. 
    }
}
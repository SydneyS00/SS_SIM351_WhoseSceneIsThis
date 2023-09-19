using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDesk : MonoBehaviour, IInteractable 
{
    //This is the script for our Main Desk
    //The MAIN DESK is where our player and the AI can 
    //  draw cards

    [SerializeField] private string _prompt;
    public string InteractionPrompt { get; }

    string IInteractable.InteractionPropmt => _prompt;

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Accessing the main desk!!");
        return true;

        //We would also be doing the things that our desk needs 
        //  to do here. 
    }
}

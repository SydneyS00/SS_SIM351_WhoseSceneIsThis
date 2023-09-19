using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDesk : MonoBehaviour, IInteractable
{
    //This script is for our individual PLAYER'S DESK
    //The PLAYER'S DESK is where our player will access their 
    //  evidence folder and notes

    [SerializeField] private string _prompt; 
    public string InteractionPrompt { get; }

    string IInteractable.InteractionPropmt => _prompt; 

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Accessing our desk!");
        return true; 

        //We would also be doing the things that our desk needs 
        //  to do here. 
    }

    //What we are implementing from our IInteractable instance

}



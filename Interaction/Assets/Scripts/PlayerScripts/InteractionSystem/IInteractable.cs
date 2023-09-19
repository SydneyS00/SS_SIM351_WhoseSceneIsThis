using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable 
{
    //This is our interface for our interactables

    public string InteractionPropmt { get; }
    public bool Interact(Interactor interactor);
}

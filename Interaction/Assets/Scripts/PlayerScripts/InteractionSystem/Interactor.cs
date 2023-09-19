using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius;
    [SerializeField] private LayerMask _interactableMask;
    [SerializeField] private InteractionPromptUI _interactionPromptUI; 

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;

    private IInteractable _interactable; 

    private void Update()
    {
        //This will return an int which will be the number of items in our colliders our found in the radius
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders,
            _interactableMask);

        //
        if(_numFound > 0)
        {
            _interactable = _colliders[0].GetComponent<IInteractable>(); 

            //If we do find and interactable object and press the E key
            //  we will activate the Interact function for that interactable
            //Super confusing but somehow makes sense 
            //NOTE the video I watched did not use Input.GetKeyDown...
            //  they used a different line of code that implemented the 
            //  using UnityEngine.InputSystems. 

            if(_interactable != null)
            {
                if (!_interactionPromptUI.isDisplayed)
                {
                    _interactionPromptUI.SetUp(_interactable.InteractionPropmt);
                }
                if(Input.GetKeyDown(KeyCode.E))
                {
                    _interactable.Interact(this); 
                }
            }
            else
            {
                if(_interactable != null)
                {
                    _interactable = null;
                }
                if(_interactionPromptUI.isDisplayed)
                {
                    _interactionPromptUI.Close(); 
                }
            }
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}

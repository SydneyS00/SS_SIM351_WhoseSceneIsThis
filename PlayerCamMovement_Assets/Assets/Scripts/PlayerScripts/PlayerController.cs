using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //This script is responsible for the following: 
    //  -Player movement
    //  -Player buttons/controls

    //______VARIABLES______//
    public CharacterController controller;

    public float speed = 12f; 

     void Update()
    {
        //Create variables for our controller inputs
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime); 
    }
}

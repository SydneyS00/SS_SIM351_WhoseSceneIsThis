using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    //This is the script for our first person camera

    public Transform player;
    public float mouseSens = 2f;
    float cameraVertRot = 0f;

    bool lockedCursor = true; 

    void Start()
    {
        //Lock and hide the mouse cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void Update()
    {
        //Collect mouse input
        float inputX = Input.GetAxis("Mouse X") * mouseSens;
        float inputY = Input.GetAxis("Mouse Y") * mouseSens;

        //Rotate the camera around its local x axis
        cameraVertRot -= inputY;
        cameraVertRot = Mathf.Clamp(cameraVertRot, -90f, 90f);
        transform.localEulerAngles = Vector3.right * cameraVertRot;

        //Rotate the player object and the camera around its y axis
        player.Rotate(Vector3.up * inputX); 
    }
}

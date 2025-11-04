using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class CameraTurn : MonoBehaviour
{
    public float rotateSpeed = 7f; // So we can set how fast we turn the camera


    // Update is called once per frame
    void Update()
    {
        // sets the angles to the variables
        float rotateX = transform.eulerAngles.x;
        float rotateY = transform.eulerAngles.y;

        // When we click and move the mouse, it rotates around the player accordingly
        if (Input.GetMouseButton(0))
        {
            // Multiplies how fast we move the mouse by the rotate speed and changes rotate(X,Y)
            rotateX -= Input.GetAxis("Mouse Y") * rotateSpeed;
            rotateY += Input.GetAxis("Mouse X") * rotateSpeed;

            // Updates the rotation
            transform.rotation = Quaternion.Euler(rotateX, rotateY, 0f);
        }
    }
}

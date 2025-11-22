using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Vector3 pos = new Vector3(0, 2, 0);

    public float moveSpeed = 0.1f;

    public Transform center;

    


    // Start is called before the first frame update
    void Start()
    {
        transform.position = pos;

        
    }


    // Update is called once per frame
    void Update()
    {
        float cenY = Mathf.Abs(center.transform.eulerAngles.y);
        float cenX = Mathf.Abs(center.transform.eulerAngles.x);
        float cenZ = Mathf.Abs(center.transform.eulerAngles.z);

        float rotY = Mathf.Abs(transform.eulerAngles.y);
        float rotX = Mathf.Abs(transform.eulerAngles.x);
        
        Debug.Log($"X: {pos.x}, Y: {pos.y}, Z: {pos.z}");

        if (Input.GetKey(KeyCode.Space) && Mathf.Abs(pos.x) < 50f && pos.y > -50f && pos.y < 50f && Mathf.Abs(pos.z) < 50f)
        {
            

            if (rotY < 90)
            {
                pos.z += (1 - (rotY / 90)) * moveSpeed;
                pos.x += rotY / 90 * moveSpeed;
            }
            else if (rotY > 90 && rotY < 180)
            {
                pos.z -= (1 - ((180 - rotY) / 90)) * moveSpeed;
                pos.x += (180 - rotY) / 90 * moveSpeed;
            }
            else if (rotY > 180 && rotY < 270)
            {
                pos.z -= (270 - rotY) / 90 * moveSpeed;
                pos.x -= (1 - ((270 - rotY) / 90)) * moveSpeed;
            }
            else if (rotY > 270)
            {
                pos.z += (1 - ((360 - rotY) / 90)) * moveSpeed;
                pos.x -= (360 - rotY) / 90 * moveSpeed;
            }
            // Turn Fish Up and Down
            if (rotX < 360 && rotX > 270)
            {
                pos.y += (((360 - rotX) / 90)) * moveSpeed;
            }
            else if (rotX > 0 && rotX < 90)
            {
                pos.y -= ((rotX / 90)) * moveSpeed;
            }

            transform.position = pos;
        }
        else
        {
            
            transform.position = transform.position;
        }
        // Set the boundaries that the fish can go
        if (pos.x > 49)
            pos.x = 49;
        else if (pos.x < -49)
            pos.x = -49;
        else if (pos.z > 49)
            pos.z = 49;
        else if (pos.z < -49)
            pos.z = -49;
        else if (pos.y > 49)
            pos.y = 49;
        else if (pos.y < -49)
            pos.y = -49;


        // Turn Fish Up and Down
        if (Input.GetKey(KeyCode.W) && (rotX > 280 || rotX < 90))
        {
            rotX -= 1;
            cenX -= 0.1f;
        }
        if (Input.GetKey(KeyCode.S) && (rotX < 80 || rotX > 270))
        {
            rotX += 1;
            cenX += 0.1f;
        }

        // Turn Fish Left and Right
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            rotY -= 1;
            cenY -= 0.9f;
        }
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            rotY += 1;
            cenY += 0.9f;
        }
        transform.eulerAngles = new Vector3(rotX, rotY, 0);
        center.transform.eulerAngles = new Vector3 (cenX, cenY, cenZ);


        // Just for reseting purposes
        if (Input.GetKey(KeyCode.Period))
        {
            pos = new Vector3(0, 2, 0);
            transform.position = pos;
            transform.rotation = new Quaternion(0, 0, 0, 0);
            center.transform.eulerAngles = new Vector3(cenX, cenY, cenZ);
        }
    }
}

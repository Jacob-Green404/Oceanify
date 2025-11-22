using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public GameObject[] cameras;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && cameras[0].active)
        {
            cameras[0].SetActive(false);
            cameras[1].SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.I) && cameras[1].active)
        {
            cameras[0].SetActive(true);
            cameras[1].SetActive(false);
        }
    }
}

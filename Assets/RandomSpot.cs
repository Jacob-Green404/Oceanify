using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpot : MonoBehaviour
{
    public Vector3 pos = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

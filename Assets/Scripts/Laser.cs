using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float t;

    void Start()
    {
        GetComponent<LineRenderer>().widthMultiplier = 0.05f;
        Destroy(gameObject, 0.15f);  
    }

    void Update()
    {
 
    }
}

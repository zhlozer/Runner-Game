using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
     public float axespeed = 10.0f;
    

    void Update()
    {
     transform.Translate(Vector3.back * Time.deltaTime * axespeed);
     

    }
}

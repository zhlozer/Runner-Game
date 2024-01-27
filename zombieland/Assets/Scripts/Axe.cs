using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -2 || transform.position.x > 2 || transform.position.y < 0 || transform.position.y > 10
        || transform.position.z > 1 || transform.position.z < -10 ){
            Destroy(gameObject);
            Debug.Log("Yok oldu");
        }
       
    }
}

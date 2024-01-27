using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    public float speed=6;
    // private float width=72;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
    playerControllerScript =
    GameObject.Find("Player").GetComponent<PlayerController>();    
    }

    // Update is called once per frame
    void Update()
    {
    if (playerControllerScript.gameOver == false)
    {
    transform.Translate(Vector3.forward * speed * Time.deltaTime);     
    }
    else
    {
    speed=0;
    }
    }
}

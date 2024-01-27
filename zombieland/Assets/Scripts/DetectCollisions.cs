using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Start is called before the first frame update
  public GameObject AxePrefab;   

  public AudioClip metalicSound;
  private AudioSource axeAudio;

void Start (){
    axeAudio=GetComponent<AudioSource>();
}

  private void OnCollisionEnter(Collision collision)
   {
    if(collision.collider.tag == "Zombie"){
        
       Destroy(collision.gameObject);
       Destroy(AxePrefab);
       ScoreManager.scoreCount +=10;
    }

    if(collision.collider.tag == "Human"){
        
        Destroy(collision.gameObject);
        Destroy(AxePrefab);
        ScoreManager.scoreCount -=30;
    }
    if(collision.collider.tag == "Car"){

        axeAudio.PlayOneShot(metalicSound, 1f);
    }

   }
   
}
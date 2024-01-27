using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SIDE {Left, Mid, Right}

public class PlayerController : MonoBehaviour
{
    public SIDE m_Side = SIDE.Mid;
    float NewXPos=0f;
    public bool SwipeLeft;
    public bool SwipeRight;
    public float XValue;
    private CharacterController m_char;
    private float x;
    public float SpeedDodge;
    private Animator playerAnim;
    private MoveBack moveBackScript;
    public SpawnManager spawnManager;
    public RepeatStreet repeatStreet;
    
    private MoveBack moveBackInstance;
    public GameObject AxePrefab;
    public bool gameOver=false;
    private Rigidbody playerRb;
    public float gravityModifier;
    private Vector3 offset = new Vector3(0, 0, -1);
    private float timer;
    public ScoreManager scoreManager;
    public AudioClip throwAxeSound;
    
    
    public AudioClip swipeSound;
    // playerAudio.PlayOneShot(deathSound, 0.9f);
    
    
    private AudioSource playerAudio;

    void Start()
    {        
        Physics.gravity *= gravityModifier;
        m_char = GetComponent<CharacterController>();
        transform.position=Vector3.zero;  
        playerAnim = GetComponent<Animator>();    
        playerRb=GetComponent<Rigidbody>();  
        playerAudio = GetComponent<AudioSource>();
        
        moveBackScript = GameObject.Find("Map").GetComponent<MoveBack>();

    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
        {
        Instantiate(AxePrefab, transform.position + offset, AxePrefab.transform.rotation);
        playerAudio.PlayOneShot(throwAxeSound, 0.9f);
        }

       
        
    
     if (moveBackInstance != null && moveBackInstance.speed != 0)
    {
    playerAnim.SetBool("Run_t",true);
    }
    else
    {
    playerAnim.SetBool("Run_t",false);
    }
    
        SwipeLeft = Input.GetKeyDown(KeyCode.A);
        SwipeRight = Input.GetKeyDown(KeyCode.D);

        if (SwipeLeft)
        {
            if(m_Side == SIDE.Mid)
            {
            NewXPos = -XValue;   
            m_Side= SIDE.Left;

            }else if(m_Side == SIDE.Right)
            {
            NewXPos = 0;
            m_Side= SIDE.Mid;
            }
            playerAudio.PlayOneShot(swipeSound, 0.9f);
        }
        else if (SwipeRight){
            if(m_Side == SIDE.Mid)
            {
            NewXPos = XValue;
            m_Side= SIDE.Right;
            }else if(m_Side == SIDE.Left)
            {
            NewXPos = 0;
            m_Side= SIDE.Mid;
            }
            playerAudio.PlayOneShot(swipeSound, 0.9f);
        }
        x = Mathf.Lerp(x, NewXPos, Time.deltaTime * SpeedDodge);
        m_char.Move((x - transform.position.x) * Vector3.right);    
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Zombie"){
            gameOver=true;
            playerAnim.SetBool("Death", true);
            moveBackScript.speed = 0f;
            spawnManager.StopSpawn();
            repeatStreet.StopSpawnMap();
            SceneManager.LoadScene(3);
            
        }
    if(collision.gameObject.tag == "Human"){
            gameOver=true;
            playerAnim.SetBool("Death", true);
            moveBackScript.speed = 0f;
            spawnManager.StopSpawn();
            repeatStreet.StopSpawnMap();
            SceneManager.LoadScene(3);
            
            
        }
    if(collision.gameObject.tag == "Car"){
            gameOver=true;
            playerAnim.SetBool("Death", true);
            moveBackScript.speed = 0f;
            spawnManager.StopSpawn();
            repeatStreet.StopSpawnMap();
            SceneManager.LoadScene(3);
            
        }

        if(collision.gameObject.tag == "Axe"){
            gameOver=true;
            playerAnim.SetBool("Death", true);
            moveBackScript.speed = 0f;
            spawnManager.StopSpawn();
            repeatStreet.StopSpawnMap();
            SceneManager.LoadScene(3);
        }
    }
}   
    
    
    

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text hiScoreText;
    public static int scoreCount;
    public static int hiScoreCount;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("HighScore"))
        {
            hiScoreCount = PlayerPrefs.GetInt("HighScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>1f){
            scoreCount+= 1;
            timer =0;
        }
        if(scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetInt("HighScore",hiScoreCount);
        }
        scoreText.text= "Score: " + Mathf.Round(scoreCount); 
        hiScoreText.text= "HighScore: " + Mathf.Round(hiScoreCount); 
    }
    
}
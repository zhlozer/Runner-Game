using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
public void PlayButton()
{
SceneManager.LoadScene(1);
ScoreManager.scoreCount=0;
}
public void QuitButton()
{
Application.Quit();
}

public void HTPButton()
{
SceneManager.LoadScene(2);
}

public void BackButton()
{
SceneManager.LoadScene(0);
}
}

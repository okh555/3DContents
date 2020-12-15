using System.Collections;
using System.Collections.Generic;
using System.Runtime.Hosting;
using UnityEngine;  
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("3DContents");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoHome()
    {
        SceneManager.LoadScene("StartScene");

    }
}

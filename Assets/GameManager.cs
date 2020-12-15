using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Media;
using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private Animator animator;
    GameObject player;
    string currentScene;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        currentScene = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Dead()
    {
        SceneManager.LoadScene(currentScene);
    }

}
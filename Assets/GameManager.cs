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
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player.transform.position = new Vector3(0,0,0);
            Debug.Log("asdasd111");
            //SceneManager.LoadScene("3DContents");
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class endTutorial : MonoBehaviour
{
    public AudioClip soundSE;
    AudioSource aud;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //this.aud.PlayOneShot(this.soundSE);
            SceneManager.LoadScene("Map1");
        }
    }
}

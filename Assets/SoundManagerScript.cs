using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip jumpSE, itemSE;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        jumpSE = Resources.Load<AudioClip>("jump_04");
        itemSE = Resources.Load<AudioClip>("coin_23");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "item":
                audioSrc.PlayOneShot(itemSE);
                break;
            case "jump":
                audioSrc.PlayOneShot(jumpSE);
                break;
        }
    }
}

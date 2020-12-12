using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Debug;

public class UIManager : MonoBehaviour
{
    GameObject player;
    ItemController itemController;
    PlayerMovement playerMovement;
    bool start= false;
    float playtime = 0;
    int[] items = new int[3];

    Texture t;

    public Text speed;
    public Text timer;
    public RawImage[] item;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        itemController = player.GetComponent<ItemController>();
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMovement.Speed != Vector3.zero && !start)
        {
            start = true;
        }
        if(start)
        {
            playtime += Time.deltaTime;
        }

        SetTimer();
        SetSpeed();
        SetItem();     
    }
    void SetTimer()
    {
        if(playtime != 0)
        {
            timer.text = "Time : " + (int)playtime;
        }
    }

    void SetSpeed()
    {
       speed.text = "Velocity : " + -1 * (int)playerMovement.Speed.y;
    }

    void SetItem()
    {
        items = itemController.GetItem();
        for(int i = 0; i<items.Length;i++)
        {
            if (items[i] == 1)
            {
                t = Resources.Load("double") as Texture;
                item[i].texture = t;
            }       
            if (items[i] == 2)
            {
                t = Resources.Load("sizedown") as Texture;
                item[i].texture = t;
            }
            else if (items[i] == 3)
            {
                t = Resources.Load("booster") as Texture;
                item[i].texture = t;
            }
            else
            {
                item[i].color = Color.black;
                t = Resources.Load("basic") as Texture;
                item[i].texture = t;
            }
                
        }
    }
}

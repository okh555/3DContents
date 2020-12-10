using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    GameObject player;
    ItemController itemController;
    PlayerMovement playerMovement;
    bool start= false;
    float playtime = 0;
    int[] items = new int[3];




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
        SetItem();
    }
    void SetTimer()
    {
        if(playtime != 0)
        {
            timer.text = "Time : " + (int)playtime;
        }
    }

    void SetItem()
    {
        items = itemController.GetItem();
        for(int i = 0; i<items.Length;i++)
        {
            if (items[i] == 1)
                item[i].color = Color.red;
            else
                item[i].color = Color.black;
        }
    }
}

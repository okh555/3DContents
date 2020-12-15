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

    Vector3 oldPosition;
    Vector3 currentPosition;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        itemController = player.GetComponent<ItemController>();
        playerMovement = player.GetComponent<PlayerMovement>();

        oldPosition = player.transform.position;
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
        /*   
        currentPosition = player.transform.position;
        var distance = currentPosition - oldPosition;
        var velocity = distance / Time.deltaTime;
        oldPosition = currentPosition;
        //Debug.Log(velocity);
        
        
            */
     
        //Vector3 moveVec = player.transform.forward;
        //float Speed = moveVec.sqrMagnitude; // 값이 작게 나오기 때문에 제곱한 값을 사용한다.

        var fwdSpeed = Vector3.Dot(playerMovement.Speed, player.transform.forward);
        if (fwdSpeed < 0)
            speed.text = "Velocity : " + -1 * fwdSpeed;
        else
            speed.text = "Velocity : " + fwdSpeed;

        //speed.text = "Velocity : " + Speed; //(int)playerMovement.Speed.z;
    }

    void SetItem()
    {
        items = itemController.GetItem();
        for(int i = 0; i<items.Length;i++)
        {
            if (items[i] == 1)
            {
                t = Resources.Load("doublejump") as Texture;
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
            else if(items[i] == 0)
            {
                t = Resources.Load("basic") as Texture;
                item[i].texture = t;
            }
                
        }
    }
}

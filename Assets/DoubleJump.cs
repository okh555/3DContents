using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : Item
{
    public override void UsingItem()
    {
        usingItem = true;
        currentTime = Time.time;


        player.GetComponent<PlayerMovement>().jumpHeight *= 2f;

    }
    // Update is called once per frame
    void Update()
    {
        if (usingItem)
        {
            if (Time.time - currentTime > time && player != null)
            {
                player.GetComponent<PlayerMovement>().jumpHeight *= 1.0f / 2.0f;
                Destroy(this.gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player" && trigger == false)
        {
            player = collider.gameObject;
            this.gameObject.GetComponent<Renderer>().enabled = false;
            this.gameObject.GetComponent<Collider>().enabled = false;
            ItemController = player.GetComponent<ItemController>();
            ItemController.PushItem(this);
            trigger = true;
        }
    }

}

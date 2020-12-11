using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : Item
{

    public override void UsingItem()
    {
        time = 6;
        usingItem = true;
        currentTime = Time.time;
        player.GetComponent<PlayerMovement>().speed *= 1.4f;

    }

    // Update is called once per frame
    void Update()
    {
        if (usingItem)
        {
            if (Time.time - currentTime > time && player != null)
            {
                player.GetComponent<PlayerMovement>().speed *= 1.0f / 1.4f;
                Destroy(this.gameObject);
            }

            if (Time.time - currentTime > blinkTime && player != null)
            {
                startBlinking = true;
                SpriteBlinkingEffect();
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            player = collider.gameObject;
            this.gameObject.GetComponent<Renderer>().enabled = false;
            ItemController = player.GetComponent<ItemController>();
            ItemController.PushItem(this);
            trigger = true;
        }
    }


    private void SpriteBlinkingEffect()
    {
        spriteBlinkingTotalTimer += Time.deltaTime;
        if (spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
        {
            startBlinking = false;
            spriteBlinkingTotalTimer = 0.0f;

            Renderer[] renderers = player.gameObject.GetComponentsInChildren<Renderer>();
            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].enabled = true;
            }

            return;
        }

        spriteBlinkingTimer += Time.deltaTime;
        if (spriteBlinkingTimer >= spriteBlinkingMiniDuration)
        {
            spriteBlinkingTimer = 0.0f;
            Renderer[] renderers = player.gameObject.GetComponentsInChildren<Renderer>();
            for (int i = 0; i < renderers.Length; i++)
            {
                if (renderers[i].enabled == true)
                {
                    renderers[i].enabled = false;
                }
                else
                {
                    renderers[i].enabled = true;
                }
            } //make changes


        }

    }
}

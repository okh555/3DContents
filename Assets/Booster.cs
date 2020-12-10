using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : Item
{
    public float time = 5;
    public float blinkTime = 3;
    public float spriteBlinkingTimer = 0.0f;
    public float spriteBlinkingMiniDuration = 0.1f;
    public float spriteBlinkingTotalTimer = 0.0f;
    public float spriteBlinkingTotalDuration = 1.0f;
    public bool startBlinking = false;


    private GameObject player;
    private bool trigger = false;
    private float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - currentTime > time && player != null)
        {
            player.GetComponent<RobotFreeAnim>().speed *= 1.0f / 1.4f;
            Destroy(this.gameObject);
        }

        if (Time.time - currentTime > blinkTime && player != null)
        {
            startBlinking = true;
            SpriteBlinkingEffect();
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            player = collider.gameObject;
            player.GetComponent<RobotFreeAnim>().speed *= 1.4f;
            this.gameObject.GetComponent<Renderer>().enabled = false;
            trigger = true;
            currentTime = Time.time;
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

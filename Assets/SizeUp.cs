using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeUp : MonoBehaviour
{
    public float time = 5;
    private GameObject player;
    private bool trigger = false;
    private float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (Time.time - currentTime > time && player != null)
        {
            player.GetComponent<RobotFreeAnim>().jumpHeight *= 1.0f / 2.0f;
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - currentTime > time && player != null)
        {
            player.transform.localScale = player.transform.localScale * 0.5f;
            player.GetComponent<RobotFreeAnim>().speed *= 1.5f;
            Destroy(this.gameObject);
        }

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player" && trigger == false)
        {
            player = collider.gameObject;
            player.transform.localScale = player.transform.localScale * 2f;
            player.GetComponent<RobotFreeAnim>().speed *= 2.0f / 3.0f;
            this.gameObject.GetComponent<Renderer>().enabled = false;
            trigger = true;
            currentTime = Time.time;
        }
    }
}

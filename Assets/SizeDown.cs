using UnityEngine;

public class SizeDown : Item 
{
    public override void UsingItem()
    {
        usingItem = true;
        currentTime = Time.time;
        time = 6;

        player.transform.localScale = player.transform.localScale * 0.5f;
        player.GetComponent<PlayerMovement>().speed *= 1.5f;
    }
    // Update is called once per frame


    void Update()
    {
        code = 2;
        if (usingItem)
        {
            if (Time.time - currentTime > time && player != null)
            {
                player.transform.localScale = player.transform.localScale * 2f;
                player.GetComponent<PlayerMovement>().speed *= 2.0f / 3.0f;
                Destroy(this.gameObject);
            }
        }

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player" && trigger == false)
        {
            audioSource.clip = sound;
            audioSource.Play();
            player = collider.gameObject;
            this.gameObject.GetComponent<Renderer>().enabled = false;
            this.gameObject.GetComponent<Collider>().enabled = false;
            ItemController.PushItem(this);
            trigger = true;
        }
    }
}

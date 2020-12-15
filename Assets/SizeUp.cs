using UnityEngine;

public class SizeUp : Item
{
    public override void UsingItem()
    {
        Debug.Log("Using Size Up");

        time = 6f;
        usingItem = true;
        currentTime = Time.time;

        player.transform.localScale = player.transform.localScale * 2f;
        player.GetComponent<PlayerMovement>().speed *= 2.0f / 3.0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (usingItem)
        {
            if (Time.time - currentTime > time && player != null)
            {
                player.transform.localScale = player.transform.localScale * 0.5f;
                player.GetComponent<PlayerMovement>().speed *= 1.5f;
                Destroy(this.gameObject);
            }
        }

    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(this.ToString());
        if (collider.gameObject.name == "Player" && trigger == false)
        {
            audioSource.clip = sound;
            audioSource.Play();
            this.gameObject.GetComponent<Collider>().enabled = false;
            this.gameObject.GetComponent<Renderer>().enabled = false;
            player = collider.gameObject;
            ItemController.PushItem(this);
            trigger = true;
        }
    }

}

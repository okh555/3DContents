using UnityEngine;

public class SizeUp : Item
{
    // Start is called before the first frame update
    void Start()
    {
        time = 6;
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

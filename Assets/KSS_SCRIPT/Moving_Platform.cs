using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class Moving_Platform : MonoBehaviour
{
    public GameObject Player;

    void OnTriggerEnter(Collider other)
    {
       
            if(other.tag == "Player")
                 Player.transform.parent = transform;
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = null;
        }
    }
}

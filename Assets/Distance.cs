using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Distance : MonoBehaviour
{
    public GameObject Player;
    public GameObject EndPoint;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(Player.transform.position, EndPoint.transform.position);
        Debug.Log(distance);
    }
}

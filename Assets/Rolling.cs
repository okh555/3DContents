using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolling : MonoBehaviour
{

    private float speed = 200f;
    public float yAxisSpeed = 1f;

    private Vector3 currentPos;

    
    // Start is called before the first frame update
    void Awake()
    {
        currentPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,Time.deltaTime *speed,0), Space.World);
        transform.position += new Vector3(0, Time.deltaTime * yAxisSpeed, 0);
        if (Mathf.Abs(currentPos.y - transform.position.y) > 1f)
        {
            yAxisSpeed = -yAxisSpeed;
        }
    }
}

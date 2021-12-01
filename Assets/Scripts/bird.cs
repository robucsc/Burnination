using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{
    public float speed = 0.0f;
    // Start is called before the first frame update
    void Awake()
    {
        speed = -6.0f;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(speed,GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
    }
}

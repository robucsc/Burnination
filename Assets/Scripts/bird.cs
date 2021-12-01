using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{
    public float speed = 0.0f;

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Transform>().position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
}

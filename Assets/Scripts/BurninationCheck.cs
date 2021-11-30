using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurninationCheck : MonoBehaviour
{
    public bool BurninateFence;

    void Update()
    {
        BurninateFence = false;
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Fence"){
            //Debug.Log("fence collided");
            BurninateFence = true;
        }
    }
}
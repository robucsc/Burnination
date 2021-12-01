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
        if(col.gameObject.tag == "Fence" && !col.gameObject.GetComponent<FenceBurnination>().burning){
            //Debug.Log("fence collided");
            BurninateFence = true;
            col.gameObject.GetComponent<FenceBurnination>().burning = true;
        }
    }
}
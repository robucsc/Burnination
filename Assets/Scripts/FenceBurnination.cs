using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceBurnination : MonoBehaviour
{
    public ParticleSystem smoke;
    public ParticleSystem flame;
    public BurninationCheck burninationCheck;
    

    void Start()
    {
        smoke.Pause();
        flame.Pause();
    }

    void Update(){
        if(burninationCheck.BurninateFence){
            Debug.Log("fence hit");
            smoke.Play();
            flame.Play();
        } 
    }
}

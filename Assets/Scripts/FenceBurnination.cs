using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FenceBurnination : MonoBehaviour
{
    public ParticleSystem smoke;
    public ParticleSystem flame;
    public BurninationCheck burninationCheck;
    public float burning_duration = 5;
    public bool burning;

    void Start()
    {
        smoke.Pause();
        flame.Pause();
        burning = false;
    }

    void Update(){
        if(burninationCheck.BurninateFence){
           StartCoroutine(BurnCoroutine());
        }

        if(burning){
            //Debug.Log("fence hit");
            smoke.Play();
            flame.Play();
            this.GetComponent<Collider>().isTrigger = true;
        } else {
            smoke.Clear();
            smoke.Pause();
            flame.Clear();
            flame.Pause();
            this.GetComponent<Collider>().isTrigger = false;
        }
    }

    IEnumerator BurnCoroutine(){
        FindObjectOfType<AudioManager>().Play("fire_crackle");
        Debug.Log("audio playing");
        burning = true;
        yield return new WaitForSeconds(burning_duration);
        burning = false;
    }

}

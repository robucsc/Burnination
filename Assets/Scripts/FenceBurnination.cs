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
    public AudioClip crackle;
    public AudioManager myAudioManager;
    public bool SoundOn;
    public float crackle_duration = 5;




    void Start()
    {
        smoke.Pause();
        flame.Pause();
        burning = false;
        SoundOn = false;
        myAudioManager = FindObjectOfType<AudioManager>();

    }

    void Update(){
        if(burninationCheck.BurninateFence){
           StartCoroutine(ExampleCoroutine());
           StartCoroutine(SoundCoroutine());
        }

        if(burning){
            Debug.Log("fence hit");
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
        if (SoundOn)
        {
            FindObjectOfType<AudioManager>().Play("fire_crackle");
            Debug.Log("audio playing");
        }
    }

    IEnumerator ExampleCoroutine(){
        burning = true;
        yield return new WaitForSeconds(burning_duration);
        burning = false;
    }

    IEnumerator SoundCoroutine()
    {
        SoundOn = true;
        yield return new WaitForSeconds(crackle_duration);
        SoundOn = false;
    }


}

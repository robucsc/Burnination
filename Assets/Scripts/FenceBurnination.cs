using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FenceBurnination : MonoBehaviour
{
    public ParticleSystem smoke;
    public ParticleSystem flame;
    public BurninationCheck burninationCheck;
    public MeshRenderer meshRenderer;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public float burning_duration = 5;
    public bool burning;
    public bool startCor;

    void Start()
    {
        smoke.Pause();
        flame.Pause();
        burning = false;
        startCor = true;
    }

    void Update(){
        if(burning){
            //Debug.Log("fence hit");
            smoke.Play();
            flame.Play();
            this.GetComponent<Collider>().isTrigger = true;
            if(startCor){
                StartCoroutine(BurnCoroutine());
                StartCoroutine(SmokeCoroutine());
                startCor = false;

            }
        } else {
            flame.Clear();
            flame.Pause();
            //this.GetComponent<Collider>().isTrigger = false;
        }
    }

    IEnumerator BurnCoroutine(){
        this.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(burning_duration);
        burning = false;
        if(meshRenderer){
            meshRenderer.enabled = false;
        } else {
            skinnedMeshRenderer.enabled = false;
        }
    }

    IEnumerator SmokeCoroutine(){
        yield return new WaitForSeconds(burning_duration * 2);
        this.GetComponent<AudioSource>().Stop();
        smoke.Clear();
        smoke.Pause();
        this.GetComponent<Collider>().enabled = false;
    }

}

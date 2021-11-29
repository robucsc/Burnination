using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burninate : MonoBehaviour
{
    public ParticleSystem burninate_effect;
    public GameObject burninate_hitbox;
    public float burninate_duration;
    public bool burninateActive = false;

    // Update is called once per frame
    void Update()
    {
        if(!burninateActive){
            if(Input.GetKeyDown("space")){
                StartCoroutine(ExampleCoroutine());
            }
        }

        if(burninateActive){
            //Debug.Log("burninate start");
            burninate_effect.Play();
            burninate_hitbox.SetActive(true);
        } else {
            burninate_effect.Clear();
            burninate_effect.Pause();
            burninate_hitbox.SetActive(false);
            //Debug.Log("burninate stop");
        }
    }

    IEnumerator ExampleCoroutine(){
        burninateActive = true;
        yield return new WaitForSeconds(burninate_duration);
        burninateActive = false;
    }
}

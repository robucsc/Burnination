using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burninate : MonoBehaviour
{
    public ParticleSystem burninate_effect;
    public GameObject burninate_hitbox;
    public CharacterMove characterMove;
    public float burninate_duration;
    private float saved_burninate_duration;
    public bool burninateActive;
    public bool FloatingActive;
    private bool swapFloat;

    void Start()
    {
        saved_burninate_duration = burninate_duration;
    }
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
        if(!burninateActive && !swapFloat){
            burninateActive = true;
            burninate_duration = saved_burninate_duration;
        }
        if(!FloatingActive && swapFloat){
            FloatingActive = true;
            burninate_duration = 0.1f;
        }
        yield return new WaitForSeconds(burninate_duration);
        burninateActive = false;
        FloatingActive = false;
        swapFloat = false;
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.GetComponent<FenceBurnination>().burning){
            Debug.Log("player hit burnt fence");
            swapFloat = true;
            StartCoroutine(ExampleCoroutine());

        }
    }
}

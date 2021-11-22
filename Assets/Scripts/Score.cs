using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    private bool wasPickedUp = false;
	public GameObject myJumps;
	public GameObject myPlayer;
    public GameObject myScore;
    public GameObject myStuns;
	public bool pickedUp;
    
    
    // Start is called before the first frame update
    void Start() {
        myPlayer = GameObject.Find("Player");
        myScore = GameObject.Find("ScoreUI");
    }

    // Update is called once per frame
    void Update() {
        var transform = this.GetComponent<Transform>();
        transform.localRotation *= Quaternion.Euler(0.0f, 0.0f, 200.0f * Time.deltaTime);
        if (wasPickedUp) {
            transform.localScale *= 0.8f;
        }
    }
    
    void OnTriggerEnter(Collider collider) {   
        // Debug.Log("on the trigger");
        // if (collider.gameObject.CompareTag("Player") && !pickedUp) {
        //     pickedUp = true;
        //     myPlayer.GetComponent<Player>().ScoreCount += 500;
        //     myScore.GetComponent<UnityEngine.UI.Text>().text = "Score: " + myPlayer.GetComponent<Player>().ScoreCount;
        //     // Debug.Log("something collided with us");
        //     FindObjectOfType<AudioManager>().Play("beem");
        //     // Debug.Log("Did it play?");
        //     Destroy(gameObject, 1.5f);
        //     wasPickedUp = true;
        }
    }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/

public class Timer : MonoBehaviour {
    public float timeRemaining = 120;
    public bool timerIsRunning = false;
    public Text timeText;
    public GameObject myGameOver;
    
    private void Start() {
        // Starts the timer automatically
        timerIsRunning = true;
        myGameOver = GameObject.Find("GameOver");
    }

    void Update() {
        
        if (timerIsRunning) {
            if (timeRemaining > 0) {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            } else {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                myGameOver.GetComponent<Text>().enabled = true;
            }
        }
    }

    void DisplayTime(float timeToDisplay) {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("Time: " + "{0:00}:{1:00}", minutes, seconds);
    }
    
    // SceneManager.LoadScene
}

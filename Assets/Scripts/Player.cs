using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour {
    // Update is called once per frame
    
    public float speed = 5000.0f;
    public float turnSpeed = 5.0f;
    private Vector3 startPosition;
    public int ScoreCount = 0;
    public Text text;
    public GameObject myTimer;
    public AudioManager myAudioManager;
    [SerializeField] private GameObject powerUpPrefab;
    [SerializeField] private GameObject powerUpTimePrefab;
    
    // AudioSource audioSource;
    public float minPitch = 1.0f;
    private float pitchFromCar;

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("beem");
        myAudioManager = FindObjectOfType<AudioManager>();
        myAudioManager.Play("landspeeder");
        myAudioManager.PitchMod("landspeeder", minPitch);
        
        myTimer = GameObject.Find("TimeKeeper");
        this.startPosition = this.transform.position;
    }

    void FixedUpdate()
    {
        var rigidbody = this.GetComponent<Rigidbody>();
        var transform = this.GetComponent<Transform>();
        bool running = true;
        // Gas pedal and brakes
        var force = this.speed * Input.GetAxis("Vertical") * Time.deltaTime;
        running = myTimer.GetComponent<Timer>().timerIsRunning;

        if (running)
        {
            Vector3 direction = transform.forward;
            rigidbody.AddForce(force * direction);
        }

        // Turning
        var turnDirection = 1.0f;
        if (Vector3.Dot(transform.forward, rigidbody.velocity) < 0.0f)
        {
            turnDirection = -1.0f;
        }

        rigidbody.MoveRotation(transform.localRotation * Quaternion.Euler(
            0.0f,
            turnDirection *
            rigidbody.velocity.magnitude *
            this.turnSpeed * Input.GetAxis("Horizontal") *
            Time.deltaTime,
            0.0f));

        pitchFromCar = force * 0.015f;
        if (pitchFromCar < minPitch) {
            myAudioManager.PitchMod("landspeeder", minPitch);
        } else  {
            myAudioManager.PitchMod("landspeeder", pitchFromCar);
        }
   
    }

    public void ResetPosition() {
        this.transform.position = this.startPosition;
        
    }

    public void SetMasterVolume(float value) {
        this.speed = 6000.0f * value;
        // this.text.text = "Speed: " + (int)(value * 100.0) + "%";
    }
}

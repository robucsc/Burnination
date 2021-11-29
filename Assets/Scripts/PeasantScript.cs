using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeasantScript : MonoBehaviour
{
    public string state = "idle";
    private float moveSpeed = 0.0f;
    private float moveTime = 2.0f;
    private float idleTime = 5.0f;
    
    // Awake is called when an instance of this script is created
    void Awake()
    {
        //Get the Animator attached to the GameObject you are intending to animate.
        // m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // establish movement
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed,GetComponent<Rigidbody2D>().velocity.y);

        if (state == "burning")
        {
            // move quickly in a direction
            // apply burning effect
            // play running animation
            // destroy eventually
        }
        else if (state == "walking")
        {
            // move in a direction for moveTime seconds at random speed 
            moveTime -= Time.deltaTime;
            if (moveSpeed == 0.0f)
            {
                moveSpeed = Random.Range(-1.0f, 1.0f);
            }

            if (moveTime <= 0.0)
            {
                moveSpeed = -moveSpeed;
                idleTime = 5.0f;
                state = "idle";
            }
            // play walking animation
            // m_Animator.ResetTrigger("idle");
            // m_Animator.SetTrigger("walking");
        }
        else
        {
            // start idletimer, stop moving
            idleTime -= Time.deltaTime;
            moveSpeed = 0.0f;
            if (idleTime <= 0.0)
            {
                moveTime = 1.0f;
                state = "walking";
            }
            
            // play idle animation
            // m_Animator.ResetTrigger("walking");
            // m_Animator.SetTrigger("idle");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeasantScript : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;
    Animator m_Animator;
    public string state = "idle";
    private float moveSpeed = 0.0f;
    private float moveTime = 2.0f;
    private float idleTime = 5.0f;
    
    // Awake is called when an instance of this script is created
    void Awake()
    {
        //Get the Animator attached to the GameObject you are intending to animate.
        m_Animator = gameObject.GetComponent<Animator>();

        // Get the SpriteRenderer attatched to the GameObject you are intending to uhhhh render???
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
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
                if (moveSpeed >= 0.0f)
                {
                    m_SpriteRenderer.flipX = true;
                }
                else
                {
                    m_SpriteRenderer.flipX = false; 
                }
            }

            if (moveTime <= 0.0 || (moveSpeed < 0.3f && moveSpeed > -0.3f))
            {
                moveSpeed = -moveSpeed;
                idleTime = Random.Range(3.0f, 5.0f);
                state = "idle";
            }
            // play walking animation
            m_Animator.SetTrigger("walking");
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
            m_Animator.ResetTrigger("walking");
        }
    }
}

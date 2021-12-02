using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;
    Animator m_Animator;
    [SerializeField] private float detectRange = 5.0f;
    public Transform playerLoc;
    private string state = "idle";
    private float moveSpeed = 0.0f;
    [SerializeField] private float maxSpeed = 1.0f;
    [SerializeField] private float minSpeed = 0.3f;
    private float moveTime = 2.0f;
    private float idleTime = 5.0f;
    // Only necessary if NPC is 3D. 
    private bool facingLeft = true;
    // IMPORTANT. CHECK IF APPLICABLE. 
    [SerializeField] private bool is3D = true;
    // This one's less important, just saves you error spam. 
    // IF YOU DO ANIMATE, this script ONLY toggles a walking boolean. What that does can be managed from the animator window, but you have to set that part up yourself. 
    [SerializeField] private bool isAnimated = true;
    // determines what the NPC does once Trogdor enters collision box. 
    [SerializeField] private bool Cowardice = true;
    
    void TurnCheck()
    {
                        
        // turns the npc around if necessary
        if (moveSpeed >= 0.0f)
        {
            if (is3D && facingLeft)
            {
                // rotate the model 
                this.GetComponent<Transform>().eulerAngles = new Vector3(180.0f, GetComponent<Transform>().eulerAngles.y, 180);

            }
            else if (!is3D) m_SpriteRenderer.flipX = true;
            facingLeft = false;
                    
        }
        else
        {
            if (is3D && !facingLeft)
            {
                // rotate the model 
                this.GetComponent<Transform>().eulerAngles = new Vector3(180.0f, GetComponent<Transform>().eulerAngles.y, 180);
                        
            }
            else if (!is3D) m_SpriteRenderer.flipX = false;
            facingLeft = true;
        }
    }
    // Awake is called when an instance of this script is created
    void Awake()
    {
        // Get the Animator attached to the GameObject.
        if (isAnimated) m_Animator = gameObject.GetComponent<Animator>();

        // Get the SpriteRenderer if GameObject is a sprite. 
        if (!is3D)
        {
            // gets components for 2D objects
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (is3D)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(moveSpeed,GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
        }
        
        if (Vector3.Distance(playerLoc.position, transform.position) <= detectRange)
        {
            state = "playerDetected";
        }
    
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
                moveSpeed = Random.Range(-maxSpeed, maxSpeed);
                TurnCheck();
            }

            if (moveTime <= 0.0 || (moveSpeed < minSpeed && moveSpeed > -minSpeed))
            {
                moveSpeed = -moveSpeed;
                idleTime = Random.Range(3.0f, 5.0f);
                // start idle animation
                if (isAnimated) m_Animator.SetBool("walking", false);
                state = "idle";
            }
            
        }
        else if (state == "playerDetected")
        {
            // run away if Cowardice is true, else run towards player
            if (playerLoc.position.x > this.GetComponent<Transform>().position.x)
            {
                if (Cowardice) moveSpeed = Random.Range(-minSpeed, -maxSpeed);
                else moveSpeed = Random.Range(minSpeed, maxSpeed);
                TurnCheck();
            }
            else 
            {
                if (Cowardice) moveSpeed = Random.Range(minSpeed, maxSpeed);
                else moveSpeed = Random.Range(-minSpeed, -maxSpeed);
                TurnCheck();
            }
        }
        else
        {
            // start idletimer, stop moving
            idleTime -= Time.deltaTime;
            moveSpeed = 0.0f;

            // switch to walking once timer is up 
            if (idleTime <= 0.0)
            {
                moveTime = 1.0f;
                // start walking animation
                if (isAnimated) m_Animator.SetBool("walking", true);
                state = "walking";
            }
            
            
        }
    }
}

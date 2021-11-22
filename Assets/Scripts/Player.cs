using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour {
    
    // AudioSource audioSource;
    
    public float maxSpeed = 10;
    public Rigidbody rb;
    private Collision coll;
    public LayerMask groundLayer;
    private AnimationScript anim;
    Rigidbody PlayerRb;
    BoxCollider boxCollider;
    
    public float upwardForce = 25;
    public float sidewaysForce = 20f;
    public bool onGround;
    public bool isFalling;
    public bool isFlying;
    public bool isDirection;
    public float terminalVelocity = -12;
    public float fastFallTV = -24;
    public bool canMove;

    void Start()
    {
        coll = GetComponent<Collision>();
        rb = GetComponent<Rigidbody>();
        PlayerRb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey("right")) {
            if (sidewaysForce * Time.deltaTime < maxSpeed)
            {
                rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.Impulse);
            }
            else
            {
                rb.velocity = new Vector3(maxSpeed, 0, 0);
            }
            
            
        }
        
        if (Input.GetKey("left")) {
            if (sidewaysForce * Time.deltaTime < maxSpeed)
            {
                rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.Impulse);
            }
            else
            {
                rb.velocity = new Vector3(-maxSpeed, 0, 0);
            }
        }
    }

    void Update()
    {
        // float x = Input.GetAxis("Horizontal");
        // float y = Input.GetAxis("Vertical");
        // float xRaw = Input.GetAxisRaw("Horizontal");
        // float yRaw = Input.GetAxisRaw("Vertical");
        // Vector2 dir = new Vector2(x, y);
        //
        // if (xRaw < 0 || xRaw > 0)
        //     isDirection = true;
        // else
        //     isDirection = false;
        //
        // Walk(dir);
        // anim.SetHorizontalMovement(x, y, rb.velocity.y);
        // onGround = groundCheck();
        //
        // if (rb.velocity.y < 0)
        // {
        //     isFlying = false;
        //     isFalling = true;
        // }
        // else
        // {
        //     isFalling = false;
        // }
        //
        //
        // if (isFalling)
        // {
        //     if (rb.velocity.y < terminalVelocity)
        //     {
        //         if (Input.GetAxis("Vertical") < 0)
        //         {
        //             if (rb.velocity.y < fastFallTV)
        //             {
        //                 rb.velocity = new Vector2(rb.velocity.x, fastFallTV);
        //             }
        //         }
        //         else
        //         {
        //             rb.velocity = new Vector2(rb.velocity.x, terminalVelocity);
        //         }
        //     }
        // }
    }

    // private bool groundCheck(){
    //     Quaternion myQuat = 0, 0, 0, 0;
    //     RaycastHit hit = Physics.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size,  Vector3.down, myQuat, 1.0f,   groundLayer);
    //     return hit.collider != null;
    // }
    //
    // private void Walk(Vector2 dir)
    // {
    //     if (!canMove)
    //     {
    //         return;
    //     }
    // }
    //
    // void RigidbodyDrag(float x)
    // {
    //     rb.drag = x;
    // }    
            
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{

    private Animator anim;
    private Player move;
    private Collision coll;
    [HideInInspector]
    public SpriteRenderer sr;

    void Start()
    {
        anim = GetComponent<Animator>();
        coll = GetComponentInParent<Collision>();
        move = GetComponentInParent<Player>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // anim.SetBool("onGround", coll.onGround);

        anim.SetBool("canMove", move.canMove);
        anim.SetBool("isFlying", move.isFlying);

    }

    public void SetHorizontalMovement(float x,float y, float yVel)
    {
        anim.SetFloat("HorizontalAxis", x);
        anim.SetFloat("VerticalAxis", y);
        anim.SetFloat("VerticalVelocity", yVel);
    }

    public void SetTrigger(string trigger)
    {
        anim.SetTrigger(trigger);
    }

    // public void Flip(int side)
    // {
    //
    //     if (move.wallGrab || move.wallSlide)
    //     {
    //         if (side == -1 && sr.flipX)
    //             return;
    //
    //         if (side == 1 && !sr.flipX)
    //         {
    //             return;
    //         }
    //     }
    //
    //     bool state = (side == 1) ? false : true;
    //     sr.flipX = state;
    // }
}
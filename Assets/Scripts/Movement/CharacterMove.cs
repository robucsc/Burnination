﻿using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMove : MonoBehaviour
{
    private PlayerControls controls;
    
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _jumpSpeed = 0.5f;
    [SerializeField] private float _gravity = 0.4f;
    [SerializeField] private float _fallingGravity = 0.4f;
    [SerializeField] private float _burninatePushSpeed = 0.0f;
    private bool midairJump;
    
    public CharacterController _characterController;
    private Vector3 _moveDirection;
    //private Vector3 transformDirection;
    private bool right;
    private bool goingDown;
    private float previous_position_y = 0f;

    public Burninate burninate;

    // void Awake() => _characterController = GetComponent<CharacterController>();
    
    void Awake() {
        _characterController = GetComponent<CharacterController>();
        
        //gamepad code
        controls = new PlayerControls();
        controls.Gameplay.Burninate.performed += ctx => burn();
    }

    void Start()
    {
        right = true;
    }
    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");

        Vector3 inputDirection = new Vector3(horizontal, 0, 0);
        //transformDirection = transform.TransformDirection(-inputDirection);
        
        Vector3 flatMovement = _moveSpeed * Time.deltaTime * inputDirection;
        _moveDirection = new Vector3(flatMovement.x, _moveDirection.y , flatMovement.z);
        
        if (PlayerJumped){  
            _moveDirection.y = _jumpSpeed;
            midairJump = true;
            goingDown = false;
            //Debug.Log("player jumped");
        }
        else if (_characterController.isGrounded){
            //Debug.Log("player grounded");
            _moveDirection.y -= _gravity;
            midairJump = false;
            goingDown = false;
            this.GetComponent<Transform>().eulerAngles = new Vector3(-90, 90, 0);
        } else if (!_characterController.isGrounded){
            //Debug.Log("player not grounded");
            if(this.GetComponent<Transform>().position.y < previous_position_y){
                goingDown = true;
            }
            
            
            _moveDirection = new Vector3(0f, _moveDirection.y, 0f);
            //Vector3 final_rotation;
            Vector3 current_rotation = this.GetComponent<Transform>().eulerAngles;

            previous_position_y = this.GetComponent<Transform>().position.y;
        }

        if(!right){
            //Debug.Log("facing right");
            /*final_rotation = new Vector3 (0f, 0f, -180f);
            Vector3 euler_rotation = Vector3.Lerp(current_rotation, final_rotation, 0.01f);
            this.GetComponent<Transform>().eulerAngles = euler_rotation;*/
            this.GetComponent<Transform>().eulerAngles = new Vector3(-90, 90, -180f);
        } else {
            //Debug.Log("facing left");
            this.GetComponent<Transform>().eulerAngles = new Vector3(-90, 90, 0f);
        }

        if(Input.GetAxis("Horizontal") > 0){
            right = true;
        } else if(Input.GetAxis("Horizontal") < 0){
            right = false;
        }

        if(midairJump && Input.GetKeyDown("space")){
            Debug.Log("Jumped!");
            if(!right){
                _moveDirection.x += _burninatePushSpeed;
            } else {
                _moveDirection.x -= _burninatePushSpeed;
            }
        }

        /*if(midairJump){
            Debug.Log("can midair jump");
        } else {
            Debug.Log("can't midair jump");
        }*/

        _characterController.Move(_moveDirection);
    }

    void FixedUpdate()
    {
        if(!goingDown){
            Debug.Log("floating up");
            _moveDirection.y -= _gravity * Time.deltaTime;
        } else {
            Debug.Log("floating down");
            _moveDirection.y -= _fallingGravity * Time.deltaTime;
        }
    }

    private bool PlayerJumped => _characterController.isGrounded && burninate.FloatingActive;

    void burn()
    {
        // press the space bar
        Debug.Log("Burninate!");
    }

    // gamepad code
    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
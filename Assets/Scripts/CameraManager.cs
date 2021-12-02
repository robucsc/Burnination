using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject player;
    public GameObject main_camera;
    public CharacterMove characterMove;
    public float distance;
    public float height;
    public bool adjust_camera_now;
    private float cameraLerp;

    void Start()
    {
        adjust_camera_now = false;
    }

    // Update is called once per frame
    void Update()
    {
        //initializing camera and player position variables
        var camera_transform = main_camera.GetComponent<Transform>();
        var player_transform = player.GetComponent<Transform>();
        var player_pos = player.transform.position;
        
        //target_camera_pos refers to where the camera should be in relation to player_pos
        var target_camera_pos = player_pos;

        cameraLerp = 0.03f;
        
        if(characterMove._characterController.isGrounded){
            target_camera_pos += new Vector3(this.distance, this.height, -5);
        } else {
            target_camera_pos += new Vector3(this.distance, this.height, -7);
            cameraLerp = 0.1f;
        }
        
        //current_camera_position 
        var current_camera_position = camera_transform.position;
        if(adjust_camera_now){
            camera_transform.position = Vector3.Lerp(current_camera_position, target_camera_pos, cameraLerp);
        }
        
        if(camera_transform.position == target_camera_pos){
            adjust_camera_now = false;
        }
        
    }
    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.GetComponent<CharacterMove>()){
            adjust_camera_now = true;
        }
    }
}

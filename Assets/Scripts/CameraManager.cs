using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject player;
    public CharacterMove characterMove;
    public float distance;
    public float height;

    // Update is called once per frame
    void Update()
    {
        //initializing camera and player position variables
        var camera_transform = this.GetComponent<Transform>();
        var player_transform = player.GetComponent<Transform>();
        var player_pos = player.transform.position;
        
        //target_camera_pos refers to where the camera should be in relation to player_pos
        var target_camera_pos = player_pos;
        if(characterMove._characterController.isGrounded){
            target_camera_pos += new Vector3(this.distance, this.height, -5);
        } else {
            target_camera_pos += new Vector3(this.distance, this.height, -7);
        }
        
        //current_camera_position 
        var current_camera_position = camera_transform.position;
        camera_transform.position = Vector3.Lerp(current_camera_position, target_camera_pos, 0.01f);
    }
}

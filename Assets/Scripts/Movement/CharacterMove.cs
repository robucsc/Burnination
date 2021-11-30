using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _jumpSpeed = 0.5f;
    [SerializeField] private float _gravity = 0.4f;
    [SerializeField] private float _burninatePushSpeed = 0.0f;
    private bool midairJump;
    
    public CharacterController _characterController;
    private Vector3 _moveDirection;

    public Burninate burninate;

    void Awake() => _characterController = GetComponent<CharacterController>();
    void FixedUpdate()
    {
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 inputDirection = new Vector3(0, horizontal, vertical);
        Vector3 transformDirection = transform.TransformDirection(-inputDirection);
        
        Vector3 flatMovement = _moveSpeed * Time.deltaTime * transformDirection;
        _moveDirection = new Vector3(flatMovement.x, _moveDirection.y , flatMovement.z);
        
        if (PlayerJumped){
            _moveDirection.y = _jumpSpeed;
            midairJump = true;
            //Debug.Log("player jumped");
        }
        else if (_characterController.isGrounded){
            //Debug.Log("player grounded");
            _moveDirection.y -= _gravity;
            midairJump = false;
        } else if (!_characterController.isGrounded){
            //Debug.Log("player not grounded");
            _moveDirection.y -= _gravity * Time.deltaTime;
            _moveDirection = new Vector3(0f, _moveDirection.y, 0f);
            
        }
        if(midairJump && Input.GetKeyDown("space")){
            Debug.Log("Jumped!");
            _moveDirection = _burninatePushSpeed * transformDirection;
            midairJump = false;
        }

        if(midairJump){
            Debug.Log("can midair jump");
        } else {
            Debug.Log("can't midair jump");
        }

        _characterController.Move(_moveDirection);
    }

    private bool PlayerJumped => _characterController.isGrounded && burninate.FloatingActive;
}
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _jumpSpeed = 0.5f;
    [SerializeField] private float _gravity = 0.4f;
    [SerializeField] private float _burninatePushSpeed = 0.0f;
    
    private bool midairJump;
    
    CharacterController _characterController;
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
            midairJump = false;
        }
        else if (_characterController.isGrounded){
            _moveDirection.y = 0f;
        } else if (!_characterController.isGrounded){
            _moveDirection.y -= _gravity * Time.deltaTime;
        }
        if(!_characterController.isGrounded){
            _moveDirection = new Vector3(0f, _moveDirection.y, 0f);
            if(Input.GetKeyDown("space") && !midairJump){
                Debug.Log("push!");
                _moveDirection = _burninatePushSpeed * transformDirection;
                midairJump = true;
            }
        }

        _characterController.Move(_moveDirection);
    }

    private bool PlayerJumped => _characterController.isGrounded && burninate.FloatingActive;
}
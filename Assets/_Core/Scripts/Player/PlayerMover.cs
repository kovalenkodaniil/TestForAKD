using DefaultNamespace;
using UnityEngine;
using Zenject;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Transform _cameraPosition; 
    
    private float _mouseSensitivity;
    private float _playerSpeed;
    private float _verticalAngle;
    private float _horizontalAngle ;
    private float _verticalSpeed;

    private CharacterController characterController;
    
    [Inject]
    private void Construct(PlayerConfig playerConfig)
    {
        _playerSpeed = playerConfig.speed;
        _mouseSensitivity = playerConfig.mouseSensitivity;
        
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleMovement();
        HandleMouseLook();
    }


    void HandleMovement()
    {
        float speed = _playerSpeed;

        float moveHorizontal = SimpleInput.GetAxis("Horizontal");
        float moveVertical = SimpleInput.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(moveHorizontal, 0, moveVertical).normalized;

        if (moveDirection.magnitude > 1.0f)
            moveDirection.Normalize();

        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed * Time.deltaTime;
        
        _verticalSpeed += Physics.gravity.y * Time.deltaTime;
        moveDirection.y = _verticalSpeed * Time.deltaTime;

        characterController.Move(moveDirection);
    }

    void HandleMouseLook()
    {
        float mouseX = 0;
        float mouseY = 0;
        
        mouseX = SimpleInput.GetAxis("LookX") * _mouseSensitivity;
        mouseY = -SimpleInput.GetAxis("LookY") * _mouseSensitivity;

        _horizontalAngle += mouseX;
        _verticalAngle = Mathf.Clamp(_verticalAngle + mouseY, -89.0f, 89.0f);

        transform.localRotation = Quaternion.Euler(0.0f, _horizontalAngle, 0.0f);
        _cameraPosition.localRotation = Quaternion.Euler(_verticalAngle, 0.0f, 0.0f);
    }
}
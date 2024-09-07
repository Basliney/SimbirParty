using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _cameraTransform;

    private PlayerInput _playerInput;
    private Vector2 _moveDirection;

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void Update()
    {
        _moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();

        Move();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Move()
    {
        if (_moveDirection.sqrMagnitude < 0.1f)
            return;

        Vector3 forward = Vector3.forward;  // _cameraTransform.forward;
        Vector3 right = Vector3.right;  // _cameraTransform.right;

        //forward.y = 0f;
        //right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 direction = forward * _moveDirection.y + right * _moveDirection.x;
        transform.rotation = Quaternion.LookRotation(direction);
        float scaledMoveSpeed = _moveSpeed * Time.deltaTime;
        Vector3 offset = direction * scaledMoveSpeed;

        transform.Translate(offset, Space.World);
    }

    private float GetAngleByDirection(Vector3 direction)
    {
        float angle = 0f;
        direction *= 180;

        angle = -90 + (direction.x + direction.z)/2;
        return angle;
    }
}

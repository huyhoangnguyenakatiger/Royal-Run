using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 movement;
    Rigidbody rigidBody;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float xClamp = 4;
    [SerializeField] float zClamp = 3;
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    public void FixedUpdate()
    {
        HandleMovement();
    }
    void HandleMovement()
    {
        Vector3 currentPosition = rigidBody.position;
        Vector3 moveDirection = new Vector3(movement.x, 0f, movement.y);
        Vector3 newPosition = currentPosition + moveDirection * (moveSpeed * Time.fixedDeltaTime);
        newPosition.x = Mathf.Clamp(newPosition.x, -xClamp, xClamp);
        newPosition.z = Mathf.Clamp(newPosition.z, -zClamp, zClamp);
        rigidBody.MovePosition(newPosition);
    }
    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
}

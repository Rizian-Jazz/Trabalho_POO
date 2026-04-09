using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(PlayerInput))]
public class PlayerCharacterController : BaseCharacterController
{

    private PlayerInput playerInput;
    void Update()
    { 
      Move();      
    }
    protected override void Awake()
    {   
        base.Awake();        
        playerInput = GetComponent<PlayerInput>();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 inputDirection = context.ReadValue<Vector2>();
        direction = inputDirection;
        Debug.Log("is moving");
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Jump();
            Debug.Log("Jump action started");
        }
    }
    public void OnDoubleJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            DoubleJump();
            Debug.Log("DoubleJump action started");
        }
    }
    public void OnSquareWalk(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SquareWalk();
            Debug.Log("SquareWalk action started");
        }
    }
    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Dash();
            Debug.Log("Dash action started");
        }
    }
}



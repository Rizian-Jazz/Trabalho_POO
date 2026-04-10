using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(DashAction))]
[RequireComponent(typeof(SquareWalkAction))]
[RequireComponent(typeof(SquareWalk_Version2))]
public class PlayerCharacterController : BaseCharacterController
{

    private PlayerInput playerInput;
    private DashAction dash;
    private SquareWalkAction squareWalk;
    private SquareWalk_Version2 squareWalkVr2; 
    void Update()
    { 
        if (dash != null && dash.isDashing) return;
        if (squareWalk != null && squareWalk.isWalking) return;
        if(squareWalkVr2 != null && squareWalkVr2.isWalking) return;
        Move(); 

    }
    protected override void Awake()
    {   
        base.Awake();        
        playerInput = GetComponent<PlayerInput>();
        dash = GetComponent<DashAction>();
        squareWalk = GetComponent<SquareWalkAction>();
        squareWalkVr2 = GetComponent<SquareWalk_Version2>();
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
    public void OnSquareWalk2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SquareWalkV2();
            Debug.Log("SquareWalk2 action started");
        }
    }
}



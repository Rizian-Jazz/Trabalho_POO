using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(DoubleJumpAction))]
[RequireComponent(typeof(SquareWalkAction))]
[RequireComponent(typeof(DashAction))]
[RequireComponent(typeof(JumpAction))]
[RequireComponent(typeof(SquareWalk_Version2))]

public abstract class BaseCharacterController : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected BoxCollider2D boxCollider;
    public float moveSpeed = 7f;
    public Vector2 direction;

    [Header("Actions")]
    protected DoubleJumpAction doubleJumpAction;
    protected SquareWalkAction squareWalkAction;
    protected DashAction dashAction;
    protected JumpAction jumpAction;
    protected SquareWalk_Version2 squareWalkV2;


    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        doubleJumpAction = GetComponent<DoubleJumpAction>();
        squareWalkAction = GetComponent<SquareWalkAction>();
        dashAction = GetComponent<DashAction>();
        jumpAction = GetComponent<JumpAction>();
        squareWalkV2 = GetComponent<SquareWalk_Version2>();

    }

    virtual public void Move()
    {
        rb.linearVelocity = new Vector2(direction.x * moveSpeed, rb.linearVelocity.y);     
    }

    virtual public void DoubleJump()
    {   
        if (doubleJumpAction != null)
        doubleJumpAction.Use();
    }
    virtual public void SquareWalk()
    {   
        if (squareWalkAction != null)
        {
            direction = Vector2.zero;
            squareWalkAction.Use();
        }
    }
    virtual public void Dash()
    {   
        if (dashAction != null)
        dashAction.Use();
    }
    virtual public void Jump()
    {   
        if (jumpAction != null)
        jumpAction.Use();
    }
    virtual public void SquareWalkV2()
    {
        if(squareWalkV2 != null)
        {
            direction = Vector2.zero;
            squareWalkV2.Use();
        }
    }

}

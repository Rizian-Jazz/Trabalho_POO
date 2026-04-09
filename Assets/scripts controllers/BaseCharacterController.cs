using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(DoubleJumpAction))]
[RequireComponent(typeof(SquareWalkAction))]
[RequireComponent(typeof(DashAction))]
[RequireComponent(typeof(JumpAction))]

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

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        doubleJumpAction = GetComponent<DoubleJumpAction>();
        squareWalkAction = GetComponent<SquareWalkAction>();
        dashAction = GetComponent<DashAction>();
        jumpAction = GetComponent<JumpAction>();
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
        squareWalkAction.Use();
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

}

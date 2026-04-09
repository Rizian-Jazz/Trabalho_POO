using UnityEngine;
public class DoubleJumpAction : ActionModel
{
    public Transform groundCheck;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.1f); 
    public LayerMask groundLayer = ~0;
    public float jumpForce = 7f;
    public bool canDoubleJump = true; 
    private int jumpCount = 0;
    protected override void Awake()
    {
        base.Awake();
        if(groundCheck == null)
        {
            GameObject groundCheckObj = new GameObject("GroundCheck");
            groundCheckObj.transform.SetParent(transform, false);
            groundCheckObj.transform.localPosition = new Vector3(0, -0.5f, 0);
            groundCheck = groundCheckObj.transform;
        }
    }
    public override void Use()
    {
        if (!CanUseAction()) return;
        if(IsGrounded())
        {
            JumpAction();
            jumpCount = 1;
        }
        else if (canDoubleJump && jumpCount < 2)
        {
            JumpAction();
            jumpCount = 2;
        }
        if (!IsGrounded() && jumpCount >= 2)
        {
            canDoubleJump = false;
        }
    }
    private bool IsGrounded()
    {
        bool grounded = Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0, groundLayer);
        if (grounded)
        {
            this.jumpCount = 0;
            return grounded;
        }   
        return false;  
    }

    public void JumpAction()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }
}
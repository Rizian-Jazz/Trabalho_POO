using UnityEngine;
public class DoubleJumpAction : ActionModel
{
    public Transform groundCheck;
    public Vector2 groundCheckSize = new(0.5f, 0.2f); 
    public LayerMask groundLayer;
    public float jumpForce = 7f;
    public bool canDoubleJump;
    public int jumpCount = 0, maxJumps = 2;
    protected override void Awake()
    {
        base.Awake();
        if(groundCheck == null)
        {
            GameObject groundCheckObj = new("GroundCheck");
            groundCheckObj.transform.SetParent(transform, false);
            groundCheckObj.transform.localPosition = new Vector2(0, -0.6f);
            
            groundCheck = groundCheckObj.transform;
        }
    }

    void Update()
    {
       bool touchingGround = IsGrounded();

        
        if (touchingGround && rb.linearVelocity.y <= 0.1f)
        {
            if (jumpCount != 0)
            {
                Debug.Log("Chão detectado! Resetando pulos.");
                jumpCount = 0;
            }
        }
       
    }
    public override void Use()
    {
        if (!CanUseAction()) return;
        if (jumpCount < maxJumps)
        {
           JumpAction();         
        }                

    }
    private bool IsGrounded()
    {
       
        Collider2D hit = Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0, groundLayer);
        return hit != null;
    }

    public void JumpAction()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        jumpCount++;
    }

  
}
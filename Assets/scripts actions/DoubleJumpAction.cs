using UnityEngine;
public class DoubleJumpAction : ActionModel
{
    public Transform groundCheck;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.1f); 
   
    public float jumpForce = 7f;
    private int jumpCount = 0;
    protected override void Awake()
    {
        base.Awake();
        if(groundCheck == null)
        {
            GameObject groundCheckObj = new GameObject("GroundCheck");
            groundCheckObj.transform.SetParent(transform, false);
            groundCheckObj.transform.localPosition = new Vector3(0, -0.6f, 0);
            groundCheck = groundCheckObj.transform;
        }
    }  
    void Update()
    {
        if (IsGrounded())
        {
            jumpCount = 0;
        }
    }
    public override void Use()
    {
        if (!CanUseAction()) return;
    
        if (jumpCount < 2)
        {            
            JumpAction();
            jumpCount++;
           
        }   
     
    }
   private bool IsGrounded()
    {
        Collider2D hit = Physics2D.OverlapBox(
            groundCheck.position,
            groundCheckSize,
            0
        );

         return hit != null && hit.gameObject != gameObject;
     
    }


    public void JumpAction()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }
  
}
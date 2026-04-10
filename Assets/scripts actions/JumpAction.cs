
using UnityEngine;

public class JumpAction : ActionModel
{
    public Transform groundCheck;
    public Vector2 groundCheckSize = new(0.5f, 0.2f);
    public LayerMask groundLayer;
    public float jumpForce = 7f;

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
    public override void Use()
    {
        if (!CanUseAction()) return;
        if (IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }   
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0, groundLayer);
    }
}

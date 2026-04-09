using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class DashAction : ActionModel
{
    public float dashForce = 20f, dashCooldown = 1f, dashTime = 0.2f;
    public bool isDashing = false, canDash = true;

    private Coroutine DashCoroutine;

    protected override void Awake()
    {
        base.Awake();
    }

    public override void Use()
    {
        if (!CanUseAction() || !canDash || isDashing) return; 

        StartCoroutine(Dash());
        
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;       
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;    

        float direction = 1;

        if (transform.localScale.x < 0) 
        {
            direction = -1; 
        }
        else 
        {
            direction = 1;
        }
        float timer = 0;
        while (timer < dashTime)
        {
        
            rb.linearVelocity = new Vector2(direction * dashForce, 0f);
            timer += Time.deltaTime;
            yield return null; 
        }   
        rb.linearVelocity = new Vector2(direction * dashForce, 0f);     
           
        yield return new WaitForSeconds(dashTime);

        rb.gravityScale = originalGravity;
        rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y); // Para o movimento horizontal
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}





using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class DashAction : ActionModel
{
    public float dashForce = 20f, dashCooldown = 1f, dashCount = 0f, dashTime = 0.2f, MoveSpeed;
    private bool isDashing = false, canDash = true;
    public override void Use()
    {
        if (!CanUseAction()) return;
        
        if (canDash)
        {
            StartCoroutine(Dash());
        }
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;

        float ogMoveSpeed = MoveSpeed;
        MoveSpeed = MoveSpeed * dashForce;

        yield return WaitForSeconds(dashCooldown);
        canDash = true;
        isDashing = false;

        //teste pra ver se agora commita

    }




}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class DashAction : ActionModel
{
    public float dashForce = 20f, dashCooldown = 1f, dashCount = 0f, dashTime = 0.2f, MoveSpeed;
    private bool isDashing = false, canDash = true;

    private Coroutine DashCoroutine;

    protected override void Awake()
    {
        base.Awake();
    }

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
        float originalMoveSpeed = MoveSpeed;
        MoveSpeed *= dashForce;

        yield return WaitForSeconds(dashCooldown);
        canDash = true;
        isDashing = false;
        StopDashing();
    }

    private object WaitForSeconds(float dashCooldown)
    {
        throw new NotImplementedException();
    }

    private void StopDashing()
    {

        if (DashCoroutine != null)
        {
            StopCoroutine(DashCoroutine);
            DashCoroutine = null;
        }
        isDashing = false;
        }
    }



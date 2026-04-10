using UnityEngine;
using System.Collections;
public class SquareWalk_Version2 : ActionModel
{
    public float walkSpeed = 3f, walkDuration = 1f;
    public Vector2[] walkDirections = new Vector2[4] { Vector2.right, Vector2.up, Vector2.left, Vector2.down };
    private int currentDirectionIndex = 0;

    public bool isWalking = false;
    private Coroutine walkInSquareCoroutine;
    private float originalGravityScale;

    protected override void Awake()
    {
        base.Awake();
        originalGravityScale = rb.gravityScale;
    }

    public override void Use()
    {
        if (!CanUseAction()) return;

        if (isWalking)
            StopWalking();
        else
            walkInSquareCoroutine = StartCoroutine(WalkInSquare());
    }

    private IEnumerator WalkInSquare()
    {
        isWalking = true;
        rb.gravityScale = 0f;
        float timer = 0f;

        while (isWalking)
        {
            rb.linearVelocity = walkDirections[currentDirectionIndex] * walkSpeed;
            timer += Time.fixedDeltaTime;

            if (timer >= walkDuration)
            {
                timer = 0f;
                currentDirectionIndex = (currentDirectionIndex + 1) % walkDirections.Length;
            }

            yield return new WaitForFixedUpdate();
        }
    }

    private void StopWalking()
    {
        if (walkInSquareCoroutine != null)
        {
            StopCoroutine(walkInSquareCoroutine);
            walkInSquareCoroutine = null;
        }

        rb.gravityScale = originalGravityScale;
        rb.linearVelocity = Vector2.zero;
        isWalking = false;
    }
}

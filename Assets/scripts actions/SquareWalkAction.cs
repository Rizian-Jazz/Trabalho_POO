using UnityEngine;
using System.Collections;

public class SquareWalkAction : ActionModel
{ 
    public float walkSpeed = 10f, walkDuration = 2f;
    public Vector2[] walkDirections = new Vector2[2] { Vector2.right, Vector2.left };
    private int currentDirectionIndex = 0;

    public bool isWalking = false; 
    private Coroutine WalkInSquareCoroutine;
  


    public override void Use()
     {
        if (!CanUseAction()) return;
        if (isWalking)
        {
            StopWalking();
        }
        else WalkInSquareCoroutine = StartCoroutine(WalkInSquare());
     }

    private IEnumerator WalkInSquare()
    {
        isWalking = true;  
        float timer = 0f;
        
        while (isWalking)     
        {
            rb.linearVelocity = new Vector2(
                walkDirections[currentDirectionIndex].x * walkSpeed,
                rb.linearVelocity.y);
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
        if (WalkInSquareCoroutine != null )
        {
            StopCoroutine(WalkInSquareCoroutine);
            WalkInSquareCoroutine = null;
        }       
       
        rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y); // para X, mantém Y
        isWalking = false;

    }
        
}





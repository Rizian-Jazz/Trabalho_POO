using UnityEngine;
using System.Collections;

public class SquareWalkAction : ActionModel
{ 
    public float walkSpeed = 10f, walkDuration = 1f;
    public Vector3[] walkDirections = new Vector3[4] {Vector3.right, Vector3.up, Vector3.left, Vector3.down};
    private int currentDirectionIndex = 0;

    private bool isWalking = false; 
    private Coroutine WalkInSquareCoroutine;

    public override  void Use()
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
        rb.gravityScale = 0;
        isWalking = true;       
        Vector3 Direction = walkDirections[currentDirectionIndex];
        rb.linearVelocity = Direction * walkSpeed;              
        yield return new WaitForSeconds(walkDuration);
        currentDirectionIndex = (currentDirectionIndex + 1) % walkDirections.Length;
        StopWalking();
    }

    private void StopWalking()
    {
        if (WalkInSquareCoroutine != null)
        {
            StopCoroutine(WalkInSquareCoroutine);
            WalkInSquareCoroutine = null;
        }
        isWalking = false;
        }
        
}





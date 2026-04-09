using UnityEngine;
using System.Collections;
public class NonPlayerableController : BaseCharacterController
{
    public float intervalo = 6.7f;
    private bool Choraxx = false;//


    // sim
    void Start()
    {
        StartCoroutine(Buzanfa());
    }

    
    private IEnumerator Buzanfa()
    {
        while (true)
        {
            if (!Choraxx)
            {
              yield return StartCoroutine(Atumalaca());
            }
            
            yield return new WaitForSeconds(intervalo);
        }
    }

    private IEnumerator Atumalaca()
    {
        Choraxx = true; //como?
        int acoes = Random.Range(0, 4);
        switch(acoes)
        {
            case 0:
                Jump();
                yield return new WaitForSeconds(1f);
                break;
            case 1:
                DoubleJump();
                yield return new WaitForSeconds(1f);
                break;
            case 2:
                SquareWalk();
                yield return new WaitForSeconds(1f);
                break;
            case 3:
                Dash();
                yield return new WaitForSeconds(1f);
                break;
        }
        Choraxx = false;
    }
}

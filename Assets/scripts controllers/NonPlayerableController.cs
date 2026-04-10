using UnityEngine;
using System.Collections;

public class NonPlayerableController : BaseCharacterController
{
    public float intervalo = 3f;
    private bool isExecutingAction = false;

    void Start()
    {
        StartCoroutine(AILoop());
    }

    private IEnumerator AILoop()
    {
        while (true)
        {
            if (!isExecutingAction)
                yield return StartCoroutine(ExecuteRandomAction());

            yield return new WaitForSeconds(intervalo);
        }
    }

    private IEnumerator ExecuteRandomAction()
    {
        isExecutingAction = true;

        int acao = Random.Range(0, 5);
        switch (acao)
        {
            case 0: Jump(); break;
            case 1: DoubleJump(); break;
            case 2: SquareWalk(); break;
            case 3: SquareWalkV2(); break;
            case 4: Dash(); break;
        }

        yield return new WaitForSeconds(2f);
        isExecutingAction = false;
    }
}
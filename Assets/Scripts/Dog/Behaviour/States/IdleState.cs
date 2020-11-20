
using System.Collections;
using UnityEngine;

public class IdleState : State
{
    public override void Enter()
    {
        base.Enter();
    }

    public override void FixedUpdate()
    {
        
        base.FixedUpdate();
    }

    private IEnumerator StartMoving()
    {
        yield return new WaitForSeconds(3);

    }
}

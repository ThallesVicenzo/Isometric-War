using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadState : State
{
    public override void Enter()
    {
        
    }

    IEnumerator LoadSequence(){

        yield return StartCoroutine(Board.instance.InitSequence(this));
        //
        //
        //
        yield return null;

        StateMachineController.instance.ChangeTO<RoamState>();

    }
}

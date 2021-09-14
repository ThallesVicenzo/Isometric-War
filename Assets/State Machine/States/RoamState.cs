using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamState : State
{
    public override void Enter(){
        base.Enter();
        InputController.instance.OnMove += OnMove;
    }

    void OnMove(object sender, object args){

        Vector2Int input = (Vector2Int)args;

        Debug.Log("Moveu: " +input);
    }
}

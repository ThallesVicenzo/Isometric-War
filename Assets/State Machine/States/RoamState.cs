using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamState : State
{
    public override void Enter(){
        base.Enter();
        InputController.instance.OnMove += OnMove;
        CheckNullPosition();
    }

    public override void Exit(){
        base.Exit();
        InputController.instance.OnMove -= OnMove;
    }

    void OnMove(object sender, object args){

        Vector3Int input = (Vector3Int)args;

        TileLogic t = Board.GetTile(Selector.instance.position + input);

        if(t!=null){

            Selector.instance.tile = t;

            Selector.instance.spriteRenderer.sortingOrder = t.contentOrder;

            Selector.instance.transform.position = t.worldPos;
        }
    }

    void CheckNullPosition(){
        if(Selector.instance.position == null){

            TileLogic t = Board.GetTile(new Vector3Int(0,0,0));

            Selector.instance.tile = t;

            Selector.instance.spriteRenderer.sortingOrder = t.contentOrder;

            Selector.instance.transform.position = t.worldPos;
        }
    }
}

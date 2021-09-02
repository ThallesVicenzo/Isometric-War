using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    float hCoolDown = 0;
    float vCoolDown = 0;
    float cooldownTimer = 0.5f;

    // Update is called once per frame
    void Update()
    {
        int h = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
        int v = Mathf.RoundToInt(Input.GetAxisRaw("Vertical"));

        Vector2Int moved = new Vector2Int(0, 0);

        if(h != 0){
            moved.x = GetMoved(ref hCoolDown, h);
        }
        else
            hCoolDown = 0;
        if(v != 0){
            moved.y = GetMoved(ref vCoolDown, v);
        }
        else
            hCoolDown = 0;

        if(moved != Vector2Int.zero)
        Debug.Log(moved);
    }

    int GetMoved(ref float cooldownSum, int value){

        if(Time.time > cooldownSum){

            cooldownSum += Time.time + cooldownTimer;

            return value;
        }
        return 0;
    }
}

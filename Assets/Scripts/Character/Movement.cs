using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public bool teste;

    const float MoveSpeed = 0.5f;

    const float jumpHeight = 0.5f;

    public List<Vector3Int> path;

    SpriteRenderer SR;

    Transform jumper;

    TileLogic tileAtual;

    // Start is called before the first frame update
    void Awake()
    {
        jumper = transform.Find("Jumper");
        SR = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (teste)
        {
            teste = false;
            StopAllCoroutines();
            StartCoroutine(Move());
        }
    }

    IEnumerator Move()
    {
        tileAtual = Board.GetTile(path[0]);
        transform.position = tileAtual.worldPos;

        for(int i = 1; i<path.Count; i++){

            TileLogic to = Board.GetTile(path[i]);

            if(to == null)
                continue;

            tileAtual.content = null;
            
            if(tileAtual.floor != to.floor){
                yield return StartCoroutine(Jump(to));
            }
            else{
                yield return StartCoroutine(Walk(to));
            }
            
        }
    }

    IEnumerator Walk(TileLogic to){

        int id = LeanTween.move(transform.gameObject, to.worldPos, MoveSpeed).id;
        tileAtual = to;

        yield return new WaitForSeconds(MoveSpeed * 0.5f);
        SR.sortingOrder = to.contentOrder;

        while(LeanTween.descr(id) != null){
            yield return null;
        }

        to.content = this.gameObject;

    }

    IEnumerator Jump(TileLogic to)
    {

        int id1 = LeanTween.move(transform.gameObject, to.worldPos, MoveSpeed).id;
        
        LeanTween.moveLocalY(jumper.gameObject, jumpHeight, MoveSpeed * 0.5f).
        setLoopPingPong(1).setEase(LeanTweenType.easeInOutQuad);

        float timerOrderUpdate = MoveSpeed;

        if(tileAtual.floor.tilemap.tileAnchor.y > to.floor.tilemap.tileAnchor.y){
            timerOrderUpdate *= 0.85f;
        }
        else{
            timerOrderUpdate *= 0.2f;
        }
        yield return new WaitForSeconds(timerOrderUpdate);

        tileAtual = to;

        SR.sortingOrder = to.contentOrder;

        while(LeanTween.descr(id1) != null){
            yield return null;
        }

        to.content = this.gameObject;

    }

}

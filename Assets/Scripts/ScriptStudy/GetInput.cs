using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void Controle(object sender, ref Somatoria somatoria);
public class GetInput : MonoBehaviour
{

    Controle sum;
    Somatoria somatoria;
    float juros = 0.10f;
    // Start is called before the first frame update
    void Start()
    {
        somatoria = new Somatoria(100000.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C)){
            sum = (object sender, ref Somatoria somatoria) => new Somatoria(somatoria.soma *= juros);
        }

        if(Input.GetKeyDown(KeyCode.P)){

            if(sum != null){
                sum(null, ref somatoria);
                Debug.Log(string.Format("Resultado: {0}", somatoria.soma));
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StateMachineController : MonoBehaviour
{
    
    public static StateMachineController instance;
    State _current;
    public Transform selector;
    bool busy;
    
    [Header("ChooseActionState")]
    public List<Image> chooseActionButtons;
    public Image chooseActionSelection;

    public State current{get{return _current;}}
    void Awake(){
        instance = this;
    }

    void Start(){
        // ChangeTo<AudioDataLoadState>();
    }

    public void ChangeTO<T>() where T:State{

        State state = GetState<T>();

        if(_current != state)
            ChangeState(state);
    }

    public T GetState<T>() where T:State{

        T target = GetComponent<T>();

        if(target == null)
            target = gameObject.AddComponent<T>();

            return target;
    }

    protected void ChangeState(State value){

        if(busy)
            return;
        busy = true;

        if(_current != null){
            _current.Exit();
        }

        _current = value;

        if(_current != null)
            _current.Enter();

        busy = false;
    }
}

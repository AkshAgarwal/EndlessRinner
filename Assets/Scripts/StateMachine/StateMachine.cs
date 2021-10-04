using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class StateMachine : MonoBehaviour
{
    protected States State;
    [SerializeField] MenuManager menuManager;
    public void setState(States state)
    {
        State = state;
    }
   
}

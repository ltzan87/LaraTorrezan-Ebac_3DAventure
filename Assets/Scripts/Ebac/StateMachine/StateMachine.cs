using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class StateMachine : MonoBehaviour
{
  public enum States
    {
        NONE,
    }


    public Dictionary<States, StateBase> dictionaryState;

    private StateBase _currenteState;
    public float timeToStartGame = 1f;


    private void Awake()
    {
        dictionaryState = new Dictionary<States, StateBase>();
        dictionaryState.Add(States.NONE, new StateBase());

        SwitchState(States.NONE);

        Invoke(nameof(StartGame), timeToStartGame);
    }

    [Button]
    private void StartGame()
    {
        SwitchState(States.NONE);
    }

#if UNITY_EDITOR
    #region DEBUG
    [Button]
    private void ChangeStateToStateX()
    {
        SwitchState(States.NONE);
    }
    private void ChangeStateToStateY()
    {
        SwitchState(States.NONE);
    }

    #endregion
#endif
    public void SwitchState(States state)
    {
        if (_currenteState != null) _currenteState.OnStateExit();

        _currenteState = dictionaryState[state];

        _currenteState.OnStateEnter();
    }


    private void Update()
    {
        if (_currenteState != null) _currenteState.OnStateStay();

        if (Input.GetKeyDown(KeyCode.O))
        {
            //SwitchState(States.NONE);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System;

namespace Ebac.StateMachine
{
    public class StateMachine<T> where T : System.Enum
    {
        public Dictionary<T, StateBase> dictionaryState;

        private StateBase _currenteState;
        public float timeToStartGame = 1f;



        public StateBase CurrentState
        {
            get { return _currenteState; }
        }

        public void Init()
        {
            dictionaryState = new Dictionary<T, StateBase>();
        }

        public void RegisterStates(T typeEnum, StateBase state)
        {
            dictionaryState.Add(typeEnum, state);
        }

        public void SwitchState(T state)
        {
            if (_currenteState != null) _currenteState.OnStateExit();

            _currenteState = dictionaryState[state];

            _currenteState.OnStateEnter();
        }

        public void Update()
        {
            if (_currenteState != null) _currenteState.OnStateStay();
        }
    }
}
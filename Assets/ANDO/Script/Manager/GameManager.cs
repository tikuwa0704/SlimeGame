using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StateMachineAI;

public interface IGameService
{

}

public enum E_GAME_MANAGER_STATE
{
    BeginSTAGE1,
    ExeSTAGE1,
    FinSTAGE1,
}

public class GameManager : StatefulObjectBase<GameManager,E_GAME_MANAGER_STATE>,IGameService
{

    private void Awake()
    {
        //ステートを登録する
        stateList.Add(new BeginState1State(this));
        stateList.Add(new ExeState1State(this));
        stateList.Add(new FinState1State(this));
        
        stateMachine = new StateMachine<GameManager>();

        ChangeState(E_GAME_MANAGER_STATE.BeginSTAGE1);
    }

}


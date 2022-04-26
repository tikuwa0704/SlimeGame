using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using StateMachineAI;

public interface IGameService
{
    void TransState(E_GAME_MANAGER_STATE state);
}

public enum E_GAME_MANAGER_STATE
{
    BeginTITLE,
    ExeTITLE,
    FinTITLE,
    BeginSTAGE1,
    ExeSTAGE1,
    FinSTAGE1,
}

public class GameManager : StatefulObjectBase<GameManager, E_GAME_MANAGER_STATE>, IGameService
{

    private void Awake()
    {
        DontDestroyObjectManager.DontDestroyOnLoad(this.gameObject);

        //ÉXÉeÅ[ÉgÇìoò^Ç∑ÇÈ
        stateList.Add(new BeginTitleState(this));
        stateList.Add(new ExeTitleState(this));
        stateList.Add(new FinTitleState(this));
        stateList.Add(new BeginState1State(this));
        stateList.Add(new ExeState1State(this));
        stateList.Add(new FinState1State(this));

        stateMachine = new StateMachine<GameManager>();

        ChangeState(E_GAME_MANAGER_STATE.BeginTITLE);

        SceneManager.activeSceneChanged += OnActiveSceneChanged;
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    public void TransState(E_GAME_MANAGER_STATE state){
        ChangeState(state);
    }

    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        Debug.Log(prevScene.name + "->" + nextScene.name);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Debug.Log(scene.name + " scene loaded");
        if (scene.name=="GameScene")
        {

            ServiceLocator<IGameService>.Instance.TransState(E_GAME_MANAGER_STATE.BeginSTAGE1);
        }
    }

    void OnSceneUnloaded(Scene scene)
    {
        Debug.Log(scene.name + " scene unloaded");
    }
}


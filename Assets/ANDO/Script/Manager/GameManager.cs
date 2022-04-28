using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using StateMachineAI;

public interface IGameService
{
    void TransState(E_GAME_MANAGER_STATE state);

    bool IsState(E_GAME_MANAGER_STATE state);
}

public enum E_GAME_MANAGER_STATE
{
    READY_TITLE,//タイトルから他のマネージャーが登録されるまで
    EXE_TITLE,//音を鳴らす
    BEGIN_STAGE1,
    READY_STAGE1,
    EXE_STAGE1,
}

public class GameManager : StatefulObjectBase<GameManager, E_GAME_MANAGER_STATE>, IGameService
{
    [SerializeField] public GameObject canvas;


    private void Awake()
    {
        DontDestroyObjectManager.DontDestroyOnLoad(this.gameObject);

        canvas = GameObject.Find("Canvas");

        //ステートを登録する
        stateList.Add(new ReadyTitleState(this));
        stateList.Add(new ExeTitleState(this));
        stateList.Add(new BeginState1State(this));
        stateList.Add(new ReadyStage1State(this));
        stateList.Add(new ExeStage1State(this));

        stateMachine = new StateMachine<GameManager>();

        ChangeState(E_GAME_MANAGER_STATE.READY_TITLE);

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

            ServiceLocator<IGameService>.Instance.TransState(E_GAME_MANAGER_STATE.BEGIN_STAGE1);
        }
    }

    void OnSceneUnloaded(Scene scene)
    {
        Debug.Log(scene.name + " scene unloaded");
    }

    public bool IsState(E_GAME_MANAGER_STATE state)
    {
        return IsCurrentState(state);
    }

}


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
    NONE,//何もしない
    BEGIN_STAGE1,//ステージ1の開始
    READY_STAGE1,//ステージ1のファンファーレ
    EXE_STAGE1,//ステージ1挑戦中
    FIN_STAGE1,//ステージ1の終了
    BEGIN_STAGE2,
    READY_STAGE2,//ステージ2のファンファーレ
    EXE_STAGE2,//ステージ2挑戦中
    FIN_STAGE2,//ステージ2の終了
}

public class GameManager : StatefulObjectBase<GameManager, E_GAME_MANAGER_STATE>, IGameService
{
  
    [SerializeField] public E_GAME_MANAGER_STATE dispaly_state;

    [SerializeField] public GameObject m_mainCamera;
    [SerializeField] public GameObject m_subCamera;



    private void Awake()
    {
        //DontDestroyObjectManager.DontDestroyOnLoad(this.gameObject);

        //ステートを登録する
        stateList.Add(new NoneState(this));
        stateList.Add(new BeginState1State(this));
        stateList.Add(new ReadyStage1State(this));
        stateList.Add(new ExeStage1State(this));
        stateList.Add(new FinStage1State(this));
        stateList.Add(new BeginStage2State(this));

        stateMachine = new StateMachine<GameManager>();

        ChangeState(E_GAME_MANAGER_STATE.BEGIN_STAGE1);

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
        Debug.Log(scene.name + " scene loaded");       
    }

    void OnSceneUnloaded(Scene scene)
    {
        Debug.Log(scene.name + " scene unloaded");
    }

    public bool IsState(E_GAME_MANAGER_STATE state)
    {
        Debug.Log("ここまで");
        return IsCurrentState(state);
    }

}


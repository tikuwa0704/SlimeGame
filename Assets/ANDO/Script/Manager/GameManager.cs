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
    NONE,//�������Ȃ�
    BEGIN_STAGE1,//�X�e�[�W1�̊J�n
    READY_STAGE1,//�X�e�[�W1�̃t�@���t�@�[��
    EXE_STAGE1,//�X�e�[�W1���풆
    FIN_STAGE1,//�X�e�[�W1�̏I��
    BEGIN_STAGE2,
    READY_STAGE2,//�X�e�[�W2�̃t�@���t�@�[��
    EXE_STAGE2,//�X�e�[�W2���풆
    FIN_STAGE2,//�X�e�[�W2�̏I��
}

public class GameManager : StatefulObjectBase<GameManager, E_GAME_MANAGER_STATE>, IGameService
{
  
    [SerializeField] public E_GAME_MANAGER_STATE dispaly_state;

    [SerializeField] public GameObject m_mainCamera;
    [SerializeField] public GameObject m_subCamera;



    private void Awake()
    {
        //DontDestroyObjectManager.DontDestroyOnLoad(this.gameObject);

        //�X�e�[�g��o�^����
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
        Debug.Log("�����܂�");
        return IsCurrentState(state);
    }

}


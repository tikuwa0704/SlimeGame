using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using StateMachineAI;


public interface IGameService
{
    void SetCrrentCheckPoint(int stageNum);

    Vector3 GetCrrentCheckPoint();

    void CheckPoint();

    float GetLimitTime();

    int GetCurrentScore();

    int GetTotalScore();
}


public enum E_GAME_MANAGER_STATE
{
    NONE,//�������Ȃ�
    BEGIN_STAGE1,//�X�e�[�W1�̊J�n
    READY_STAGE1,//�X�e�[�W1�̃t�@���t�@�[��
    EXE_STAGE1,//�X�e�[�W1���풆
    FIN_STAGE1,//�X�e�[�W1�̏I��
    CONECT_1TO2,//�X�e�[�W1��2�̓r��
    BEGIN_STAGE2,//�X�e�[�W2�J�n���[�r�[
    EXE_STAGE2,//�X�e�[�W2���풆
    FIN_STAGE2,//�X�e�[�W2�̏I��
    CONECT_2TO3,//�X�e�[�W2��3�̓r��
    BEGIN_STAGE3,//�X�e�[�W3�J�n���[�r�[
    EXE_STAGE3,//�X�e�[�W3���풆
    FIN_STAGE3,//�X�e�[�W3�̏I��
    GameOver,//�Q�[���̏I��
}

public class GameManager : StatefulObjectBase<GameManager, E_GAME_MANAGER_STATE> , IGameService
{
  
    [SerializeField]
    [Tooltip("���݂̃X�e�[�W�ԍ�")]
    public int stageNum;

    [SerializeField]
    [Tooltip("���C���J����")]
    public GameObject m_mainCamera;
    [SerializeField]
    [Tooltip("�T�u�J����")]
    public GameObject m_subCamera;

    [SerializeField]
    [Tooltip("�`�F�b�N�|�C���g�̔z��")]
    List<Transform> m_checkPointArray;

    [SerializeField]
    [Tooltip("���X�^�[�g���ɊJ�n���錻�݂̒n�_")]
    private Transform m_crrentCheckPoint;

    [SerializeField]
    [Tooltip("�X���C���R�A")]
    private GameObject m_slime;

    [SerializeField]
    [Tooltip("��{�X�R�A�_")]
    public int basicLimitTimeScore = 10;

    [SerializeField]
    [Tooltip("��{�X�R�A�_")]
    public int basicSlimeNumScore = 50;

    [SerializeField]
    [Tooltip("�S�X�e�[�W���v�̃X�R�A")]
    public int totalScore;

    [SerializeField]
    [Tooltip("���݂̃X�e�[�W�̃X�R�A")]
    public int currentScore;

    [SerializeField]
    [Tooltip("�e�X�e�[�W�̃X�R�A(3�X�e�[�W��)")]
    public int[] gameScore = new int[3];

    [SerializeField]
    [Tooltip("�e�X�e�[�W�̐�������")]
    public float[] gameLimitTimes = new float[3];

    [SerializeField]
    [Tooltip("���݂̐�������")]
    public float currentGameLimitTime;


    private void Awake()
    {
        
        //�X�e�[�g��o�^����
        stateList.Add(new NoneState(this));
        stateList.Add(new BeginState1State(this));
        stateList.Add(new ReadyStage1State(this));
        stateList.Add(new ExeStage1State(this));
        stateList.Add(new FinStage1State(this));
        stateList.Add(new Conect1to2State(this));
        stateList.Add(new BeginStage2State(this));
        stateList.Add(new ExeStage2State(this));
        stateList.Add(new FinStage2State(this));
        stateList.Add(new Conect2to3State(this));
        stateList.Add(new BeginState3State(this));
        stateList.Add(new ExeStage3State(this));
        stateList.Add(new FinStage3State(this));
        stateList.Add(new GameOverState(this));

        stateMachine = new StateMachine<GameManager>();

        ChangeState(E_GAME_MANAGER_STATE.BEGIN_STAGE1);

       
    }

    public void SetCrrentCheckPoint(int stageNum)
    {
        int idx = stageNum - 1;
        m_crrentCheckPoint = m_checkPointArray[idx];
    }


    public Vector3 GetCrrentCheckPoint()
    {
        return m_crrentCheckPoint.position;
    }
    
    //�X���C�����`�F�b�N�|�C���g�ɖ߂�����
    public void CheckPoint() {

        SlimeManager slimeManager = SlimeManager.Instance;
        GameObject slime = slimeManager.gameObject;
        
        //�X���C��������
        slimeManager.DestorySlime();
        //�v���C���[���ʒu�`�F�b�N�|�C���g�̈ʒu�Ɏ����Ă���
        //�`�F�b�N�|�C���g�ɖ߂�
        Vector3 point = GetCrrentCheckPoint();
        m_slime.transform.position = point;
        m_slime.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //�q�X���C���𐶐�����X��Ԃł͐������Ȃ�

        slimeManager.ChangeState(E_SLIMES_STATE.E_NORMAL);
        int num = slimeManager.GetSlimeNum();
        slimeManager.GenerateSlime(num);
    }

    public float GetLimitTime()
    {
        return currentGameLimitTime;
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public int GetTotalScore()
    {
        return totalScore;
    }

    public void SetScore()
    {
        //�X�R�A���i�[
        //�c�莞�Ԃ��擾
        var limit = currentGameLimitTime;
        var num = SlimeManager.Instance.GetSlimeNum();
        //int basicScore = 100;
        int score = (int)(limit * basicLimitTimeScore + num * basicSlimeNumScore);
        gameScore[stageNum - 1] = score;
        currentScore = score;
        int s = 0;
        foreach (int i in gameScore)
        {
            s += i;
        }
        totalScore = s;
    }

}


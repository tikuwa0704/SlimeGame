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
    NONE,//何もしない
    BEGIN_STAGE1,//ステージ1の開始
    READY_STAGE1,//ステージ1のファンファーレ
    EXE_STAGE1,//ステージ1挑戦中
    FIN_STAGE1,//ステージ1の終了
    CONECT_1TO2,//ステージ1と2の途中
    BEGIN_STAGE2,//ステージ2開始ムービー
    EXE_STAGE2,//ステージ2挑戦中
    FIN_STAGE2,//ステージ2の終了
    CONECT_2TO3,//ステージ2と3の途中
    BEGIN_STAGE3,//ステージ3開始ムービー
    EXE_STAGE3,//ステージ3挑戦中
    FIN_STAGE3,//ステージ3の終了
    GameOver,//ゲームの終了
}

public class GameManager : StatefulObjectBase<GameManager, E_GAME_MANAGER_STATE> , IGameService
{
  
    [SerializeField]
    [Tooltip("現在のステージ番号")]
    public int stageNum;

    [SerializeField]
    [Tooltip("メインカメラ")]
    public GameObject m_mainCamera;
    [SerializeField]
    [Tooltip("サブカメラ")]
    public GameObject m_subCamera;

    [SerializeField]
    [Tooltip("チェックポイントの配列")]
    List<Transform> m_checkPointArray;

    [SerializeField]
    [Tooltip("リスタート時に開始する現在の地点")]
    private Transform m_crrentCheckPoint;

    [SerializeField]
    [Tooltip("スライムコア")]
    private GameObject m_slime;

    [SerializeField]
    [Tooltip("基本スコア点")]
    public int basicLimitTimeScore = 10;

    [SerializeField]
    [Tooltip("基本スコア点")]
    public int basicSlimeNumScore = 50;

    [SerializeField]
    [Tooltip("全ステージ合計のスコア")]
    public int totalScore;

    [SerializeField]
    [Tooltip("現在のステージのスコア")]
    public int currentScore;

    [SerializeField]
    [Tooltip("各ステージのスコア(3ステージ分)")]
    public int[] gameScore = new int[3];

    [SerializeField]
    [Tooltip("各ステージの制限時間")]
    public float[] gameLimitTimes = new float[3];

    [SerializeField]
    [Tooltip("現在の制限時間")]
    public float currentGameLimitTime;


    private void Awake()
    {
        
        //ステートを登録する
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
    
    //スライムをチェックポイントに戻す処理
    public void CheckPoint() {

        SlimeManager slimeManager = SlimeManager.Instance;
        GameObject slime = slimeManager.gameObject;
        
        //スライムを消す
        slimeManager.DestorySlime();
        //プレイヤーを位置チェックポイントの位置に持ってくる
        //チェックポイントに戻る
        Vector3 point = GetCrrentCheckPoint();
        m_slime.transform.position = point;
        m_slime.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //子スライムを生成する氷状態では生成しない

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
        //スコアを格納
        //残り時間を取得
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


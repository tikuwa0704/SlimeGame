using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class GameInfoRender : MonoBehaviour
{
    [SerializeField]
    [Tooltip("現在合計のスコアText")]
    Text crrentTotalScoreText;

    [SerializeField]
    [Tooltip("ターゲットスコア")]
    float targetTotalScore;

    [SerializeField]
    [Tooltip("現在合計のスコアの数値")]
    float currentTotalScore;

    [SerializeField]
    [Tooltip("制限時間Text")]
    Text limitTime;

    [SerializeField]
    [Tooltip("結果発表用現在の時間の数値Text")]
    Text announceCurrentLimitText;

    [SerializeField]
    [Tooltip("結果発表用現在のスコアの数値Text")]
    Text announceCurrentScoreText;

    // Start is called before the first frame update
    void Start()
    {
        targetTotalScore = 0;
        currentTotalScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //現在の全てのステージの合計のスコア表示
        crrentTotalScoreText.text = currentTotalScore.ToString("F0");
        if (currentTotalScore <= targetTotalScore) currentTotalScore =Mathf.Min(currentTotalScore + Time.deltaTime * 1000,targetTotalScore);

        //現在のステージの残り時間表示
        float time = ServiceLocator<IGameService>.Instance.GetLimitTime();

        int minutes = (int)time / 60;
        int second = (int)time % 60;

        limitTime.text = minutes + ":" + second.ToString("D2");


        //結果発表用
        //現在のステージの残り時間
        int t = (int)time;
        announceCurrentLimitText.text = t.ToString();

        //現在のステージの最終スコア
        announceCurrentScoreText.text = ServiceLocator<IGameService>.Instance.GetCurrentScore().ToString();
    }

    public void SetTargetScore()
    {
        targetTotalScore = ServiceLocator<IGameService>.Instance.GetTotalScore();
    }
}

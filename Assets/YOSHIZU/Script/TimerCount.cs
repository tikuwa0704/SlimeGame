using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerCount : MonoBehaviour
{
    //トータルの制限時間
    private float TotalTime;
    //制限時間(分)
    private int Minutes = 1;
    //制限時間(秒)
    private float Seconds;
    //前のアップデート時の秒数
    private float OldSeconds;
    //タイマー表示用テキスト(実験用)
    private Text TimerText;

    void Start()
    {
        TotalTime = Minutes * 60 + Seconds;
        OldSeconds = 0f;
        TimerText = GetComponentInChildren<Text>();
    }

    private void Update()
    {
        //制限時間が0以下なら変化なし
        if (TotalTime <= 0f)
        {
            return;
        }
        //現在の制限時間を計測
        TotalTime = Minutes * 60 + Seconds;
        TotalTime -= Time.deltaTime;
        //再設定
        Minutes = (int)TotalTime / 60;
        Seconds = TotalTime - Minutes * 60;
        //タイマー表示用のUIテキストに現在の制限時間を表示する
        if ((int)Seconds != (int)OldSeconds)
        {
            TimerText.text = Minutes.ToString("00") + ":" + ((int)Seconds).ToString("00");
        }
        OldSeconds = Seconds;
        //制限時間が0以下になったらコンソールに「制限時間終了」という文字を表示
        if (TotalTime <= 0f)
        {
            Debug.Log("制限時間終了");
        }
    }
}

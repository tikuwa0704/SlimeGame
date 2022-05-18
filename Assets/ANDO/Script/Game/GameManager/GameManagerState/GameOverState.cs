using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StateMachineAI;

public class GameOverState : State<GameManager>
{
    public GameOverState(GameManager owner) : base(owner) { }

    public override void Enter()
    {
        //音楽を止める
        ServiceLocator<ISoundService>.Instance.Stop();
        //音楽を止める
        ServiceLocator<ISoundService>.Instance.Play("BGM_運命2");
        

        //プレイヤーを動けなくする
        SlimeManager.Instance.StartPause();
        //GAMEOVERUIをだす
        ServiceLocator<IUIService>.Instance.SetUIActive("GAMEOVERテキストエリア",true);
        
    }

    public override void Execute()
    {
       

    }

    public override void Exit()
    {
       
    }

}

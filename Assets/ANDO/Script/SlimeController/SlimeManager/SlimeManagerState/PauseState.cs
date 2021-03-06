using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StateMachineAI;
public class PauseState : State<SlimeManager>
{

    public PauseState(SlimeManager owner): base(owner) { }

    public override void Enter()
    {
        //プレイヤーを動けなくする
        owner.rigidBody.velocity = Vector3.zero;
        owner.rigidBody.isKinematic = true;
    }

    public override void Execute()
    {
        
    }

    public override void Exit()
    {

        owner.rigidBody.isKinematic = false;
        
    }
}

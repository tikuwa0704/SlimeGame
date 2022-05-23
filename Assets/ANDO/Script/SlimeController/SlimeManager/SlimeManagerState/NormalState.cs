using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StateMachineAI;

public class NormalState : State<SlimeManager>
{

    public NormalState(SlimeManager owner) : base(owner) { }

    Vector3 moveVector;

    float moveMagnitude; 

    public override void Enter()
    {

        owner.GetComponent<MeshRenderer>().material = owner._material[(int)E_SLIMES_STATE.E_NORMAL];

        owner.GetComponent<SphereCollider>().material = owner._physicMaterial[(int)E_SLIMES_STATE.E_NORMAL];

        owner.rigidBody.constraints = RigidbodyConstraints.FreezeRotation;

        owner.target_scale = Vector3.one;

        owner.t = 0.0f;

        moveVector = new Vector3(0, 0, 0);

        moveMagnitude = 0;

    }

    public override void Execute()
    {
        Debug.Log(Time.deltaTime);
        Move();
        Jump();
        ThrowSlime();
        ChageScale();
    }

    public override void Exit()
    {
        
    }

    void Move()
    {
        if (!owner.isActive) return;

        var inputHorizontal = Input.GetAxisRaw("Horizontal");
        var inputVertical = Input.GetAxisRaw("Vertical");
        var Horizontalrotation = Quaternion.AngleAxis(owner.mainCamera.transform.eulerAngles.y, Vector3.up);
        var velocity = Horizontalrotation * new Vector3(inputHorizontal, 0, inputVertical).normalized;
        var speed = owner.m_moveSpeedIdle;
        

        moveVector += velocity * speed * Time.deltaTime;
        owner.rigidBody.MovePosition(owner.rigidBody.position + moveVector * Time.deltaTime);
        moveVector *= 0.85f;

        // 移動音を鳴らす
        if (velocity != Vector3.zero)
        {
            moveMagnitude += velocity.magnitude * Time.deltaTime;
            if (moveMagnitude >= 2.0f)
            {
                owner.GetComponent<SlimeAudio>().PlayFootstepSE();
                moveMagnitude = 0;
            }
        }
    }

    void Jump()
    {
        if (!owner.isActive) return;

        ////もしY軸の移動速度が0以上なら落下している
        //var y_power = owner.rigidBody.velocity.y;
        //owner.m_is_falling = (y_power < 0) ? true : false;

        ////落下中ではない状態で地面に接すると再びジャンプフラグがONになる
        //if (!owner.m_is_falling && owner.m_is_ground) owner.m_is_jump = false;

        //if (owner.m_is_jump) return;//ジャンプしているなら帰る

        if (owner.jumpCount >= owner.jumpCountMax) return;

        if (Input.GetButton("Fire1"))
        {
            Debug.Log("ジャンプしています");
            owner.m_is_jump = true;
            owner.m_is_ground = false;//isGroundをfalseにする
            owner.rigidBody.AddForce(new Vector3(0, owner.upForce, 0),ForceMode.Impulse); //上に向かって力を加える
            owner.jumpCount++;
        }

    }

    void ChageScale()
    {
        if (owner.t <= 1)
        {
            owner.transform.localScale = owner.transform.localScale * (1 - owner.t) + owner.target_scale * owner.t;
            owner.t += Time.deltaTime / 5.0f;
        }
    }

    void ThrowSlime()
    {
        if (!owner.isActive) return;
        

        if (Input.GetButton("Fire3"))
        {
            owner.ThrowSlimeNear(300);


        }
        
    }
}

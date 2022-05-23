using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StateMachineAI;

public class IceState : State<SlimeManager>
{
    public IceState(SlimeManager owner): base(owner) { }

    

    public override void Enter()
    {
        InitIce(owner.childrenSlimeParent);
    }

    public override void Execute()
    {
        Move();
        ChageScale();
    }

    public override void Exit()
    {
        
    }

    void InitIce(GameObject obj)
    {

        {
            owner.rigidBody.constraints = RigidbodyConstraints.None;

            owner.GetComponent<MeshRenderer>().enabled = false;

            GameObject ice = GameObject.Instantiate(owner.icePrefab, owner.transform);
                
            foreach(Transform dummy in ice.transform)
            {
                dummy.SetParent(owner.transform);
                dummy.GetComponent<MeshCollider>().enabled = false;
            }
            owner.gameObject.AddComponent<Hakai>();
            //GameObject.Instantiate(owner.icePrefab, owner.transform);

            //�}�e���A����X��
            owner.GetComponent<MeshRenderer>().material = owner._material[(int)E_SLIMES_STATE.E_ICE];

            owner.GetComponent<SphereCollider>().material = owner._physicMaterial[(int)E_SLIMES_STATE.E_ICE];

            //�q�X���C���̐��̊����ŕX�ɂȂ������̑傫�����ς��
            int slime_num = Mathf.Max(1, owner.GetComponent<SlimeConcentration>().m_stick_num);

            //�ő�l
            float scale_max = 3.0f;
            float per = slime_num / 100f;

            owner.target_scale = new Vector3(per, per, per) * scale_max;

            owner.t = 0.0f;

            GameObject effect = GameObject.Instantiate(owner.cold_effect, owner.transform);
            GameObject.Destroy(effect, 3.0f);
        }


        Transform children = obj.GetComponentInChildren<Transform>();
        //�q�v�f�����Ȃ���ΏI��
        if (children.childCount == 0)
        {
            return;
        }
        //�����
        foreach (Transform ob in children)
        {

            SlimeContoroller slime_con = ob.gameObject.GetComponent<SlimeContoroller>();

            if (slime_con.m_is_sticking)
            {
                GameObject.Destroy(ob.gameObject);
            }

        }

    }

    void Move()
    {
        if (!owner.isActive) return;

        var inputHorizontal = Input.GetAxisRaw("Horizontal");
        var inputVertical = Input.GetAxisRaw("Vertical");
        var Horizontalrotation = Quaternion.AngleAxis(owner.mainCamera.transform.eulerAngles.y, Vector3.up);
        var velocity = Horizontalrotation * new Vector3(inputHorizontal, 0, inputVertical).normalized;
        var speed = owner.m_moveSpeedCold;

        owner.rigidBody.AddForce(velocity * speed * Time.deltaTime, ForceMode.Force);

    }

    void ChageScale()
    {
        if (owner.t <= 1)
        {
            owner.transform.localScale = owner.transform.localScale * (1 - owner.t) + owner.target_scale * owner.t;
            owner.t += Time.deltaTime / 5.0f;
        }
    }
}

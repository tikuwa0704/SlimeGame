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
        {
            
            owner.GetComponent<MeshRenderer>().enabled = true;

            owner.gameObject.GetComponent<Hakai>().enabled = false;

            //マテリアルを氷に
            owner.GetComponent<MeshRenderer>().material = owner._material[(int)E_SLIMES_STATE.E_NORMAL];

            owner.GetComponent<SphereCollider>().material = owner._physicMaterial[(int)E_SLIMES_STATE.E_NORMAL];

         

            owner.target_scale = new Vector3(1, 1, 1);

      

            owner.GetComponent<SphereCollider>().radius = 0.5f;

            int i = 0;
            foreach (Transform k in owner.transform)
            {
                if (k.CompareTag("Effect")) continue;
                k.gameObject.AddComponent<Rigidbody>();
                k.transform.parent = null;
                k.gameObject.AddComponent<HakaiTime>();
                k.gameObject.GetComponent<MeshCollider>().enabled = true;
                /*
                float Dtime = Random.Range(1.0f, 3.0f);
                Destroy(k.gameObject, Dtime);
                */
                i++;
            }

            Debug.Log(i);
        }
    }

    void InitIce(GameObject obj)
    {

        {
            owner.rigidBody.constraints = RigidbodyConstraints.None;

            owner.GetComponent<MeshRenderer>().enabled = false;

            GameObject ice = GameObject.Instantiate(owner.icePrefab, owner.transform);
                
            foreach(Transform dummy in ice.transform)
            {
                if (dummy.CompareTag("Effect")) continue;
                dummy.SetParent(owner.transform);
                dummy.GetComponent<MeshCollider>().enabled = false;
            }
            owner.gameObject.GetComponent<Hakai>().enabled =true;

            GameObject.Destroy(ice);
            

            //マテリアルを氷に
            owner.GetComponent<MeshRenderer>().material = owner._material[(int)E_SLIMES_STATE.E_ICE];

            owner.GetComponent<SphereCollider>().material = owner._physicMaterial[(int)E_SLIMES_STATE.E_ICE];

            //子スライムの数の割合で氷になった時の大きさが変わる
            int slime_num = Mathf.Max(1, owner.GetComponent<SlimeConcentration>().m_stick_num);

            //最大値
            float scale_max = 2.0f;
            float scale_min = 1.0f;
            float per = slime_num / 100f;

            float scale = Mathf.Max(scale_min,per * scale_max);

            owner.target_scale = new Vector3(scale, scale, scale);

            owner.t = 0.0f;

            float radius_max = 1.0f;
            float radius_min = 0.5f;
            float radius = Mathf.Max(radius_min, per * radius_max);

            owner.GetComponent<SphereCollider>().radius = radius;

            GameObject effect = GameObject.Instantiate(owner.cold_effect, owner.transform);
            GameObject.Destroy(effect, 3.0f);
        }


        Transform children = obj.GetComponentInChildren<Transform>();
        //子要素がいなければ終了
        if (children.childCount == 0)
        {
            return;
        }
        //いれば
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

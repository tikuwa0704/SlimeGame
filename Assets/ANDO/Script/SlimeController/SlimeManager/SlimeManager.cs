using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StateMachineAI;

public enum E_SLIMES_STATE
{
    E_NORMAL,//通常状態
    E_ICE,//氷状態
    E_PAUSE,//停止状態
}

public class SlimeManager : StatefulObjectBase<SlimeManager,E_SLIMES_STATE>
{
    public static SlimeManager Instance { get; private set; }

    [SerializeField]
    [Tooltip("アイススライムプレハブ")]
    public GameObject icePrefab;
    [SerializeField]
    [Tooltip("子スライムのプレハブ")]
    GameObject childSlimePrefab;
    [Tooltip("リジッドボディ")]
    public Rigidbody rigidBody;
    [SerializeField]
    [Tooltip("子スライム群の親オブジェクト")]
    public GameObject childrenSlimeParent;
    [SerializeField]
    [Tooltip("メインカメラ")]
    public Camera mainCamera;
    [SerializeField]
    [Tooltip("最高速度")]
    float m_max_magnitude;
    [Tooltip("スライムが動くかどうか")]
    public bool isActive = true;

    private void Awake()
    {
        Instance = this;

        TryGetComponent(out rigidBody);

        target_scale = this.transform.localScale;
        t = 1.0f;  

        stateList.Add(new NormalState(this));
        stateList.Add(new IceState(this));
        stateList.Add(new PauseState(this));

        stateMachine = new StateMachine<SlimeManager>();

        ChangeState(E_SLIMES_STATE.E_NORMAL);

    }

    private void OnDestroy()
    {
        Instance = null;
    }

    [SerializeField]
    [Tooltip("移動方向")]
    public Vector3 velocity;         // 移動方向
    [SerializeField]
    [Tooltip("通常状態の移動速度")]
    public float m_moveSpeedIdle = 5.0f;   // 移動速度
    [SerializeField]
    [Tooltip("氷状態の移動速度")]
    public float m_moveSpeedCold = 5.0f;   // 移動速度
    [SerializeField]
    [Tooltip("移動ベクトル")]
    public Vector3 m_moveVector = new Vector3(0, 0, 0);   // 移動速度
    [Tooltip("ジャンプパワー")]
    public float upForce = 200f; //上方向にかける力 
    [SerializeField]
    [Tooltip("着地しているかどうか")]
    public bool m_is_ground; //着地しているかどうかの判定
    [SerializeField]
    [Tooltip("ジャンプしているかどうか")]
    public bool m_is_jump = false; //着地しているかどうかの判定
    [SerializeField]
    [Tooltip("ジャンプの可能回数")]
    public int jumpCountMax; 
    [SerializeField]
    [Tooltip("ジャンプの回数")]
    public int jumpCount=0;
    [SerializeField]
    [Tooltip("落下しているかどうか")]
    public bool m_is_falling;
    [SerializeField]
    public GameObject cold_effect;


    [SerializeField]
    [Header("マテリアルの配列")]
    public Material[] _material;
    [SerializeField]
    public Vector3 target_scale;

    [SerializeField]
    public PhysicMaterial[] _physicMaterial;

    [SerializeField]
    [Header("遷移の時間")]
    public float t;


    private void OnCollisionEnter(Collision collision)
    {
        if (IsCurrentState(E_SLIMES_STATE.E_NORMAL))
        {
            for (int i = 0; i < collision.contacts.Length; i++)
            {

                // 衝突位置を取得する
                Vector3 hitPos = collision.contacts[i].point;

                Vector3 dir = hitPos - this.transform.position;

                if (dir.y <= -0.25)
                {
                    jumpCount = 0;
                    //jumpCount = 0;
                    //m_is_ground = true; //isGroundをtrueにする
                    GetComponent<SlimeAudio>().PlayFootstepSE();
                }

            }
            
        }
        if (IsCurrentState(E_SLIMES_STATE.E_ICE))
        {
           GetComponent<IceAudio>().PlayFootstepSE();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        // 衝突位置を取得する
        Vector3 hitPos = collision.contacts[0].point;

        Vector3 dir = hitPos - this.transform.position;
        //Debug.Log(dir.y);
        if (dir.y <= -0.25)
        {
            //jumpCount = 0;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //氷
        if (other.gameObject.CompareTag("ColdWind"))
        {
            if (IsCurrentState(E_SLIMES_STATE.E_NORMAL)) ChangeState(E_SLIMES_STATE.E_ICE);
        }
        //Fireタグのオブジェクトに触れている
        if (other.gameObject.CompareTag("Fire"))
        {
            //氷状態なら解ける
            if (IsCurrentState(E_SLIMES_STATE.E_ICE))
            {
                int num = GetComponent<SlimeConcentration>().m_stick_num;
                GenerateSlime(num);
                ChangeState(E_SLIMES_STATE.E_NORMAL);
            }
        }
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    //Groundタグのオブジェクトに触れている
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        m_is_ground = true; //isGroundをtrueにする
    //        //GetComponent<SlimeAudio>().PlayFootstepSE();
    //    }
    //}

    //自分の周りに子スライムを生成
    public void GenerateSlime(int spawnNum)
    {

        spawnNum = Mathf.Max(0, spawnNum);

        for (int i = 0; i < spawnNum; i++)
        {
            //親スライムの地点
            Vector3 parentPosition = transform.position;
            float rangeX = 3.0f;
            float rangeY = 3.0f;
            float rangeZ = 3.0f;

            // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
            float x = Random.Range(parentPosition.x - rangeX, parentPosition.x + rangeX);
            // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
            float y = Random.Range(parentPosition.y, parentPosition.y + rangeY);
            // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
            float z = Random.Range(parentPosition.z - rangeZ, parentPosition.z + rangeZ);

            GameObject obj = Instantiate(childSlimePrefab, new Vector3(x, y, z), childSlimePrefab.transform.rotation);

            obj.transform.parent = childrenSlimeParent.transform;

        }
    }

    public void GenerateSlime(Vector3 point)
    {
        //100体以上は作らない
        if (GetSlimeNum() >= 100) return;
        //親スライムの地点
        Vector3 parentPosition = transform.position;

        GameObject obj = Instantiate(childSlimePrefab, point, childSlimePrefab.transform.rotation);

        obj.transform.parent = childrenSlimeParent.transform;
    }


    //子スライムたちを消去
    public void DestorySlime()
    {
        var children = childrenSlimeParent.GetComponentInChildren<Transform>();

        foreach (Transform obj in children)
        {
            Destroy(obj.gameObject);
        }
    }


    public void StartPause()
    {
        //プレイヤーを動けなくする
        isActive = false;
        rigidBody.velocity = Vector3.zero;
        //rigidBody.isKinematic = true;
        
    }

    public void StopPause()
    {
        //プレイヤーを動けるようにする
        isActive = true;
        //rigidBody.isKinematic = false;

    }

    //くっついているスライムの中で一番遠いスライムを前方に飛ばす通常状態だけ
    public void ThrowSlimeFar(float power)
    {

        Transform slime;
        if(slime= GetFarStickSlime(mainCamera.transform.position))
        {
            //とれたなら投げる
            Rigidbody rb = slime.GetComponent<Rigidbody>();
            
            rb.AddForce(mainCamera.transform.forward * power);
            SlimeContoroller slime1 =  slime.GetComponent<SlimeContoroller>();
            slime1.m_state = SlimeContoroller.E_SLIME_STATE.eThrow;
            slime1.m_is_sticking = false;
        }

    }
        
    //くっついている中で地点から一番遠いスライムを取得
    public Transform GetFarStickSlime(Vector3 pos)
    {
        var children = childrenSlimeParent.GetComponentInChildren<Transform>();

        float currentLength = 0;
        Transform o = null;

        foreach (Transform obj in children)
        {
            SlimeContoroller slime = obj.gameObject.GetComponent<SlimeContoroller>();
            //くっついてないなら判定しない
            if (!slime.m_is_sticking) continue;

            float length = (pos - obj.position).magnitude;

            if (length > currentLength)
            {
                currentLength = length;
                o = obj;
            }

        }

        return o;

    }

    public void ThrowSlimeNear(float power)
    {

        Transform slime;
        if (slime = GetNearStickSlime(mainCamera.transform.position))
        {
            //とれたなら投げる
            Rigidbody rb = slime.GetComponent<Rigidbody>();

            rb.AddForce(-mainCamera.transform.forward * power);
            SlimeContoroller slime1 = slime.GetComponent<SlimeContoroller>();
            slime1.m_state = SlimeContoroller.E_SLIME_STATE.eThrow;
            slime1.m_is_sticking = false;
        }

    }

    //くっついている中で地点から一番近いスライムを取得
    public Transform GetNearStickSlime(Vector3 pos)
    {
        var children = childrenSlimeParent.GetComponentInChildren<Transform>();

        float currentLength = float.MaxValue;
        Transform o = null;

        foreach (Transform obj in children)
        {
            SlimeContoroller slime = obj.gameObject.GetComponent<SlimeContoroller>();
            //くっついてないなら判定しない
            if (!slime.m_is_sticking) continue;

            float length = (pos - obj.position).magnitude;

            if (length < currentLength)
            {
                currentLength = length;
                o = obj;
            }

        }

        return o;

    }

    public int GetSlimeNum()
    {
        return GetComponent<SlimeConcentration>().m_stick_num;
    }

}

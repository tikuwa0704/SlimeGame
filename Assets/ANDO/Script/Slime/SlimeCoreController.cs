using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCoreController : MonoBehaviour
{
    [Header("スライムが動くかどうか")]
    public static bool isActive = true;

    [Header("子スライム群")]
    [SerializeField] public GameObject m_slime;

    [SerializeField]
    [Header("メインカメラ")]
    Camera m_mainCamera;

    float inputHorizontal;
    float inputVertical;
    Quaternion Horizontalrotation;
    Rigidbody rb;

    public enum SLIME_CORE_STATE
    {
        IDLE,
        COLD,
    }

    [Header("スライムの状態")]
    [SerializeField] public SLIME_CORE_STATE m_state;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target_scale = this.transform.localScale;
        t = 1.0f;
        total_vel = 0;
        m_state = SLIME_CORE_STATE.IDLE;
    }


    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
        Horizontalrotation = Quaternion.AngleAxis(m_mainCamera.transform.eulerAngles.y, Vector3.up);
        if (isActive)
        {
            Jump();
            SlimeMove();
            ChageScale();
        }
    }

    [Header("移動方向")]
    [SerializeField] private Vector3 velocity;         // 移動方向
    [Header("移動速度")]
    [SerializeField] private float moveSpeed = 5.0f;   // 移動速度

    float total_vel;

    void SlimeMove()
    {
        var velo = Horizontalrotation * new Vector3(inputHorizontal, 0, inputVertical).normalized;
       
        if (rb.velocity.magnitude < 5)
        {
            rb.AddForce(velo * moveSpeed,ForceMode.Force);
        }

        

        // キャラクターの向きを進行方向に
        if (velo != Vector3.zero)
        {
            total_vel += velo.magnitude * Time.deltaTime;
            if(total_vel>= 2.0f)
            {
                GetComponent<SlimeAudio>().PlayFootstepSE();
                total_vel = 0;
            }
            transform.rotation = Quaternion.LookRotation(velo);
        }
    }

    [Header("ジャンプパワー")]
    public float upForce = 200f; //上方向にかける力
    [Header("着地しているかどうか")]
    [SerializeField] private bool isGround; //着地しているかどうかの判定

    [SerializeField] public GameObject cold_effect;
    void Jump()
    {
        if (isGround == true)//着地しているとき
        {
            if (m_state == SLIME_CORE_STATE.COLD) return;
            

                if (Input.GetKeyDown("space"))
                {
                    isGround = false;//  isGroundをfalseにする
                    rb.AddForce(new Vector3(0, upForce, 0)); //上に向かって力を加える
                }
            
        }
    }

    
    [Header("氷のマテリアル")]
    [SerializeField] public Material[] _material;
    [SerializeField] public Vector3 target_scale;

    [SerializeField] public PhysicMaterial[] _physicMaterial;

    void ChangeState(GameObject obj)
    {

        m_state = SLIME_CORE_STATE.COLD;

        Transform children = obj.GetComponentInChildren<Transform>();
        //子要素がいなければ終了
        if (children.childCount == 0)
        {
            return;
        }

        foreach (Transform ob in children)
        {

            SlimeContoroller slime_con = ob.gameObject.GetComponent<SlimeContoroller>();

            if (slime_con.m_is_sticking)
            {
                //引っ張られている子スライムの状態をコールドに
                slime_con.m_state = SlimeContoroller.E_SLIME_STATE.eCold;

                slime_con.gameObject.SetActive(false);
            }

        }

        {
            //メッシュを四角に変更
            //this.GetComponent<MeshFilter>().mesh = Cube;
            //マテリアルを氷に
            this.GetComponent<MeshRenderer>().material = _material[1];
            //スフィアコライダーをＯＦＦに
            //this.GetComponent<SphereCollider>().enabled = false;
            //ＢＯＸコライダーをＯＮに
            //this.GetComponent<BoxCollider>().enabled = true;

            this.GetComponent<SphereCollider>().material = _physicMaterial[1];

            //子スライムの数の割合で氷になった時の大きさが変わる
            int slime_num = this.GetComponent<SlimeConcentration>().m_stick_num;

            //最大値
            float scale_max = 3.0f;
            float per = slime_num / 100f;

            target_scale = new Vector3(per, per, per) * scale_max;

            t = 0.0f;

            GameObject effect = Instantiate(cold_effect, this.transform);
            Destroy(effect,3.0f);
        }





    }

    [Header("遷移の時間")]
    [SerializeField] public float t;

    void ChageScale()
    {
        if (t <= 1)
        {
            this.transform.localScale = this.transform.localScale * (1 - t) + target_scale * t;
            t += Time.deltaTime / 5.0f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) //Groundタグのオブジェクトに触れたとき
        {
            isGround = true; //isGroundをtrueにする
            GetComponent<SlimeAudio>().PlayFootstepSE();
        }

       
    }

    private void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.CompareTag("ColdWind")) 
        {
            if (m_state != SLIME_CORE_STATE.COLD) ChangeState(m_slime);
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCoreController : MonoBehaviour
{
    [Tooltip("スライムが動くかどうか")]
    public static bool isActive = true;

    [Tooltip("スライムが動くかどうかRd")]
    public static Rigidbody rb;
    
    [SerializeField]
    [Tooltip("子スライム群")]
     public GameObject m_slime;

    [SerializeField]
    [Tooltip("メインカメラ")]
    Camera m_mainCamera;

    [SerializeField]
    [Tooltip("最高速度")]
    float m_max_magnitude;

    float inputHorizontal;
    float inputVertical;
    Quaternion Horizontalrotation;
    

    public enum SLIME_CORE_STATE
    {
        IDLE,
        COLD,
    }

    [SerializeField]
    [Tooltip("スライムの状態")]
     public SLIME_CORE_STATE m_state;

    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out rb);
        
        target_scale = this.transform.localScale;
        t = 1.0f;
        total_vel = 0;
        m_state = SLIME_CORE_STATE.IDLE;
    }


    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            Jump();
            SlimeMove();
            ChageScale();
        }
        
    }
    
    [SerializeField]
    [Tooltip("移動方向")]
    private Vector3 velocity;         // 移動方向
    [SerializeField] 
    [Tooltip("移動速度")]
    private float moveSpeed = 5.0f;   // 移動速度

    float total_vel;

    void SlimeMove()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
        Horizontalrotation = Quaternion.AngleAxis(m_mainCamera.transform.eulerAngles.y, Vector3.up);

        var velo = Horizontalrotation * new Vector3(inputHorizontal, 0, inputVertical).normalized;
       
        if (rb.velocity.magnitude < m_max_magnitude)
        {
            rb.AddForce(velo * moveSpeed * Time.deltaTime,ForceMode.Force);
            //rb.MovePosition(rb.position + velo * moveSpeed * Time.deltaTime);
        }

        // 音を鳴らす
        if (velo != Vector3.zero)
        {
            total_vel += velo.magnitude * Time.deltaTime;
            if(total_vel >= 2.0f)
            {
                GetComponent<SlimeAudio>().PlayFootstepSE();
                total_vel = 0;
            }    
        }
    }

    [Tooltip("ジャンプパワー")]
    public float upForce = 200f; //上方向にかける力 
    [SerializeField] 
    [Tooltip("着地しているかどうか")]
    private bool m_is_ground; //着地しているかどうかの判定
    [SerializeField]
    [Tooltip("ジャンプしているかどうか")]
    private bool m_is_jump=false; //着地しているかどうかの判定
    [SerializeField]
    [Tooltip("落下しているかどうか")]
    private bool m_is_falling;
    [SerializeField] 
    public GameObject cold_effect;

    void Jump()
    {
        //もしY軸の移動速度が0以上なら落下している
        var y_power = rb.velocity.y;
        m_is_falling = (y_power < 0) ? true : false;

        //落下中ではない状態で地面に接すると再びジャンプフラグがONになる
        if (!m_is_falling&&m_is_ground)m_is_jump = false;
        
        if (m_state == SLIME_CORE_STATE.COLD) return;//氷状態なら帰る
        if (m_is_jump) return;//ジャンプしているなら帰る

        if (Input.GetKeyDown("space"))
        {
            Debug.Log("ジャンプしています");
            m_is_jump = true;
            m_is_ground = false;//isGroundをfalseにする
            rb.AddForce(new Vector3(0, upForce, 0)); //上に向かって力を加える
        }          
        
    }

    
    
    [SerializeField]
    [Header("氷のマテリアル")] 
    public Material[] _material;
    [SerializeField] 
    public Vector3 target_scale;

    [SerializeField] 
    public PhysicMaterial[] _physicMaterial;

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


   
    [SerializeField] 
    [Header("遷移の時間")]
    public float t;

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
            m_is_ground = true; //isGroundをtrueにする
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

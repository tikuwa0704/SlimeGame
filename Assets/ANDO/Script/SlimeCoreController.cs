using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCoreController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
        Horizontalrotation = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y,Vector3.up);
        Jump();
        SlimeMove();
    }

    private void FixedUpdate()
    {
        
    }

    [SerializeField] private Vector3 velocity;         // 移動方向
    [SerializeField] private float moveSpeed = 5.0f;   // 移動速度

    float inputHorizontal;
    float inputVertical;
    Quaternion Horizontalrotation;
    Rigidbody rb;

    void SlimeMove()
    {
        var velo = Horizontalrotation * new Vector3(inputHorizontal, 0, inputVertical).normalized;
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);
        //rb.AddForce(velo * moveSpeed,ForceMode.Force);

        // キャラクターの向きを進行方向に
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }

    public float upForce = 200f; //上方向にかける力
    [SerializeField] private bool isGround; //着地しているかどうかの判定

    void Jump()
    {
        if (isGround == true)//着地しているとき
        {
            if (Input.GetKeyDown("space"))
            {
                isGround = false;//  isGroundをfalseにする
                rb.AddForce(new Vector3(0, upForce, 0)); //上に向かって力を加える
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) //Groundタグのオブジェクトに触れたとき
        {
            isGround = true; //isGroundをtrueにする
        }
    }
    
}

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
        //SlimeMove();
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
        Jump();
    }

    private void FixedUpdate()
    {
        SlimeMove2();

    }

    [SerializeField] private Vector3 velocity;         // 移動方向
    [SerializeField] private float moveSpeed = 5.0f;   // 移動速度

    void SlimeMove()
    {
        // WASD入力から、XZ平面(水平な地面)を移動する方向(velocity)を得ます
        velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            velocity.z += 1;
        if (Input.GetKey(KeyCode.A))
            velocity.x -= 1;
        if (Input.GetKey(KeyCode.S))
            velocity.z -= 1;
        if (Input.GetKey(KeyCode.D))
            velocity.x += 1;

        // 速度ベクトルの長さを1秒でmoveSpeedだけ進むように調整します
        velocity = velocity.normalized * moveSpeed * Time.deltaTime;

        // いずれかの方向に移動している場合
        if (velocity.magnitude > 0)
        {
            // プレイヤーの位置(transform.position)の更新
            // 移動方向ベクトル(velocity)を足し込みます
            transform.position += velocity;
        }
    }

    float inputHorizontal;
    float inputVertical;
    Rigidbody rb;

    void SlimeMove2()
    {
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);

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

    void OnCollisionEnter(Collision other) //地面に触れた時の処理
    {
        if (other.gameObject.CompareTag("Ground")) //Groundタグのオブジェクトに触れたとき
        {
            isGround = true; //isGroundをtrueにする
        }
    }
}

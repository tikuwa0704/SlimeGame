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

    [SerializeField] private Vector3 velocity;         // �ړ�����
    [SerializeField] private float moveSpeed = 5.0f;   // �ړ����x

    void SlimeMove()
    {
        // WASD���͂���AXZ����(�����Ȓn��)���ړ��������(velocity)�𓾂܂�
        velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            velocity.z += 1;
        if (Input.GetKey(KeyCode.A))
            velocity.x -= 1;
        if (Input.GetKey(KeyCode.S))
            velocity.z -= 1;
        if (Input.GetKey(KeyCode.D))
            velocity.x += 1;

        // ���x�x�N�g���̒�����1�b��moveSpeed�����i�ނ悤�ɒ������܂�
        velocity = velocity.normalized * moveSpeed * Time.deltaTime;

        // �����ꂩ�̕����Ɉړ����Ă���ꍇ
        if (velocity.magnitude > 0)
        {
            // �v���C���[�̈ʒu(transform.position)�̍X�V
            // �ړ������x�N�g��(velocity)�𑫂����݂܂�
            transform.position += velocity;
        }
    }

    float inputHorizontal;
    float inputVertical;
    Rigidbody rb;

    void SlimeMove2()
    {
        // �J�����̕�������AX-Z���ʂ̒P�ʃx�N�g�����擾
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // �����L�[�̓��͒l�ƃJ�����̌�������A�ړ�����������
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

        // �ړ������ɃX�s�[�h���|����B�W�����v�◎��������ꍇ�́A�ʓrY�������̑��x�x�N�g���𑫂��B
        rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);

        // �L�����N�^�[�̌�����i�s������
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }

    public float upForce = 200f; //������ɂ������
    [SerializeField] private bool isGround; //���n���Ă��邩�ǂ����̔���

    void Jump()
    {
        if (isGround == true)//���n���Ă���Ƃ�
        {
            if (Input.GetKeyDown("space"))
            {
                isGround = false;//  isGround��false�ɂ���
                rb.AddForce(new Vector3(0, upForce, 0)); //��Ɍ������ė͂�������
            }
        }
    }

    void OnCollisionEnter(Collision other) //�n�ʂɐG�ꂽ���̏���
    {
        if (other.gameObject.CompareTag("Ground")) //Ground�^�O�̃I�u�W�F�N�g�ɐG�ꂽ�Ƃ�
        {
            isGround = true; //isGround��true�ɂ���
        }
    }
}

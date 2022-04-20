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

    [SerializeField] private Vector3 velocity;         // �ړ�����
    [SerializeField] private float moveSpeed = 5.0f;   // �ړ����x

    float inputHorizontal;
    float inputVertical;
    Quaternion Horizontalrotation;
    Rigidbody rb;

    void SlimeMove()
    {
        var velo = Horizontalrotation * new Vector3(inputHorizontal, 0, inputVertical).normalized;
        // �J�����̕�������AX-Z���ʂ̒P�ʃx�N�g�����擾
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // �����L�[�̓��͒l�ƃJ�����̌�������A�ړ�����������
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

        // �ړ������ɃX�s�[�h���|����B�W�����v�◎��������ꍇ�́A�ʓrY�������̑��x�x�N�g���𑫂��B
        rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);
        //rb.AddForce(velo * moveSpeed,ForceMode.Force);

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) //Ground�^�O�̃I�u�W�F�N�g�ɐG�ꂽ�Ƃ�
        {
            isGround = true; //isGround��true�ɂ���
        }
    }
    
}

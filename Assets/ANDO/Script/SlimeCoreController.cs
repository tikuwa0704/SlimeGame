using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCoreController : MonoBehaviour
{
    
    [Header("�q�X���C���Q")]
    [SerializeField] public GameObject m_slime;

    float inputHorizontal;
    float inputVertical;
    Quaternion Horizontalrotation;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target_scale = this.transform.localScale;
        t = 1.0f;
    }

    
    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
        Horizontalrotation = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y,Vector3.up);
        Jump();
        SlimeMove();
        ChangeState(m_slime);
        ChageScale();
    }

    [Header("�ړ�����")]
    [SerializeField] private Vector3 velocity;         // �ړ�����
    [Header("�ړ����x")]
    [SerializeField] private float moveSpeed = 5.0f;   // �ړ����x

    void SlimeMove()
    {
        var velo = Horizontalrotation * new Vector3(inputHorizontal, 0, inputVertical).normalized;
       
        rb.AddForce(velo * moveSpeed,ForceMode.Force);
       
        // �L�����N�^�[�̌�����i�s������
        if (velo != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(velo);
        }
    }

    [Header("�W�����v�p���[")]
    public float upForce = 200f; //������ɂ������
    [Header("���n���Ă��邩�ǂ���")]
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

    [Header("�l�p�̃��b�V��")]
    [SerializeField] public Mesh Cube;
    [Header("�X�̃}�e���A��")]
    [SerializeField] public Material[] _material;
    [SerializeField] public Vector3 target_scale;

    void ChangeState(GameObject obj)
    {

        if (Input.GetKeyDown("z"))
        {

            Transform children = obj.GetComponentInChildren<Transform>();
            //�q�v�f�����Ȃ���ΏI��
            if (children.childCount == 0)
            {
                return;
            }
            
            foreach (Transform ob in children)
            {

                SlimeContoroller slime_con = ob.gameObject.GetComponent<SlimeContoroller>();

                if (slime_con.m_is_sticking)
                {
                    //���������Ă���q�X���C���̏�Ԃ��R�[���h��
                   slime_con.m_state = SlimeContoroller.E_SLIME_STATE.eCold;

                    //���b�V�����l�p�ɕύX
                    //this.GetComponent<MeshFilter>().mesh = Cube;
                    //�}�e���A����X��
                    this.GetComponent<MeshRenderer>().material = _material[1];
                    //�X�t�B�A�R���C�_�[���n�e�e��
                    //this.GetComponent<SphereCollider>().enabled = false;
                    //�a�n�w�R���C�_�[���n�m��
                    //this.GetComponent<BoxCollider>().enabled = true;

                    //�q�X���C���̐��̊����ŕX�ɂȂ������̑傫�����ς��
                    int slime_num = this.GetComponent<SlimeConcentration>().m_sticking_slime_num;

                    //�ő�l
                    float scale_max = 3.0f;
                    float per = slime_num / 100f;

                    target_scale = new Vector3(per, per, per)*scale_max;

                    t = 0.0f;
                }
               

            }

            
        }


    }

    [Header("�J�ڂ̎���")]
    [SerializeField] public float t;

    void ChageScale()
    {
        if (t <= 1)
        {
            this.transform.localScale = this.transform.localScale * (1 - t) + target_scale * t;
            t += Time.deltaTime / 3.0f;
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

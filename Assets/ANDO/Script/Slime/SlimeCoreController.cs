using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCoreController : MonoBehaviour
{
    [Header("�X���C�����������ǂ���")]
    public static bool isActive = true;

    [Header("�q�X���C���Q")]
    [SerializeField] public GameObject m_slime;

    [SerializeField]
    [Header("���C���J����")]
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

    [Header("�X���C���̏��")]
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

    [Header("�ړ�����")]
    [SerializeField] private Vector3 velocity;         // �ړ�����
    [Header("�ړ����x")]
    [SerializeField] private float moveSpeed = 5.0f;   // �ړ����x

    float total_vel;

    void SlimeMove()
    {
        var velo = Horizontalrotation * new Vector3(inputHorizontal, 0, inputVertical).normalized;
       
        if (rb.velocity.magnitude < 5)
        {
            rb.AddForce(velo * moveSpeed,ForceMode.Force);
        }

        

        // �L�����N�^�[�̌�����i�s������
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

    [Header("�W�����v�p���[")]
    public float upForce = 200f; //������ɂ������
    [Header("���n���Ă��邩�ǂ���")]
    [SerializeField] private bool isGround; //���n���Ă��邩�ǂ����̔���

    [SerializeField] public GameObject cold_effect;
    void Jump()
    {
        if (isGround == true)//���n���Ă���Ƃ�
        {
            if (m_state == SLIME_CORE_STATE.COLD) return;
            

                if (Input.GetKeyDown("space"))
                {
                    isGround = false;//  isGround��false�ɂ���
                    rb.AddForce(new Vector3(0, upForce, 0)); //��Ɍ������ė͂�������
                }
            
        }
    }

    
    [Header("�X�̃}�e���A��")]
    [SerializeField] public Material[] _material;
    [SerializeField] public Vector3 target_scale;

    [SerializeField] public PhysicMaterial[] _physicMaterial;

    void ChangeState(GameObject obj)
    {

        m_state = SLIME_CORE_STATE.COLD;

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

                slime_con.gameObject.SetActive(false);
            }

        }

        {
            //���b�V�����l�p�ɕύX
            //this.GetComponent<MeshFilter>().mesh = Cube;
            //�}�e���A����X��
            this.GetComponent<MeshRenderer>().material = _material[1];
            //�X�t�B�A�R���C�_�[���n�e�e��
            //this.GetComponent<SphereCollider>().enabled = false;
            //�a�n�w�R���C�_�[���n�m��
            //this.GetComponent<BoxCollider>().enabled = true;

            this.GetComponent<SphereCollider>().material = _physicMaterial[1];

            //�q�X���C���̐��̊����ŕX�ɂȂ������̑傫�����ς��
            int slime_num = this.GetComponent<SlimeConcentration>().m_stick_num;

            //�ő�l
            float scale_max = 3.0f;
            float per = slime_num / 100f;

            target_scale = new Vector3(per, per, per) * scale_max;

            t = 0.0f;

            GameObject effect = Instantiate(cold_effect, this.transform);
            Destroy(effect,3.0f);
        }





    }

    [Header("�J�ڂ̎���")]
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
        if (collision.gameObject.CompareTag("Ground")) //Ground�^�O�̃I�u�W�F�N�g�ɐG�ꂽ�Ƃ�
        {
            isGround = true; //isGround��true�ɂ���
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCoreController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�q�X���C���̃v���n�u")]
    GameObject slimeChildrenPrefab;

    [Tooltip("�X���C�����������ǂ���")]
    public static bool isActive = true;

    [Tooltip("Rd")]
    public static Rigidbody rb;
    
    [SerializeField]
    [Tooltip("�q�X���C���Q")]
     public GameObject m_slime;

    [SerializeField]
    [Tooltip("���C���J����")]
    Camera m_mainCamera;

    [SerializeField]
    [Tooltip("�ō����x")]
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
    [Tooltip("�X���C���̏��")]
     public SLIME_CORE_STATE m_state;

    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out rb);
        
        target_scale = this.transform.localScale;
        t = 1.0f;
        total_vel = 0;
        m_state = SLIME_CORE_STATE.IDLE;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }


    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            Jump();
            Move();
            ChageScale();
        }
        
    }
    
    [SerializeField]
    [Tooltip("�ړ�����")]
    private Vector3 velocity;         // �ړ�����
    [SerializeField] 
    [Tooltip("�ʏ��Ԃ̈ړ����x")]
    private float m_moveSpeedIdle = 5.0f;   // �ړ����x
    [SerializeField]
    [Tooltip("�X��Ԃ̈ړ����x")]
    private float m_moveSpeedCold = 5.0f;   // �ړ����x
    [SerializeField]
    [Tooltip("�ړ��x�N�g��")]
    private Vector3 m_moveVector = new Vector3(0,0,0);   // �ړ����x

    float total_vel;

    void Move()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
        Horizontalrotation = Quaternion.AngleAxis(m_mainCamera.transform.eulerAngles.y, Vector3.up);

        var velo = Horizontalrotation * new Vector3(inputHorizontal, 0, inputVertical).normalized;

         
        switch (m_state)
        {
            case SLIME_CORE_STATE.IDLE:

                m_moveVector += velo * m_moveSpeedIdle * Time.deltaTime;
                //rb.MovePosition(rb.position + m_moveVector * Time.deltaTime);
                transform.position += m_moveVector * Time.deltaTime;
                m_moveVector *= 0.85f;

                break;
            case SLIME_CORE_STATE.COLD:
                rb.AddForce(velo * m_moveSpeedCold * Time.deltaTime, ForceMode.Force);
                break;
        }
        

        // ����炷
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

    [Tooltip("�W�����v�p���[")]
    public float upForce = 200f; //������ɂ������ 
    [SerializeField] 
    [Tooltip("���n���Ă��邩�ǂ���")]
    private bool m_is_ground; //���n���Ă��邩�ǂ����̔���
    [SerializeField]
    [Tooltip("�W�����v���Ă��邩�ǂ���")]
    private bool m_is_jump=false; //���n���Ă��邩�ǂ����̔���
    [SerializeField]
    [Tooltip("�������Ă��邩�ǂ���")]
    private bool m_is_falling;
    [SerializeField] 
    public GameObject cold_effect;

    void Jump()
    {
        //����Y���̈ړ����x��0�ȏ�Ȃ痎�����Ă���
        var y_power = rb.velocity.y;
        m_is_falling = (y_power < 0) ? true : false;

        //�������ł͂Ȃ���ԂŒn�ʂɐڂ���ƍĂуW�����v�t���O��ON�ɂȂ�
        if (!m_is_falling&&m_is_ground)m_is_jump = false;
        
        if (m_state == SLIME_CORE_STATE.COLD) return;//�X��ԂȂ�A��
        if (m_is_jump) return;//�W�����v���Ă���Ȃ�A��

        if (Input.GetKeyDown("space"))
        {
            Debug.Log("�W�����v���Ă��܂�");
            m_is_jump = true;
            m_is_ground = false;//isGround��false�ɂ���
            rb.AddForce(new Vector3(0, upForce, 0)); //��Ɍ������ė͂�������
        }          
        
    }

    
    
    [SerializeField]
    [Header("�}�e���A���̔z��")] 
    public Material[] _material;
    [SerializeField] 
    public Vector3 target_scale;

    [SerializeField] 
    public PhysicMaterial[] _physicMaterial;

    void ChangeState(GameObject obj)
    {

        m_state = SLIME_CORE_STATE.COLD;
        rb.constraints = RigidbodyConstraints.None;
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
            int slime_num = Mathf.Max(1,this.GetComponent<SlimeConcentration>().m_stick_num);

            //�ő�l
            float scale_max = 3.0f;
            float per = slime_num / 100f;

            target_scale = new Vector3(per, per, per) * scale_max;

            t = 0.0f;

            GameObject effect = Instantiate(cold_effect, this.transform);
            Destroy(effect,3.0f);
        }

    }


   
    [SerializeField] 
    [Header("�J�ڂ̎���")]
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
        if (collision.gameObject.CompareTag("Ground")) //Ground�^�O�̃I�u�W�F�N�g�ɐG�ꂽ�Ƃ�
        {
            m_is_ground = true; //isGround��true�ɂ���
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


    //�����̎���Ɏq�X���C���𐶐�
    public void GenerateSlime(int spawnNum)
    {

        spawnNum = Mathf.Max(0, spawnNum);

        for(int i= 0; i < spawnNum; i++)
        {
            //�e�X���C���̒n�_
            Vector3 parentPosition = transform.position;
            float rangeX = 5.0f;
            float rangeY = 5.0f;
            float rangeZ = 5.0f;

            // rangeA��rangeB��x���W�͈͓̔��Ń����_���Ȑ��l���쐬
            float x = Random.Range(parentPosition.x - rangeX, parentPosition.x + rangeX);
            // rangeA��rangeB��y���W�͈͓̔��Ń����_���Ȑ��l���쐬
            float y = Random.Range(parentPosition.y, parentPosition.y + rangeY);
            // rangeA��rangeB��z���W�͈͓̔��Ń����_���Ȑ��l���쐬
            float z = Random.Range(parentPosition.z - rangeZ, parentPosition.z + rangeZ);

            GameObject obj = Instantiate(slimeChildrenPrefab, new Vector3(x, y, z), slimeChildrenPrefab.transform.rotation);

            obj.transform.parent = m_slime.transform;

        }
    }


    //�q�X���C������������
    public void DestorySlime()
    {
        var children = m_slime.GetComponentInChildren<Transform>();

        foreach(Transform obj in children)
        {
            //
            Destroy(obj.gameObject);
        }
    }


    public void ChangeIdleState()
    {
        
        this.GetComponent<MeshRenderer>().material = _material[0];
        
        this.GetComponent<SphereCollider>().material = _physicMaterial[0];

        m_state = SLIME_CORE_STATE.IDLE;

        rb.constraints = RigidbodyConstraints.FreezeRotation;

        target_scale = Vector3.one;

        t = 0.0f;

        GameObject effect = Instantiate(cold_effect, this.transform);
        Destroy(effect, 3.0f);
    }

}

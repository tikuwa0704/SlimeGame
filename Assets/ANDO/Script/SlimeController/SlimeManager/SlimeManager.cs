using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StateMachineAI;

public enum E_SLIMES_STATE
{
    E_NORMAL,//�ʏ���
    E_ICE,//�X���
    E_PAUSE,//��~���
}

public class SlimeManager : StatefulObjectBase<SlimeManager,E_SLIMES_STATE>
{
    public static SlimeManager Instance { get; private set; }

    [SerializeField]
    [Tooltip("�A�C�X�X���C���v���n�u")]
    public GameObject icePrefab;
    [SerializeField]
    [Tooltip("�q�X���C���̃v���n�u")]
    GameObject childSlimePrefab;
    [Tooltip("���W�b�h�{�f�B")]
    public Rigidbody rigidBody;
    [SerializeField]
    [Tooltip("�q�X���C���Q�̐e�I�u�W�F�N�g")]
    public GameObject childrenSlimeParent;
    [SerializeField]
    [Tooltip("���C���J����")]
    public Camera mainCamera;
    [SerializeField]
    [Tooltip("�ō����x")]
    float m_max_magnitude;
    [Tooltip("�X���C�����������ǂ���")]
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
    [Tooltip("�ړ�����")]
    public Vector3 velocity;         // �ړ�����
    [SerializeField]
    [Tooltip("�ʏ��Ԃ̈ړ����x")]
    public float m_moveSpeedIdle = 5.0f;   // �ړ����x
    [SerializeField]
    [Tooltip("�X��Ԃ̈ړ����x")]
    public float m_moveSpeedCold = 5.0f;   // �ړ����x
    [SerializeField]
    [Tooltip("�ړ��x�N�g��")]
    public Vector3 m_moveVector = new Vector3(0, 0, 0);   // �ړ����x
    [Tooltip("�W�����v�p���[")]
    public float upForce = 200f; //������ɂ������ 
    [SerializeField]
    [Tooltip("���n���Ă��邩�ǂ���")]
    public bool m_is_ground; //���n���Ă��邩�ǂ����̔���
    [SerializeField]
    [Tooltip("�W�����v���Ă��邩�ǂ���")]
    public bool m_is_jump = false; //���n���Ă��邩�ǂ����̔���
    [SerializeField]
    [Tooltip("�W�����v�̉\��")]
    public int jumpCountMax; 
    [SerializeField]
    [Tooltip("�W�����v�̉�")]
    public int jumpCount=0;
    [SerializeField]
    [Tooltip("�������Ă��邩�ǂ���")]
    public bool m_is_falling;
    [SerializeField]
    public GameObject cold_effect;


    [SerializeField]
    [Header("�}�e���A���̔z��")]
    public Material[] _material;
    [SerializeField]
    public Vector3 target_scale;

    [SerializeField]
    public PhysicMaterial[] _physicMaterial;

    [SerializeField]
    [Header("�J�ڂ̎���")]
    public float t;


    private void OnCollisionEnter(Collision collision)
    {
        if (IsCurrentState(E_SLIMES_STATE.E_NORMAL))
        {
            for (int i = 0; i < collision.contacts.Length; i++)
            {

                // �Փˈʒu���擾����
                Vector3 hitPos = collision.contacts[i].point;

                Vector3 dir = hitPos - this.transform.position;

                if (dir.y <= -0.25)
                {
                    jumpCount = 0;
                    //jumpCount = 0;
                    //m_is_ground = true; //isGround��true�ɂ���
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
        // �Փˈʒu���擾����
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
        //�X
        if (other.gameObject.CompareTag("ColdWind"))
        {
            if (IsCurrentState(E_SLIMES_STATE.E_NORMAL)) ChangeState(E_SLIMES_STATE.E_ICE);
        }
        //Fire�^�O�̃I�u�W�F�N�g�ɐG��Ă���
        if (other.gameObject.CompareTag("Fire"))
        {
            //�X��ԂȂ������
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
    //    //Ground�^�O�̃I�u�W�F�N�g�ɐG��Ă���
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        m_is_ground = true; //isGround��true�ɂ���
    //        //GetComponent<SlimeAudio>().PlayFootstepSE();
    //    }
    //}

    //�����̎���Ɏq�X���C���𐶐�
    public void GenerateSlime(int spawnNum)
    {

        spawnNum = Mathf.Max(0, spawnNum);

        for (int i = 0; i < spawnNum; i++)
        {
            //�e�X���C���̒n�_
            Vector3 parentPosition = transform.position;
            float rangeX = 3.0f;
            float rangeY = 3.0f;
            float rangeZ = 3.0f;

            // rangeA��rangeB��x���W�͈͓̔��Ń����_���Ȑ��l���쐬
            float x = Random.Range(parentPosition.x - rangeX, parentPosition.x + rangeX);
            // rangeA��rangeB��y���W�͈͓̔��Ń����_���Ȑ��l���쐬
            float y = Random.Range(parentPosition.y, parentPosition.y + rangeY);
            // rangeA��rangeB��z���W�͈͓̔��Ń����_���Ȑ��l���쐬
            float z = Random.Range(parentPosition.z - rangeZ, parentPosition.z + rangeZ);

            GameObject obj = Instantiate(childSlimePrefab, new Vector3(x, y, z), childSlimePrefab.transform.rotation);

            obj.transform.parent = childrenSlimeParent.transform;

        }
    }

    public void GenerateSlime(Vector3 point)
    {
        //100�̈ȏ�͍��Ȃ�
        if (GetSlimeNum() >= 100) return;
        //�e�X���C���̒n�_
        Vector3 parentPosition = transform.position;

        GameObject obj = Instantiate(childSlimePrefab, point, childSlimePrefab.transform.rotation);

        obj.transform.parent = childrenSlimeParent.transform;
    }


    //�q�X���C������������
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
        //�v���C���[�𓮂��Ȃ�����
        isActive = false;
        rigidBody.velocity = Vector3.zero;
        //rigidBody.isKinematic = true;
        
    }

    public void StopPause()
    {
        //�v���C���[�𓮂���悤�ɂ���
        isActive = true;
        //rigidBody.isKinematic = false;

    }

    //�������Ă���X���C���̒��ň�ԉ����X���C����O���ɔ�΂��ʏ��Ԃ���
    public void ThrowSlimeFar(float power)
    {

        Transform slime;
        if(slime= GetFarStickSlime(mainCamera.transform.position))
        {
            //�Ƃꂽ�Ȃ瓊����
            Rigidbody rb = slime.GetComponent<Rigidbody>();
            
            rb.AddForce(mainCamera.transform.forward * power);
            SlimeContoroller slime1 =  slime.GetComponent<SlimeContoroller>();
            slime1.m_state = SlimeContoroller.E_SLIME_STATE.eThrow;
            slime1.m_is_sticking = false;
        }

    }
        
    //�������Ă��钆�Œn�_�����ԉ����X���C�����擾
    public Transform GetFarStickSlime(Vector3 pos)
    {
        var children = childrenSlimeParent.GetComponentInChildren<Transform>();

        float currentLength = 0;
        Transform o = null;

        foreach (Transform obj in children)
        {
            SlimeContoroller slime = obj.gameObject.GetComponent<SlimeContoroller>();
            //�������ĂȂ��Ȃ画�肵�Ȃ�
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
            //�Ƃꂽ�Ȃ瓊����
            Rigidbody rb = slime.GetComponent<Rigidbody>();

            rb.AddForce(-mainCamera.transform.forward * power);
            SlimeContoroller slime1 = slime.GetComponent<SlimeContoroller>();
            slime1.m_state = SlimeContoroller.E_SLIME_STATE.eThrow;
            slime1.m_is_sticking = false;
        }

    }

    //�������Ă��钆�Œn�_�����ԋ߂��X���C�����擾
    public Transform GetNearStickSlime(Vector3 pos)
    {
        var children = childrenSlimeParent.GetComponentInChildren<Transform>();

        float currentLength = float.MaxValue;
        Transform o = null;

        foreach (Transform obj in children)
        {
            SlimeContoroller slime = obj.gameObject.GetComponent<SlimeContoroller>();
            //�������ĂȂ��Ȃ画�肵�Ȃ�
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

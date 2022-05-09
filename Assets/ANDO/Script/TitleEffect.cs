using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleEffect : MonoBehaviour
{
    enum E_TITLE_STATE
    {
        E_GENERATION,//�X���C���̐���
        E_STICK_BEGIN, //�������J�n
        E_STICK,�@�@ //�X���C��������
        E_LEAVE_BEGIN,//�����J�n
        E_LEAVE,     //�����
    }

    [SerializeField]
    [Tooltip("�X�e�[�g")]
    E_TITLE_STATE m_state;
    [SerializeField]
    [Tooltip("�X���C���̐�")]
    int m_slimeChildrenNum;
    [SerializeField]
    [Tooltip("�����񂹂钆�S")]
    GameObject m_slimeCore;
    [SerializeField]
    [Tooltip("�n��")]
    GameObject m_ground;


    // Start is called before the first frame update
    void Start()
    {
        m_state = E_TITLE_STATE.E_GENERATION;
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_state)
        {
            case E_TITLE_STATE.E_GENERATION:
                GenerateSlime();
                break;
            case E_TITLE_STATE.E_STICK_BEGIN:
                StickSlimeBeginState();
                break;
            case E_TITLE_STATE.E_STICK:
                StickSlimeState();
                break;
            case E_TITLE_STATE.E_LEAVE_BEGIN:
                LeaveBeginState();
                break;
            case E_TITLE_STATE.E_LEAVE:
                LeaveState();
                break;
        }



    }


    void GenerateSlime()
    {

        if (StickSlime.m_stick_num>=100)
        {
            m_state = E_TITLE_STATE.E_STICK_BEGIN;
        }

    }

    void StickSlimeBeginState()
    {
        StickSlime.m_is_stick = true;
        m_cnt = 10.0f;
        m_state = E_TITLE_STATE.E_STICK;
        
    }
    
    [SerializeField]
    [Tooltip("����")]
    float m_cnt;

    void StickSlimeState()
    {
        m_cnt -= Time.deltaTime;

        if (m_cnt <= 0)
        {

            m_state = E_TITLE_STATE.E_LEAVE_BEGIN;

        }


    }

    void LeaveBeginState()
    {
        StickSlime.m_is_stick = false;
        m_ground.GetComponent<BoxCollider>().isTrigger = true;
        m_cnt = 2.0f;
        m_state = E_TITLE_STATE.E_LEAVE;

    }

    void LeaveState()
    {
        m_cnt -= Time.deltaTime;

        if (m_cnt <= 0)
        {
            m_ground.GetComponent<BoxCollider>().isTrigger = false;
            m_state = E_TITLE_STATE.E_GENERATION;

        }
    }

}

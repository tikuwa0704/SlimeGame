using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleEffect : MonoBehaviour
{
    enum E_TITLE_STATE
    {
        E_GENERATION,//スライムの生成
        E_STICK_BEGIN, //くっつき開始
        E_STICK,　　 //スライムくっつく
        E_LEAVE_BEGIN,//離れる開始
        E_LEAVE,     //離れる
        E_LEAVE_END, //離れる終わり
    }

    [SerializeField]
    [Tooltip("ステート")]
    E_TITLE_STATE m_state;
    [SerializeField]
    [Tooltip("スライムの数")]
    int m_slimeChildrenNum;
    [SerializeField]
    [Tooltip("地面")]
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
            case E_TITLE_STATE.E_LEAVE_END:
                LeaveEndState();
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
    [Tooltip("時間")]
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
        m_cnt = 5.0f;
        m_state = E_TITLE_STATE.E_LEAVE;

    }

    void LeaveState()
    {
        m_cnt -= Time.deltaTime;

        if (m_cnt <= 0)
        {
            m_cnt = 3.0f;
            m_ground.GetComponent<MeshCollider>().enabled = false;
            m_state = E_TITLE_STATE.E_LEAVE_END;

        }
    }
    
    void LeaveEndState()
    {
       
       
        m_cnt -= Time.deltaTime;

        if (m_cnt <= 0)
        { 
            m_ground.GetComponent<MeshCollider>().enabled = true;
            m_state = E_TITLE_STATE.E_GENERATION;

        }
    }

}

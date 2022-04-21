using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeContoroller : MonoBehaviour
{
    //èÛë‘
    public enum E_SLIME_STATE{
        eIdle,
        eCold,
        eHot,
    }

    [SerializeField] public bool m_is_sticking;

    [SerializeField] public E_SLIME_STATE m_state;

    // Start is called before the first frame update
    void Start()
    {
        m_is_sticking = true;

        m_state = E_SLIME_STATE.eHot;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

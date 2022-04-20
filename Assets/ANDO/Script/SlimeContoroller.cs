using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeContoroller : MonoBehaviour
{
    //èÛë‘
    public enum E_SLIME_STATE{
        eIdle,
        eCold,
    }

    [SerializeField] public E_SLIME_STATE m_state;

    // Start is called before the first frame update
    void Start()
    {
        m_state = E_SLIME_STATE.eIdle;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            m_state = E_SLIME_STATE.eCold;
        }
    }
}

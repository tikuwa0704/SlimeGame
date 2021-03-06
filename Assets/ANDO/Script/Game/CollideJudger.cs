using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideJudger : MonoBehaviour
{
    [SerializeField]
    [Tooltip("タグ")]
    System.String m_collide_tag;

    [SerializeField]
    [Tooltip("当たったかどうか")]
    public bool m_is_collide;

    private void Start()
    {
        m_is_collide = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag(m_collide_tag))
        {

            m_is_collide = true;

        }
    }
}

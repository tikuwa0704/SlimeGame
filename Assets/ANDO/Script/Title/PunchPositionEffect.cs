using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class PunchPositionEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOPunchPosition(
    new Vector3(0, 1, 0), // �p���`�̕����Ƌ���
    1f                    // ���o����
);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

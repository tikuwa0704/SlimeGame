using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ʂ̏ڍ�
public class SnowBalls : MonoBehaviour
{
    //�X�P�[����ς��鑬�x
    private Vector3 speed = new Vector3(1f, 1f, 1f);

    // Update is called once per frame
    void Update()
    {
        //-=�ŏ��X�ɃX�P�[��������������
        transform.localScale += speed * Time.deltaTime;
        Invoke("Des", 3);
    }

    public void Des()
    {
        Destroy(this.gameObject);
    }
}

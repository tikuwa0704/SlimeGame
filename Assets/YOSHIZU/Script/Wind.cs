using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    /*
    //X�������̉����镗�̗�
    public float WindX = 0f;

    //Y�������̉����镗�̗�
    public float WindY = 0f;

    //Z�������̉����镗�̗�
    public float WindZ = 0f;
    */
    public float power = 0f;
    /// <summary>
    /// �g���K�[�͈̔͂ɓ����Ă���Ԃ����Ǝ��s�����
    /// </summary>
    /// <param name="Other"></param>
    private void OnTriggerStay(Collider Other)
    {
        if (Other.gameObject.tag == "Player")
        {
            // �������������rigidbody�R���|�[�l���g���擾
            Rigidbody OtherRigidbody = Other.GetComponent<Rigidbody>();
            // rigidbody��null�ł͂Ȃ��ꍇ�i�����GameObject��rigidbody���t���Ă���ꍇ�j
            if (OtherRigidbody != null)
            {
                // �����rigidbody�ɗ͂�������
                OtherRigidbody.AddForce(this.transform.forward * power * Time.deltaTime, ForceMode.Force);
            }
        }
      
    }
}

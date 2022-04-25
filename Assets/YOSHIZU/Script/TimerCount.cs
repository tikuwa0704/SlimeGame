using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerCount : MonoBehaviour
{
    //�g�[�^���̐�������
    private float TotalTime;
    //��������(��)
    private int Minutes = 1;
    //��������(�b)
    private float Seconds;
    //�O�̃A�b�v�f�[�g���̕b��
    private float OldSeconds;
    //�^�C�}�[�\���p�e�L�X�g(�����p)
    private Text TimerText;

    void Start()
    {
        TotalTime = Minutes * 60 + Seconds;
        OldSeconds = 0f;
        TimerText = GetComponentInChildren<Text>();
    }

    private void Update()
    {
        //�������Ԃ�0�ȉ��Ȃ�ω��Ȃ�
        if (TotalTime <= 0f)
        {
            return;
        }
        //���݂̐������Ԃ��v��
        TotalTime = Minutes * 60 + Seconds;
        TotalTime -= Time.deltaTime;
        //�Đݒ�
        Minutes = (int)TotalTime / 60;
        Seconds = TotalTime - Minutes * 60;
        //�^�C�}�[�\���p��UI�e�L�X�g�Ɍ��݂̐������Ԃ�\������
        if ((int)Seconds != (int)OldSeconds)
        {
            TimerText.text = Minutes.ToString("00") + ":" + ((int)Seconds).ToString("00");
        }
        OldSeconds = Seconds;
        //�������Ԃ�0�ȉ��ɂȂ�����R���\�[���Ɂu�������ԏI���v�Ƃ���������\��
        if (TotalTime <= 0f)
        {
            Debug.Log("�������ԏI��");
        }
    }
}

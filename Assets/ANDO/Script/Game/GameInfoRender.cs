using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class GameInfoRender : MonoBehaviour
{
    [SerializeField]
    [Tooltip("���݃X���C���̐�NumberSpriteText")]
    ImageNumberRender crrentSlimeNumText;

    [SerializeField]
    [Tooltip("���݃X���C���̐��̃X���C�_�[")]
    Image SlimeSlider;

    [SerializeField]
    [Tooltip("���ݍ��v�̃X�R�AText")]
    Text crrentTotalScoreText;

    [SerializeField]
    [Tooltip("�^�[�Q�b�g�X�R�A")]
    float targetTotalScore;

    [SerializeField]
    [Tooltip("���ݍ��v�̃X�R�A�̐��l")]
    float currentTotalScore;

    [SerializeField]
    [Tooltip("��������Text")]
    Text limitTime;

    [SerializeField]
    [Tooltip("���ʔ��\�p���݂̎��Ԃ̐��lText")]
    Text announceCurrentLimitText;

    [SerializeField]
    [Tooltip("���ʔ��\�p���݂̃X�R�A�̐��lText")]
    Text announceCurrentScoreText;

    [SerializeField]
    [Tooltip("���ʔ��\�p���݂̃X���C���̐�Text")]
    Text announceCurrentSlimeNumText;

    // Start is called before the first frame update
    void Start()
    {
        targetTotalScore = 0;
        currentTotalScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int num = SlimeManager.Instance.GetSlimeNum();
        //���݂̃X���C���̉摜�\��
        crrentSlimeNumText.DisplayNum = num;
        //���݂̃X���C���̃X���C�_�[�X�V
        SlimeSlider.fillAmount = Mathf.Min(1,num / 100.0f);

        //���݂̑S�ẴX�e�[�W�̍��v�̃X�R�A�\��
        crrentTotalScoreText.text = currentTotalScore.ToString("F0");
        if (currentTotalScore <= targetTotalScore) currentTotalScore =Mathf.Min(currentTotalScore + Time.deltaTime * 1000,targetTotalScore);

        //���݂̃X�e�[�W�̎c�莞�ԕ\��
        float time = ServiceLocator<IGameService>.Instance.GetLimitTime();

        int minutes = (int)time / 60;
        int second = (int)time % 60;

        limitTime.text = minutes + ":" + second.ToString("D2");


        //���ʔ��\�p
        //���݂̃X�e�[�W�̎c�莞��
        int t = (int)time;
        announceCurrentLimitText.text = t.ToString();

        //���݂̃X�e�[�W�̍ŏI�X�R�A
        announceCurrentScoreText.text = ServiceLocator<IGameService>.Instance.GetCurrentScore().ToString();

        //���݂̃X���C���̐�
        announceCurrentSlimeNumText.text = SlimeManager.Instance.GetSlimeNum().ToString();
    }

    public void SetAnnounceSCore()
    {
        //���݂̃X�e�[�W�̎c�莞�ԕ\��
        float time = ServiceLocator<IGameService>.Instance.GetLimitTime();
        //���ʔ��\�p
        //���݂̃X�e�[�W�̎c�莞��
        int t = (int)time;
        announceCurrentLimitText.text = t.ToString();

        //���݂̃X�e�[�W�̍ŏI�X�R�A
        announceCurrentScoreText.text = ServiceLocator<IGameService>.Instance.GetCurrentScore().ToString();

        //���݂̃X���C���̐�
        announceCurrentSlimeNumText.text = SlimeManager.Instance.GetSlimeNum().ToString();
    }

    public void SetTargetScore()
    {
        targetTotalScore = ServiceLocator<IGameService>.Instance.GetTotalScore();
    }
}

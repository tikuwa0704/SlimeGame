using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�w�i�摜")]
    Image backGround;

    [SerializeField]
    [Tooltip("GAMEOVER�����I�u�W�F�N�g")]
    List<GameObject> sprites = new List<GameObject>();

    [SerializeField]
    [Tooltip("���݂̕����̔ԍ�")]
    int currentSpriteNum;

    [SerializeField]
    float time;

    [SerializeField]
    float next_time = 1.0f;

    [SerializeField]
    bool isAnim;

    // Start is called before the first frame update
    void Start()
    {
        isAnim = false;
        time = 0.0f;
        currentSpriteNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAnim)
        {
            //�z��̒��g�Ȃ��Ȃ�I���
            if (sprites.Count <= 0) return;
            if (currentSpriteNum < sprites.Count)
            {
                time -= Time.deltaTime;
                if (time < 0)
                {
                    sprites[currentSpriteNum].transform.DOLocalMoveY(50, 2f).SetEase(Ease.OutBounce);
                    currentSpriteNum++;
                    time = next_time;
                    ServiceLocator<ISoundService>.Instance.Play("SE_�����Ռ�");
                }
            }
            
        }
        else
        {
            Color newColor = backGround.color;
            newColor.a = time;
            backGround.color = newColor;
            time += Time.deltaTime;
            if (time >= 1.0) {
                time = next_time;
                isAnim = true;
            }
        }
    }
}

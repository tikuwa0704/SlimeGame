using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    [Tooltip("背景画像")]
    Image backGround;

    [SerializeField]
    [Tooltip("GAMEOVER文字オブジェクト")]
    List<GameObject> sprites = new List<GameObject>();

    [SerializeField]
    [Tooltip("現在の文字の番号")]
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
            //配列の中身ないなら終わり
            if (sprites.Count <= 0) return;
            if (currentSpriteNum < sprites.Count)
            {
                time -= Time.deltaTime;
                if (time < 0)
                {
                    sprites[currentSpriteNum].transform.DOLocalMoveY(50, 2f).SetEase(Ease.OutBounce);
                    currentSpriteNum++;
                    time = next_time;
                    ServiceLocator<ISoundService>.Instance.Play("SE_文字衝撃");
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;

public class ImageNumberRender : MonoBehaviour
{

    [SerializeField]
    [Tooltip("使用する0から９までのスプライト画像")]
    private Sprite[] imageNumbers = new Sprite[10];

    [SerializeField]
    [Tooltip("画像の幅")]
    float width;

    [SerializeField]
    [Tooltip("画像の高さ")]
    float height;

    [SerializeField] 
    [Tooltip("数字の表示間隔")]
    float numWidth;

    //表示する値
    private int displayValue;

    //表示用スプライトオブジェクトの配列
    private GameObject[] NumSprite;

    //スプライトディクショナリ
    private Dictionary<string, Sprite> Sprite_Dictionary;

    //スプライトディクショナリを初期化
    void Awake()
    {
        Sprite_Dictionary = new Dictionary<string, Sprite>();

        for (int i = 0; i < imageNumbers.Length; i++)
        {
            Sprite_Dictionary.Add(i.ToString(), imageNumbers[i]);

        }
    }

    //表示する値
    public int DisplayNum
    {
        get
        {
            return displayValue;
        }

        set
        {
            displayValue = value;

            //表示文字列の取得
            string strValue = value.ToString();
            

            //現在表示中のオブジェクトを削除
            if (NumSprite != null)
            {
                foreach (var numsprite in NumSprite)
                {
                    GameObject.Destroy(numsprite);
                }
            }

            //表示する桁数分だけオブジェクト作成
            NumSprite = new GameObject[strValue.Length];
            
            for (var i = 0; i < NumSprite.Length; ++i)
            {

                //オブジェクト作成
                GameObject obj = NumSprite[i] = new GameObject();
                
                obj.transform.position = transform.position + new Vector3((float)i * numWidth, 0);
                obj.transform.rotation = Quaternion.identity;
                Image img = obj.AddComponent<Image>();
                RectTransform rect = obj.GetComponent<RectTransform>();
                rect.sizeDelta = new Vector2(width, height);
                //obj.transform.DOScale(1.1f, 2.0f).SetEase(Ease.OutElastic);

                //表示する数値の指定
                NumSprite[i].GetComponent<Image>().sprite = Sprite_Dictionary[strValue[i].ToString()];

                //自信の子階層に移動
                NumSprite[i].transform.SetParent(this.transform);
            }
        }


    }

}

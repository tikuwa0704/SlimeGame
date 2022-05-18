using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;

public class ImageNumberRender : MonoBehaviour
{

    [SerializeField]
    [Tooltip("�g�p����0����X�܂ł̃X�v���C�g�摜")]
    private Sprite[] imageNumbers = new Sprite[10];

    [SerializeField]
    [Tooltip("�摜�̕�")]
    float width;

    [SerializeField]
    [Tooltip("�摜�̍���")]
    float height;

    [SerializeField] 
    [Tooltip("�����̕\���Ԋu")]
    float numWidth;

    //�\������l
    private int displayValue;

    //�\���p�X�v���C�g�I�u�W�F�N�g�̔z��
    private GameObject[] NumSprite;

    //�X�v���C�g�f�B�N�V���i��
    private Dictionary<string, Sprite> Sprite_Dictionary;

    //�X�v���C�g�f�B�N�V���i����������
    void Awake()
    {
        Sprite_Dictionary = new Dictionary<string, Sprite>();

        for (int i = 0; i < imageNumbers.Length; i++)
        {
            Sprite_Dictionary.Add(i.ToString(), imageNumbers[i]);

        }
    }

    //�\������l
    public int DisplayNum
    {
        get
        {
            return displayValue;
        }

        set
        {
            displayValue = value;

            //�\��������̎擾
            string strValue = value.ToString();
            

            //���ݕ\�����̃I�u�W�F�N�g���폜
            if (NumSprite != null)
            {
                foreach (var numsprite in NumSprite)
                {
                    GameObject.Destroy(numsprite);
                }
            }

            //�\�����錅���������I�u�W�F�N�g�쐬
            NumSprite = new GameObject[strValue.Length];
            
            for (var i = 0; i < NumSprite.Length; ++i)
            {

                //�I�u�W�F�N�g�쐬
                GameObject obj = NumSprite[i] = new GameObject();
                
                obj.transform.position = transform.position + new Vector3((float)i * numWidth, 0);
                obj.transform.rotation = Quaternion.identity;
                Image img = obj.AddComponent<Image>();
                RectTransform rect = obj.GetComponent<RectTransform>();
                rect.sizeDelta = new Vector2(width, height);
                //obj.transform.DOScale(1.1f, 2.0f).SetEase(Ease.OutElastic);

                //�\�����鐔�l�̎w��
                NumSprite[i].GetComponent<Image>().sprite = Sprite_Dictionary[strValue[i].ToString()];

                //���M�̎q�K�w�Ɉړ�
                NumSprite[i].transform.SetParent(this.transform);
            }
        }


    }

}

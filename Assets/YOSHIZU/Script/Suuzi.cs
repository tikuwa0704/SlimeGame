using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suuzi : MonoBehaviour
{
    //�X�v���C�g�\���p�I�u�W�F�N�g(�v���n�u)
    [SerializeField] private GameObject Slime_Kazu;

    //�����X�v���C�g
    //0
    [SerializeField] private Sprite _0;
    //1
    [SerializeField] private Sprite _1;
    //2
    [SerializeField] private Sprite _2;
    //3
    [SerializeField] private Sprite _3;
    //4
    [SerializeField] private Sprite _4;
    //5
    [SerializeField] private Sprite _5;
    //6
    [SerializeField] private Sprite _6;
    //7
    [SerializeField] private Sprite _7;
    //8
    [SerializeField] private Sprite _8;
    //9
    [SerializeField] private Sprite _9;

    //�����̕\���Ԋu
    [SerializeField] float width;

    //�\������l
    private int Hyouzi_Kazu;

    //�\���p�X�v���C�g�I�u�W�F�N�g�̔z��
    private GameObject[] NumSprite;

    //�X�v���C�g�f�B�N�V���i��
    private Dictionary<char, Sprite> Sprite_Dictionary;

    //�X�v���C�g�f�B�N�V���i����������
    void Awake()
    {
        Sprite_Dictionary = new Dictionary<char, Sprite>()
        {
            { '0', _0 },
            { '1', _1 },
            { '2', _2 },
            { '3', _3 },
            { '4', _4 },
            { '5', _5 },
            { '6', _6 },
            { '7', _7 },
            { '8', _8 },
            { '9', _9 },
         };
     }

    //�\������l
    public int Hyouzi
    {
        get
        {
            return Hyouzi_Kazu;
        }

        set 
        {
            Hyouzi_Kazu = value;

            //�\��������̎擾
            string strHyouzi = value.ToString();

            //���ݕ\�����̃I�u�W�F�N�g���폜
            if (NumSprite != null)
            {
                foreach (var numsprite in NumSprite)
            }
        }


    }




    /*
    //�g�p����摜�̖���
    [SerializeField] private Sprite[] Kazu = new Sprite[10];

    int m_Hp;
    int No;
    int Kekka;

    // Update is called once per frame
    void Update()
    {
        SetHp();
    }

    public void ChangeSprite()
    {
        if (No > 9 || No < 0)
        {
            No = 0;
        }

        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Kazu[No];
    }

    void SetHp()
    {
        if (m_Hp > 100)
        {
            m_Hp = 100;
        }

        m_Hp = GetComponent<SlimeConcentration>().m_sticking_slime_num;

        string str = m_Hp.ToString();
        List<char> n = new List<char>();

        int keta = 0;

        for (int i = 0; i < No; i++)
        {
            if (keta <= No - str.Length - 1)
            {
                n.Add('0');
            }

            else
            {
                n.Add(str[i - (No - str.Length)]);
            }
            keta++;
        }
        n.Reverse();

    }
    */
}
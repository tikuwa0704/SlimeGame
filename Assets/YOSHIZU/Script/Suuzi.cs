using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suuzi : MonoBehaviour
{
    //Žg—p‚·‚é‰æ‘œ‚Ì–‡”
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
}

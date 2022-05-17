using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverText : MonoBehaviour
{
    [SerializeField] private GameObject Hukidasi;

    private string  overText = "ÇÕÇ¢ÅAÇ‚ÇËíºÇµww";
    private string[] Words;
    public Text textLabel;

    int C;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Dialogue());
    }

    IEnumerator Dialogue()
    {
        if (Hukidasi)
        {
            var hukidasi = Hukidasi.GetComponent<GameOverP2>();
            if (hukidasi.G_Over_Change)
            {
                if (C <= 10)
                {
                    C++;
                }
                if (C == 10)
                {
                    Words = overText.Split(' ');

                    foreach (var Wold in Words)
                    {
                        textLabel.text = textLabel.text + Wold;
                        yield return new WaitForSeconds(0.1f);
                    }
                }
                
            }
        }
    }
}

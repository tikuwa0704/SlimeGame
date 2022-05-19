using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneChange : MonoBehaviour
{

    [SerializeField]
    private Button continueButton;

    [SerializeField]
    private Button endButton;

    private void Awake()
    {

        continueButton.onClick.AddListener(Continue);

        endButton.onClick.AddListener(End);
    }

    void Continue()
    {
        SceneManager.LoadScene("GameScene");
    }

    void End()
    {
        SceneManager.LoadScene("OpeningScene");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{
    public GameObject Panel;
    public GameObject CheckPoint;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Panel.SetActive(true);
            Invoke("SceneGo", 3);
        }
        if (collision.gameObject.tag == "Syougaibutu")
        {
            Destroy(collision.gameObject);
        }
    }

    public void SceneGo()
    {
        SceneManager.LoadScene("OpeningScene");
    }
}

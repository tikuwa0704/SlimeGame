using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderKill : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            
            //チェックポイントに戻る
            ServiceLocator<IGameService>.Instance.CheckPoint();
            
        }
        if (other.CompareTag("Syougaibutu"))
        {

            Destroy(other.gameObject);

        }
    }

}

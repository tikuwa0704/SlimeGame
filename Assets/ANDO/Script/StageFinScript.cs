using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageFinScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.CompareTag("Player")&&ServiceLocator<IGameService>.Instance.IsState(E_GAME_MANAGER_STATE.EXE_STAGE1))
        {
            ServiceLocator<IGameService>.Instance.TransState(E_GAME_MANAGER_STATE.EXE_STAGE1);


        }
    }
}

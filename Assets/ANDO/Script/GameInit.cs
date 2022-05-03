using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ServiceLocator<IGameService>.Instance.TransState(E_GAME_MANAGER_STATE.BEGIN_STAGE1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

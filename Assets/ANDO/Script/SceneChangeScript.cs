using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeScript : MonoBehaviour
{
    
    public void SceneChange()
    {
        
        ServiceLocator<IUIService>.Instance.SetUIActive("シーンチェンジ", true);

        Debug.Log("通ってます");
    }
}

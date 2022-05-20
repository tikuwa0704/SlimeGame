using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    /*
    //X軸方向の加える風の力
    public float WindX = 0f;

    //Y軸方向の加える風の力
    public float WindY = 0f;

    //Z軸方向の加える風の力
    public float WindZ = 0f;
    */
    public float power = 0f;
    /// <summary>
    /// トリガーの範囲に入っている間ずっと実行される
    /// </summary>
    /// <param name="Other"></param>
    private void OnTriggerStay(Collider Other)
    {
        if (Other.gameObject.tag == "Player")
        {
            // 当たった相手のrigidbodyコンポーネントを取得
            Rigidbody OtherRigidbody = Other.GetComponent<Rigidbody>();
            // rigidbodyがnullではない場合（相手のGameObjectにrigidbodyが付いている場合）
            if (OtherRigidbody != null)
            {
                // 相手のrigidbodyに力を加える
                OtherRigidbody.AddForce(this.transform.forward * power * Time.deltaTime, ForceMode.Force);
            }
        }
      
    }
}

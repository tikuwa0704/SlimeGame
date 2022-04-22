using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeConcentration : MonoBehaviour
{
	[Header("子スライム群の親オブジェクト")]
	[SerializeField] public GameObject m_slime;

	[Header("子スライムをスライムコアに引っ張る力の大きさ")]
	[SerializeField] public float ConcentrationPower;

	[Header("引っ張られている子スライムの数")]
	[SerializeField] public int m_sticking_slime_num;

	[Header("子スライムを引っ張るスライムコアの範囲")]
	[SerializeField] public float m_together_rad;

	// Start is called before the first frame update
	void Start()
    {
		m_sticking_slime_num = 100;
    }

    // Update is called once per frame
    void Update()
    {
		
		SlimeTogetherLeave(m_slime);
    }

	void SlimeTogetherLeave(GameObject obj)
	{
		if (GetComponent<SlimeCoreController>().m_state == SlimeCoreController.SLIME_CORE_STATE.COLD) return;


			Transform children = obj.GetComponentInChildren<Transform>();
		//子要素がいなければ終了
		if (children.childCount == 0)
		{
			return;
		}
		//近くのスライムの数
		int _near_slime_num = 0;
		foreach (Transform ob in children)
		{
			

			Vector3 dir = this.transform.position - ob.position;
			SlimeContoroller slime_con = ob.gameObject.GetComponent<SlimeContoroller>();
				
			if (dir.magnitude <= m_together_rad)
			{
				slime_con.m_is_sticking = true;

				Rigidbody rb = ob.gameObject.GetComponent<Rigidbody>();
				rb.AddForce(dir.normalized * ConcentrationPower * Time.deltaTime);

				_near_slime_num++;
            }
            else
            {
				slime_con.m_is_sticking = false;
            }

		}

		m_sticking_slime_num = _near_slime_num;
	}
}

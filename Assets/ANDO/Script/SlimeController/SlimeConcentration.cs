using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeConcentration : MonoBehaviour
{
	
	[SerializeField]
	[Tooltip("子スライム群の親オブジェクト")]
	private GameObject m_slime_children;
	[SerializeField]
	[Tooltip("子スライムをスライムコアに引っ張る力の大きさ")]
	public float m_stick_power;
	[Tooltip("引っ張られている子スライムの数")]
	public int m_stick_num;
	[SerializeField] 
	[Tooltip("子スライムを引っ張るスライムコアの範囲")]
	private float m_stick_rad;

	// Start is called before the first frame update
	void Start()
    {
		m_stick_num = 100;
    }

    // Update is called once per frame
    void Update()
    {
		SlimeTogetherLeave(m_slime_children);
    }

	void SlimeTogetherLeave(GameObject obj)
	{
		if (SlimeManager.Instance.IsCurrentState(E_SLIMES_STATE.E_ICE)) return;
		//if (GetComponent<SlimeCoreController>().m_state == SlimeCoreController.SLIME_CORE_STATE.COLD) return;


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

            if (dir.magnitude <= 1) { slime_con.m_state = SlimeContoroller.E_SLIME_STATE.eIdle; }
			if (slime_con.m_state == SlimeContoroller.E_SLIME_STATE.eThrow) continue;

			if (dir.magnitude <= m_stick_rad)
			{
				slime_con.m_is_sticking = true;

				Rigidbody rb = ob.gameObject.GetComponent<Rigidbody>();
				rb.AddForce(dir.normalized * m_stick_power * Time.deltaTime);

				_near_slime_num++;
            }
            else
            {
				slime_con.m_is_sticking = false;
            }

		}

		m_stick_num = _near_slime_num;
	}
	
}

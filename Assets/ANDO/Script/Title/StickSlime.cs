using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickSlime : MonoBehaviour
{

	[SerializeField]
	[Tooltip("子スライム群の親オブジェクト")]
	private GameObject m_slime_children;
	[SerializeField]
	[Tooltip("子スライムをスライムコアに引っ張る力の大きさ")]
	public float m_stick_power;
	[Tooltip("引っ張られている子スライムの数")]
	public static int m_stick_num;
	[SerializeField]
	[Tooltip("子スライムを引っ張るスライムコアの範囲")]
	private float m_stick_rad;
	[SerializeField]
	[Tooltip("引っ張るかどうか")]
	public static bool m_is_stick;

	// Start is called before the first frame update
	void Start()
	{
		m_is_stick = false;
	}

	// Update is called once per frame
	void Update()
	{
		Transform children = m_slime_children.GetComponentInChildren<Transform>();
		m_stick_num = children.childCount;

		if(m_is_stick)StickSlimeChildren(m_slime_children);
	}

	void StickSlimeChildren(GameObject obj)
	{
		Transform children = obj.GetComponentInChildren<Transform>();
		//子要素がいなければ終了
		if (children.childCount == 0)
		{
			return;
		}
		foreach (Transform ob in children)
		{
			Vector3 dir = this.transform.position - ob.position;
			Rigidbody rb = ob.gameObject.GetComponent<Rigidbody>();
			rb.AddForce(dir.normalized * m_stick_power * Time.deltaTime);
		}
	}
}

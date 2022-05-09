using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickSlime : MonoBehaviour
{

	[SerializeField]
	[Tooltip("�q�X���C���Q�̐e�I�u�W�F�N�g")]
	private GameObject m_slime_children;
	[SerializeField]
	[Tooltip("�q�X���C�����X���C���R�A�Ɉ�������͂̑傫��")]
	public float m_stick_power;
	[Tooltip("���������Ă���q�X���C���̐�")]
	public static int m_stick_num;
	[SerializeField]
	[Tooltip("�q�X���C������������X���C���R�A�͈̔�")]
	private float m_stick_rad;
	[SerializeField]
	[Tooltip("�������邩�ǂ���")]
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
		//�q�v�f�����Ȃ���ΏI��
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

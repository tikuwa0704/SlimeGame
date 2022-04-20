using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeConcentration : MonoBehaviour
{
	[SerializeField] public GameObject m_slime;
	[SerializeField] public float ConcentrationPower;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		SlimeTogetherLeave(m_slime);
    }

	[SerializeField] public float m_together_rad;

	void SlimeTogetherLeave(GameObject obj)
	{
		Transform children = obj.GetComponentInChildren<Transform>();
		//éqóvëfÇ™Ç¢Ç»ÇØÇÍÇŒèIóπ
		if (children.childCount == 0)
		{
			return;
		}
		foreach (Transform ob in children)
		{
			Vector3 dir = this.transform.position - ob.position;
			if (dir.magnitude <= m_together_rad)
			{
				Rigidbody rb = ob.gameObject.GetComponent<Rigidbody>();
				rb.AddForce(dir.normalized * ConcentrationPower * Time.deltaTime);
				//ob.transform.position += dir.normalized * ConcentrationPower * Time.deltaTime;
			}

		}
	}
}

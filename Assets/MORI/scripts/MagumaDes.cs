using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagumaDes : MonoBehaviour
{
    public GameObject Maguma;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            GameObject maguma = (GameObject)Instantiate(Maguma, transform.position, Quaternion.identity);
        }
    }
}

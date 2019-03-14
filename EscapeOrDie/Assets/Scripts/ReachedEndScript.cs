using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachedEndScript : MonoBehaviour
{
    public GameObject m_Player;

    // Start is called before the first frame update
    void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnTriggerEnter(Collider other)
	{

		if(other.tag == "MazeEnd")
		{
            m_Player.GetComponent<PlayerScript>().KEY.enabled = true;
			Destroy(this.gameObject, 0);
		}		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboLockScript : MonoBehaviour
{
	
	public GameObject tumbler1;
	public GameObject tumbler2;
	public GameObject tumbler3;
	public GameObject player;
	public GameObject m_camera;
	public GameObject home;
	
	public float speed = 1;
	
	public Vector3 offset;
	
    void Start()
    {
	
       player = GameObject.FindGameObjectWithTag("Player");
	   m_camera = GameObject.FindGameObjectWithTag("MainCamera");//finds camera object
    }

    // Update is called once per frame
    void Update()
    {
		if(player.GetComponent<PlayerScript>().engaged2 == true){
			
//			transform.rotation = Quaternion.Lerp(transform.rotation, m_camera.transform.rotation, Time.time * speed);
			transform.position = Vector3.Lerp(transform.position, m_camera.transform.position + offset, Time.time * speed);
			offset = transform.forward * 0.25f;
			transform.rotation = new Quaternion(0.0f,0.0f,90.0f,0.0f);
		}
		else 
		{
			transform.rotation = new Quaternion(0.0f,90.0f,0.0f,0.0f);
			transform.position = home.transform.position;
		}
		
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
	public GameObject player;//player object
    
	public GameObject camera;
	
	public GameObject UI;
	
	public Vector3 offset;
	
	public float speed = 1;
	
	
	
	
    void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player");//finds player object
		camera = GameObject.FindGameObjectWithTag("MainCamera");//finds camera object
    }

    
    void Update()
    {
		transform.rotation = Quaternion.Lerp(transform.rotation, camera.transform.rotation, Time.time * speed);
		transform.position = Vector3.Lerp(transform.position, camera.transform.position + offset, Time.time * speed);
		offset = transform.forward * 0.5f;
		//lerps the canvas toward where the player is looking and pushes forward 0.5
		
			
	}
	
	
	
}

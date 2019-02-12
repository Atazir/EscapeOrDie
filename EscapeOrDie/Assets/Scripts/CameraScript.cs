using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
	public GameObject player;//player object
    
    void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player");//finds player object
    }

    
    void LateUpdate()
    {
        transform.position = player.transform.position;//moves camera with player object
		transform.rotation = player.transform.rotation;//rotates camera with player object
    }
}

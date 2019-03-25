using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboLockScript : MonoBehaviour
{
	
	public GameObject tumbler1;
	public GameObject tumbler2;
	public GameObject tumbler3;
	public GameObject player;
	
	
    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

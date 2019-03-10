using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPuzzleScript : MonoBehaviour
{
	public PlayerScript pScript;
	
    // Start is called before the first frame update
    void Start()
    {
        pScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
		if(pScript.engaged1 == true){
			if(Input.GetAxis("DpadLR") < 0)
			{
				transform.Rotate(-0.5f,0.0f,0.0f);
			}     
			if(Input.GetAxis("DpadLR") > 0)
			{
				transform.Rotate(0.5f,0.0f,0.0f);
			}
		}
    }
	
	
}

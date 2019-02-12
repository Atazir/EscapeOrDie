using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	
	public Rigidbody rb;//Rigidbody component
	
	public float speed;//players speed value
	
	public float rot;//rotation rate
	
	public bool nearTape;//check for if player is near the object
	
	public bool hasTape;//check for if player has picked up the tape
	
	public GameObject Tape;//Tape Object
	
	public bool nearTV;//check for if player is near TV
	
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();//gets the current objects rigidbody component
		
		Tape = GameObject.FindGameObjectWithTag("Tape");//finds and assigns the tape object
		
		nearTape = false;//default value is false
		hasTape = false;//default value is false
		nearTV = false;//defaul value is false
    }

	void FixedUpdate()
	{
		//movement handling start		
		if(Input.GetKey("w"))
		{
			transform.position += transform.forward * speed * Time.deltaTime;//moves player in the forward direction relative to their perspective
		}
		
		if(Input.GetKey("a"))
		{
			transform.position += transform.right * -speed * Time.deltaTime;//moves player in the left direction relative to their perspective
		}
		
		if(Input.GetKey("s"))
		{
			transform.position += transform.forward * -speed * Time.deltaTime;//moves player in the backward direction relative to their perspective
		}
		
		if(Input.GetKey("d"))
		{
			transform.position += transform.right * speed * Time.deltaTime;//moves player in the right direction relative to their perspective
		}

		
		if(Input.GetKey("right"))
		{
			transform.rotation *= Quaternion.Euler (0.0f, rot, 0.0f);//rotates the player clockwise 
		}
		
		if(Input.GetKey("left"))
		{
			transform.rotation *= Quaternion.Euler (0.0f, -rot, 0.0f);//rotates the player counterclockwise
		}		
		//movement handling end
		
		//object interaction start
		if(Input.GetKeyDown("e") && nearTape)
		{
			
			Tape.transform.position = this.transform.position;
			Tape.transform.position -= new Vector3(0.0f, 0.0f, 0.1f);//picks tape up
			
			Tape.transform.parent = this.transform;//makes it a child of the player so it inherits transforms
			
			hasTape = true;
			nearTape = false;//trigger setting
			
		}//picks up the tape when the player presses e near it and lets them walk around with it
		
		if(Input.GetKeyDown("r") && hasTape)
		{
			Tape.transform.parent = null;//removes Tape as child of player
			Tape.transform.position = new Vector3(Tape.transform.position.x, 0.0f, Tape.transform.position.z);//drops tape to floor

			hasTape = false;
			nearTape = true;//trigger setting
			
		}//drops the tap when the player presses r
		
		if(Input.GetKeyDown("e") && nearTV && hasTape)
		{
			Destroy(Tape,0);
			Debug.Log("Movie plays now");
		}//plays movie
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Tape")
		{
			nearTape = true;//updates nearTape variable to true while within area near the tape
		}
		else if (other.tag == "TapePlayer")
		{
			nearTV = true;//updates nearTV value to true when near tv
		}
		
	}
	
	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Tape")
		{
			nearTape = false;//updates nearTape value to false when player leaves area
		}
		else if (other.tag == "TapePlayer")
		{
			nearTV = false;//updates nearTV value to false when player leaves area
		}
		
	}
	
}

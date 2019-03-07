using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
	
	public Rigidbody rb;//Rigidbody component
	
	public float speed;//players speed value
	
	
	public bool nearTape;//check for if player is near the object
	
	public bool hasTape;//check for if player has picked up the tape
	
	public GameObject Tape;//Tape Object
	
	public GameObject Camera;//camera object
	
	public bool nearTV;//check for if player is near TV

    public Vector3 targetLocation;

    public Touch touch;

    public RawImage VHS;



    void Start()
    {
        rb = this.GetComponent<Rigidbody>();//gets the current objects rigidbody component
		
		Tape = GameObject.FindGameObjectWithTag("Tape");//finds and assigns the tape object
		
		Camera = GameObject.FindGameObjectWithTag("MainCamera");//finds and assigns camera object
		
		nearTape = false;//default value is false
		hasTape = false;//default value is false
		nearTV = false;//defaul value is false
    }

	void FixedUpdate()
	{
		var fingerCount = 0;
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
            {
                fingerCount++;
            }
        }
    
		//movement handling start		
		if(Input.GetKeyDown("w") || fingerCount == 1 /*|| ControllerD-PadUp*/)
		{
			Debug.Log("Yo" + Camera.transform.forward * speed);
            //transform.position += new Vector3(Camera.transform.forward.x,0.0f, Camera.transform.forward.z) * speed;//moves player in the forward direction relative to their perspective and isolatesou movement in the Y axis
            if (Physics.Raycast(transform.position, Camera.transform.TransformDirection(Vector3.forward),out RaycastHit hit, Mathf.Infinity))
            {
                if(hit.transform.tag == "Floor")
                {
                    targetLocation = hit.point;
                    targetLocation += new Vector3(0, transform.localScale.y / 2, 0);
                    transform.position = targetLocation;
                    Debug.Log("hit");
                }
                else
                {
                    Debug.Log(hit.transform.name);
                }
            }
		}

        //if(Input.GetKeyDown("w") || fingerCount == 1)
        //{
        //    if(Physics.Raycast(Camera.transform.position, Camera.transform.TransformDirection(Vector3.forward), out RaycastHit hit, Mathf.Infinity))
        //    {
        //        Debug.DrawRay(Camera.transform.position, Camera.transform.TransformDirection(Vector3.forward), Color.white, 30f, true);
        //
        //        //if(touch.phase == TouchPhase.Ended)
        //        //{
        //        //
        //        //}
        //    }
        //}

		//movement handling end
		
		//object interaction start
		if(Input.GetKey("e") || fingerCount == 2 /*|| ControllerActionKey*/&& nearTape)
		{
			Tape.GetComponent<Rigidbody>().useGravity = false;
			Tape.transform.position = this.transform.position;
			Tape.transform.position -= new Vector3(0.0f, 0.0f, 0.15f);//picks tape up
			
			Tape.transform.parent = this.transform;//makes it a child of the player so it inherits transforms
            VHS.enabled = true;
			
			hasTape = true;
			nearTape = false;//trigger setting
			
		}//picks up the tape when the player presses e near it and lets them walk around with it
		
		if(Input.GetKey("r") /*|| ControllerActionKey2*/&& hasTape)
		{
			Tape.transform.parent = null;//removes Tape as child of player
			//Tape.transform.position = new Vector3(Tape.transform.position.x, 0.0f, Tape.transform.position.z);//drops tape to floor
			Tape.GetComponent<Rigidbody>().useGravity = true;
			hasTape = false;
			nearTape = true;//trigger setting
			
		}//drops the tap when the player presses r
		
		if(Input.GetKey("e") || fingerCount == 2 /*|| ControllerActionKey*/ && nearTV && hasTape)
		{
			Destroy(Tape,0);
            VHS.enabled = false;
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

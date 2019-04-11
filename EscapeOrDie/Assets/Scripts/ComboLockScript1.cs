using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboLockScript1 : MonoBehaviour
{
	
	public GameObject tumbler1;
	public GameObject tumbler2;
	public GameObject tumbler3;
	public GameObject activeTumbler;
	public GameObject player;
	public GameObject m_camera;
	public GameObject home;
	public int tumblerNum1;
	public int tumblerNum2;
	public int tumblerNum3;
	
	public bool open = false;
	
	public bool moved = false;
	
	public bool axisVReset = true;
	public bool axisHReset = true;
	
	public GameObject Tape;
	public GameObject BoxDoor;
	
	public bool resetLock = false;
	
	public float speed = 1;
	
	public Vector3 offset;
	
    void Start(){
		tumblerNum1 = 1;
		tumblerNum2 = 1;
		tumblerNum3 = 1;
		
		Tape = GameObject.FindGameObjectWithTag("Tape");//finds and assigns the tape object
		BoxDoor = GameObject.FindGameObjectWithTag("BoxDoor");//finds and assigns the tape object
		
		activeTumbler = tumbler1;
		player = GameObject.FindGameObjectWithTag("Player");
		m_camera = GameObject.FindGameObjectWithTag("MainCamera");//finds camera object
    }

    // Update is called once per frame
    void Update(){			
		if(player.GetComponent<PlayerScript>().engaged4 == true){
			if(moved == false){
				transform.localScale = new Vector3(transform.localScale.x * 16, transform.localScale.y * 16, transform.localScale.z * 16);
				moved = true;
			}
			transform.rotation = Quaternion.Lerp(transform.rotation, m_camera.transform.rotation, Time.time * speed);
			transform.position = Vector3.Lerp(transform.position, m_camera.transform.position + offset, Time.time * speed);
			offset = transform.forward * 0.75f;
			transform.Rotate(0.0f,90.0f,90.0f);
			
			Interaction();
			
		}
		
		if (resetLock == true){
			transform.localScale = new Vector3(transform.localScale.x / 16, transform.localScale.y / 16, transform.localScale.z / 16);
			transform.rotation = home.transform.rotation;
			transform.Rotate(0.0f,90.0f,0.0f);
			transform.position = home.transform.position;
			resetLock = false;
			moved = false;
		}
		
    }
	
	void Interaction(){
		if(Input.GetAxis("DpadLR") < 0 && axisHReset == true || Input.GetKeyDown(KeyCode.LeftArrow))
        {
			switch (activeTumbler.name){
				case "Tumbler1":
					axisHReset = false;
					activeTumbler = tumbler3;
					break;
				case "Tumbler2":
					axisHReset = false;
					
					activeTumbler = tumbler1;

					break;
				case "Tumbler3":
					axisHReset = false;
					
					activeTumbler = tumbler2;

					break;	
			}
		}
		else if(Input.GetAxis("DpadLR") > 0 && axisHReset == true || Input.GetKeyDown(KeyCode.RightArrow))
        {
			switch (activeTumbler.name){
				case "Tumbler1":
					axisHReset = false;
					
					activeTumbler = tumbler2;

					break;
				case "Tumbler2":
					axisHReset = false;
					
					activeTumbler = tumbler3;

					break;
				case "Tumbler3":
					axisHReset = false;
					
					activeTumbler = tumbler1;

					break;	
			}
		}
		else if(Input.GetAxis("DpadUD") > 0 && axisVReset == true || Input.GetKeyDown(KeyCode.DownArrow))
        {
			switch (activeTumbler.name){
				case "Tumbler1":
					if(tumblerNum1 == 0)
						tumblerNum1 = 9;
					else
						tumblerNum1--;
					break;
				case "Tumbler2":
					if(tumblerNum2 == 0)
						tumblerNum2 = 9;
					else
						tumblerNum2--;
					break;
				case "Tumbler3":
					if(tumblerNum3 == 0)
						tumblerNum3 = 9;
					else
						tumblerNum3--;
					break;
			}
			activeTumbler.transform.Rotate(0.0f,36.0f,0.0f);
			axisVReset = false;
		}
		else if(Input.GetAxis("DpadUD") < 0 && axisVReset == true || Input.GetKeyDown(KeyCode.UpArrow))
        {
			switch (activeTumbler.name){
				case "Tumbler1":
					if(tumblerNum1 == 9)
						tumblerNum1 = 0;
					else
						tumblerNum1++;
					break;
				case "Tumbler2":
					if(tumblerNum2 == 9)
						tumblerNum2 = 0;
					else
						tumblerNum2++;
					break;
				case "Tumbler3":
					if(tumblerNum3 == 9)
						tumblerNum3 = 0;
					else
						tumblerNum3++;
					break;
			}
			activeTumbler.transform.Rotate(0.0f,-36.0f,0.0f);
			axisVReset = false;
		}
		else if(Input.GetButtonDown("Fire1")){
			Debug.Log(tumblerNum1);
			Debug.Log(tumblerNum2);
			Debug.Log(tumblerNum3);
			if(tumblerNum1 == 1 && tumblerNum2 == 2 && tumblerNum3 == 3){
					Debug.Log("Opens");
					open = true;
					Tape.GetComponent<BoxCollider>().enabled = true;
					BoxDoor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
				}
		}
		if(Input.GetAxis("DpadUD") == 0){
			axisVReset = true;
		}
		if(Input.GetAxis("DpadLR") == 0){
			axisHReset = true;
		}
		
		
	}
	
}

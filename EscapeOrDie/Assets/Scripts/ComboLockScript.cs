using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboLockScript : MonoBehaviour
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
	
	List<int> nums = new List<int>();
	
	public NumberRandomization randScript;
	
	public bool axisVReset = true;
	public bool axisHReset = true;
	
	public bool resetLock = false;
	
	public float speed = 1;
	
	public int j;
	
	public Vector3 offset;
    void Start(){
		randScript = GameObject.Find("NumberSpots").GetComponent<NumberRandomization>();
		tumblerNum1 = 1;
		tumblerNum2 = 1;
		tumblerNum3 = 1;
		
		
		tumbler1.GetComponent<Light>().enabled = false;
		tumbler2.GetComponent<Light>().enabled = false;
		tumbler3.GetComponent<Light>().enabled = false;
		activeTumbler = tumbler1;
		player = GameObject.FindGameObjectWithTag("Player");
		m_camera = GameObject.FindGameObjectWithTag("MainCamera");//finds camera object
    }

    // Update is called once per frame
    void Update(){	
		if(j<3){
			for(int i = 0; i < randScript.spots.Length; i++){
				
				if(randScript.spots[i] != null){
				
					
					switch(randScript.spots[i].GetComponent<Renderer>().material.ToString()){
						
						case "Number0 (Instance) (UnityEngine.Material)":
							nums.Add(0);
							j++;
							break;
						case "Number1 (Instance) (UnityEngine.Material)":
							nums.Add(1);
							j++;
							break;
						case "Number2 (Instance) (UnityEngine.Material)":
							nums.Add(2);
							j++;
							break;
						case "Number3 (Instance) (UnityEngine.Material)":
							nums.Add(3);
							j++;
							break;
						case "Number4 (Instance) (UnityEngine.Material)":
							nums.Add(4);
							j++;
							break;
						case "Number5 (Instance) (UnityEngine.Material)":
							nums.Add(5);
							j++;
							break;
						case "Number6 (Instance) (UnityEngine.Material)":
							nums.Add(6);
							j++;
							break;
						case "Number7 (Instance) (UnityEngine.Material)":
							nums.Add(7);
							j++;
							break;
						case "Number8 (Instance) (UnityEngine.Material)":
							nums.Add(8);
							j++;
							break;
						case "Number9 (Instance) (UnityEngine.Material)":
							nums.Add(9);
							j++;
							break;
						default:
						Debug.Log("Default");
						break;
					}
					
				}
			}
		}
		
		if(player.GetComponent<PlayerScript>().engaged2 == true){
			
			transform.rotation = Quaternion.Lerp(transform.rotation, m_camera.transform.rotation, Time.time * speed);
			transform.position = Vector3.Lerp(transform.position, m_camera.transform.position + offset, Time.time * speed);
			offset = transform.forward * 0.1f;
			transform.Rotate(0.0f,90.0f,90.0f);
			
			Interaction();
			
		}
		
		if (resetLock == true){
			transform.rotation = home.transform.rotation;
			transform.Rotate(0.0f,90.0f,0.0f);
			transform.position = home.transform.position;
			resetLock = false;
			activeTumbler.GetComponent<Light>().enabled = false;
		}
		
    }
	
	void Interaction(){
		activeTumbler.GetComponent<Light>().enabled = true;
		if(Input.GetAxis("DpadLR") < 0 && axisHReset == true){
			switch (activeTumbler.name){
				case "Tumbler1":
					axisHReset = false;
					activeTumbler.GetComponent<Light>().enabled = false;
					activeTumbler = tumbler3;
					activeTumbler.GetComponent<Light>().enabled = true;
					break;
				case "Tumbler2":
					axisHReset = false;
					activeTumbler.GetComponent<Light>().enabled = false;
					activeTumbler = tumbler1;
					activeTumbler.GetComponent<Light>().enabled = true;
					break;
				case "Tumbler3":
					axisHReset = false;
					activeTumbler.GetComponent<Light>().enabled = false;
					activeTumbler = tumbler2;
					activeTumbler.GetComponent<Light>().enabled = true;
					break;	
			}
		}
		else if(Input.GetAxis("DpadLR") > 0 && axisHReset == true){
			switch (activeTumbler.name){
				case "Tumbler1":
					axisHReset = false;
					activeTumbler.GetComponent<Light>().enabled = false;
					activeTumbler = tumbler2;
					activeTumbler.GetComponent<Light>().enabled = true;
					break;
				case "Tumbler2":
					axisHReset = false;
					activeTumbler.GetComponent<Light>().enabled = false;
					activeTumbler = tumbler3;
					activeTumbler.GetComponent<Light>().enabled = true;
					break;
				case "Tumbler3":
					axisHReset = false;
					activeTumbler.GetComponent<Light>().enabled = false;
					activeTumbler = tumbler1;
					activeTumbler.GetComponent<Light>().enabled = true;
					break;	
			}
		}
		else if(Input.GetAxis("DpadUD") < 0 && axisVReset == true){
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
		else if(Input.GetAxis("DpadUD") > 0 && axisVReset == true){
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
			if(tumblerNum1 == nums[0] && tumblerNum2 == nums[1] && tumblerNum3 == nums[2]){
				Debug.Log("Opens");
				open = true;
				player.GetComponent<PlayerScript>().HasKey2 = true;
				player.GetComponent<PlayerScript>().KEY2.enabled = true;
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

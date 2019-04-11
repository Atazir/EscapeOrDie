using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
	public LayerMask uI;
	
	public ComboLockScript lockScript1;
	public ComboLockScript1 lockScript2;
	
	public Rigidbody rb;//Rigidbody component
	
	public float speed;//players speed value
	
	public bool nearTape;//check for if player is near the object
	
	public bool hasTape;//check for if player has picked up the tape
	
	public GameObject Tape;//Tape Object
	
	public GameObject Camera;//camera object
	
	public GameObject Reticle;
	
	public bool nearTV;//check for if player is near TV

    public GameObject StartAudio;

    public Vector3 targetLocation;
	
	public GameObject UI;

	public bool run = true;
	
    public RawImage VHS;
    public RawImage KEY1;
    public RawImage KEY2;
	public RawImage Code1;
	public RawImage Code2;
	public RawImage Code3;

	public GameObject Target1;
	public GameObject Target2;
	public GameObject Target3;
	
	public float targetNum1;
	public float targetNum2;
	public float targetNum3;
	public int curNum;
	
	public bool HasKey1 = false;
	public bool HasKey2 = false;
	
	public bool hasCode = false;
	
	public float Cooldown  = 0.25f;//cooldown for screen fade
	
	public float Timer;
	
	private int layerMask = -1;

	public bool open = false;
	
	public bool started = false;
	
	public bool engaged = false;
	public bool engaged1 = false;
	public bool engaged2 = false;
	public bool engaged3 = false;
	public bool engaged4 = false;

    public bool canMove = true;
	
	public GameObject currentObj;
	
	public List<Material> mats = new List<Material>();
	
    void Start()
    {
		targetNum1 = -1;
		targetNum2 = -1;
		targetNum3 = -1;
		lockScript1 = GameObject.Find("/Room2/locker_01b/Padlock/Cube").GetComponent<ComboLockScript>();
		lockScript2 = GameObject.Find("/Room1/BoxParent/Padlock/Cube").GetComponent<ComboLockScript1>();
		
		Reticle = GameObject.Find("GvrReticlePointer");
		
		UI.SetActive(false);
		
        rb = this.GetComponent<Rigidbody>();//gets the current objects rigidbody component
		
		Tape = GameObject.FindGameObjectWithTag("Tape");//finds and assigns the tape object
		Tape.GetComponent<BoxCollider>().enabled = false;
		
		Camera = GameObject.FindGameObjectWithTag("MainCamera");//finds and assigns camera object
		
		nearTape = false;//default value is false
		hasTape = false;//default value is false
		nearTV = false;//defaul value is false
		
		VHS.enabled = false; // initial set for VHS UI Element to be off
        KEY1.enabled = false;
        KEY2.enabled = false;
    }

	void FixedUpdate()
	{
		if(Input.GetButtonDown("Jump")){
			
			switch (open)
			{
				case true:
					CloseMenu();
					break;
				case false:
					OpenMenu();
					break;
			}
			
			
		}//open/close the menu
			if(Physics.Raycast(transform.position, Camera.transform.TransformDirection(Vector3.forward),out RaycastHit hit2, 2)){
				switch(hit2.transform.tag)
					{
						case "Floor":
							Reticle.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
							break;
						case "CanMove":
						case "Padlock":
						case "PadlockStart":
						case "TapePlayer":
						case "GravityMazePuzzle":
						case "Room1Door":
						case "ExitDoor":
						case "Safe":
							Reticle.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
							break;
						case "Button":
							if(hasCode){
								Reticle.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
							}
							else{
								Reticle.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
							}
							break;
						default:
							Reticle.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
							break;
						
					}
					
			}
			else{Reticle.GetComponent<Renderer>().material.SetColor("_Color", Color.white);}
		//movement handling start		
		if(Input.GetButtonDown("Fire3") && canMove)
		{
            if (Physics.Raycast(transform.position, Camera.transform.TransformDirection(Vector3.forward),out RaycastHit hit, 2, layerMask , QueryTriggerInteraction.Ignore))
            {
                if(hit.transform.tag == "Floor"){
					transform.GetComponent<AudioSource>().Play();
					Camera.GetComponent<Camera>().cullingMask = 0;//Fades screen to black
					Timer = Time.deltaTime;//Teleport starts
                    targetLocation = hit.point;
                    targetLocation += new Vector3(0, transform.localScale.y / 2, 0);
                    transform.position = new Vector3(targetLocation.x, transform.position.y, targetLocation.z);
					
                }
            }
		}
		Timer += Time.deltaTime;//updates the time
		if(Cooldown * 8 < Timer){
			transform.GetComponent<AudioSource>().Pause();
		}
		if(Cooldown < Timer)
		{
			Camera.GetComponent<Camera>().cullingMask = -1;
		}//checks time 
		//movement handling end
		
		//object interaction start
		
		if (Input.GetButtonDown("Fire1"))
        {	
			Physics.Raycast(transform.position, Camera.transform.TransformDirection(Vector3.forward),out RaycastHit hit1, 2);
			
			
			
			
				switch(hit1.transform.tag)
				{
				case "Tape" :
					Tape.SetActive(false);
					VHS.enabled = true;
					hasTape = true;
					nearTape = false;//trigger setting
					break;

				case "TapePlayer":
                    if(VHS.enabled == true)
                    {
                        Destroy(Tape, 0);
                        VHS.enabled = false;
                        started = true;
                        Debug.Log("Movie plays now");
                        //Insert VHS Audio here
                        StartAudio.GetComponent<AudioSource>().Play();
                    }
                    break;
				case "GravityMazePuzzle":
					engaged1 = true;
					canMove = false;
					Reticle.SetActive(false);
					break;
				case "CanMove":
					engaged3 = true;
					canMove = false;
					currentObj = GameObject.Find(hit1.transform.name);
					Reticle.SetActive(false);
					break;
				case "Padlock":
					engaged2 = true;
					canMove = false;
					Reticle.SetActive(false);
					break;
				case "PadlockStart":
					engaged4 = true;
					canMove = false;
					Reticle.SetActive(false);
					break;
				case "Room1Door":
					if(started == true){
						Camera.GetComponent<Camera>().cullingMask = 0;//Fades screen to black
						Timer = Time.deltaTime;//Teleport starts
						transform.position = new Vector3(-8.0f,1.1f,0.0f);
					}
					break;
				case "Safe":
					if(HasKey1 == true && HasKey2 == true){
						hasCode = true;
						Code1.enabled = true;
						Code2.enabled = true;
						Code3.enabled = true;
						hit1.transform.GetComponent<AudioSource>().Play();
					}
					break;
                case "Button":
					ButtonThings(hit1.transform.name);
					if(hasCode)hit1.transform.GetComponent<AudioSource>().Play();
                    break;
				
				default:
					break;
				}
			
		}
		if(Input.GetButtonDown("Cancel"))
		{
			if(engaged == false){
				canMove = true;
			}
			if(engaged3 == true){
				engaged3 = false;
				currentObj.GetComponent<Rigidbody>().useGravity = true;
				currentObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			}
			if(engaged2 == true){
				engaged2 = false;	
				lockScript1.resetLock = true;
			}
			if(engaged4 == true){
				engaged4 = false;	
				lockScript2.resetLock = true;
			}
			
			engaged1 = false;
			Reticle.SetActive(true);
			
			
		}
		
		if(engaged3 == true){
			currentObj.GetComponent<Rigidbody>().useGravity = false;
			currentObj.GetComponent<Rigidbody>().velocity = new Vector3(0.0f,0.0f,0.0f);
			if(Input.GetAxis("DpadLR") < 0)
			{
				currentObj.transform.Translate(Vector3.left * Time.deltaTime/2.5f);
			}     
			if(Input.GetAxis("DpadLR") > 0)
			{
				currentObj.transform.Translate(-Vector3.left * Time.deltaTime/2.5f);
			}
			if(Input.GetAxis("DpadUD") < 0){
				currentObj.transform.Translate(Vector3.up * Time.deltaTime/2.5f);
			}
			if(Input.GetAxis("DpadUD") > 0){
				currentObj.transform.Translate(-Vector3.up * Time.deltaTime/2.5f);
			}
			if(Input.GetAxis("RSUD") < 0){
				currentObj.transform.Translate(Vector3.forward * Time.deltaTime/2.5f);
			}
			if(Input.GetAxis("RSUD") > 0){
				currentObj.transform.Translate(-Vector3.forward * Time.deltaTime/2.5f);
			}
			if(Input.GetAxis("DpadLR") == 0 && Input.GetAxis("DpadUD") == 0 && Input.GetAxis("RSUD") == 0){
			currentObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
			}
			else{
			currentObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			}
			
		}
		
	}
		
	public void OpenMenu()
	{
		open = true;
		engaged = true;
		canMove = false;
		UI.SetActive(true);
	}//open menu function
	
	public void CloseMenu()
	{
		UI.SetActive(false);
		engaged = false;
		canMove = true;
		open = false;
	}//close menu function
	
	public void ButtonThings(string Name){
		if(hasCode == true){
			switch(Name){
				case "Cube0":
					curNum = 0;
					break;
				case "Cube1":
					curNum = 1;
					break;
				case "Cube2":
					curNum = 2;
					break;
				case "Cube3":
					curNum = 3;
					break;
				case "Cube4":
					curNum = 4;
					break;
				case "Cube5":
					curNum = 5;
					break;
				case "Cube6":
					curNum = 6;
					break;
				case "Cube7":
					curNum = 7;
					break;
				case "Cube8":
					curNum = 8;
					break;
				case "Cube9":
					curNum = 9;
					break;
				case "CubeC":
					if(targetNum1 == 6 && targetNum2 == 3 && targetNum3 == 9){
						SceneManager.LoadScene(3);
					}
					break;
				case "CubeX":
					targetNum1 = -1;
					targetNum2 = -1;
					targetNum3 = -1;
					Target1.GetComponent<Renderer>().material = mats[10];
					Target2.GetComponent<Renderer>().material = mats[10];
					Target3.GetComponent<Renderer>().material = mats[10];
					run = false;
					break;
			}
			if(run){
				if(targetNum1 == -1){
					Target1.GetComponent<Renderer>().material = mats[curNum];
					targetNum1 = curNum;
				}
				else if(targetNum2 == -1){
					Target2.GetComponent<Renderer>().material = mats[curNum];
					targetNum2 = curNum;
				}
				else if(targetNum3 == -1){
					Target3.GetComponent<Renderer>().material = mats[curNum];
					targetNum3 = curNum;
				}
			}
			else run = true;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
	public ComboLockScript lockScript;
	
	public Rigidbody rb;//Rigidbody component
	
	public float speed;//players speed value
	
	public bool nearTape;//check for if player is near the object
	
	public bool hasTape;//check for if player has picked up the tape
	
	public GameObject Tape;//Tape Object
	
	public GameObject Camera;//camera object
	
	public GameObject Reticle;
	
	public bool nearTV;//check for if player is near TV

    public Vector3 targetLocation;
	
	public GameObject UI;

    public RawImage VHS;
    public RawImage KEY;

	public float Cooldown  = 0.25f;//cooldown for screen fade
	
	public float Timer;
	
	private int layerMask = -1;

	public bool open = false;
	
	public bool started = false;
	
	public bool engaged = false;
	public bool engaged1 = false;
	public bool engaged2 = false;

    public bool canMove = true;
	
    void Start()
    {
		lockScript = GameObject.Find("/Padlock/Cube").GetComponent<ComboLockScript>();
		
		Reticle = GameObject.Find("GvrReticlePointer");
		
		UI.SetActive(false);
		
        rb = this.GetComponent<Rigidbody>();//gets the current objects rigidbody component
		
		Tape = GameObject.FindGameObjectWithTag("Tape");//finds and assigns the tape object
		
		Camera = GameObject.FindGameObjectWithTag("MainCamera");//finds and assigns camera object
		
		nearTape = false;//default value is false
		hasTape = false;//default value is false
		nearTV = false;//defaul value is false
		
		VHS.enabled = false; // initial set for VHS UI Element to be off
        KEY.enabled = false;
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
	
		//movement handling start		
		if(Input.GetButtonDown("Fire3") && canMove)
		{
            if (Physics.Raycast(transform.position, Camera.transform.TransformDirection(Vector3.forward),out RaycastHit hit, Mathf.Infinity, layerMask , QueryTriggerInteraction.Ignore))
            {
                if(hit.transform.tag == "Floor")
                {	Camera.GetComponent<Camera>().cullingMask = 0;//Fades screen to black
					Timer = Time.deltaTime;//Teleport starts
                    targetLocation = hit.point;
                    targetLocation += new Vector3(0, transform.localScale.y / 2, 0);
                    transform.position = new Vector3(targetLocation.x, transform.position.y, targetLocation.z);
					
                }
            }
		}
		Timer += Time.deltaTime;//updates the time
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
					Destroy(Tape,0);
					VHS.enabled = false;
					started = true;
					Debug.Log("Movie plays now");
					break;

				case "GravityMazePuzzle":
					engaged1 = true;
					canMove = false;
					break;

				case "Padlock":
					engaged2 = true;
					canMove = false;
					Reticle.SetActive(false);
					break;
				
                case "ExitDoor":
                    if(started == true && KEY.enabled == true)
                    {
                        UI.GetComponent<UIScript>().timerText.text = "YOU WIN";
                        SceneManager.LoadScene("Win Screen");                
                    }

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
			if(engaged2 == true){
				engaged2 = false;	
				Reticle.SetActive(true);
				lockScript.resetLock = true;
			}
			engaged1 = false;
			
			
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
	
}

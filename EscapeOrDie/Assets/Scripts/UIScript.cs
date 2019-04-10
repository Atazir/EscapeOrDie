using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
	public GameObject player;//player object
    
	public GameObject m_camera;
	
	public GameObject UI;
	
	public Vector3 offset;
	
	public float speed = 1;

    public Text timerText;
    public float timer = 600.0f; //10 minutes on the clock on run time

    public RawImage code1;
    public RawImage code2;
    public RawImage code3;
	
    void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player");//finds player object
        m_camera = GameObject.FindGameObjectWithTag("MainCamera");//finds camera object

        timerText.text = timer.ToString();

        code1.enabled = false;
        code2.enabled = false;
        code3.enabled = false;
    }
 
    void Update()
    {
		transform.rotation = Quaternion.Lerp(transform.rotation, m_camera.transform.rotation, Time.time * speed);
		transform.position = Vector3.Lerp(transform.position, m_camera.transform.position + offset, Time.time * speed);
		offset = transform.forward * 1.5f;
        //lerps the canvas toward where the player is looking and pushes forward 0.5
		if(player.GetComponent<PlayerScript>().started == true){
			timerText.text = timer.ToString();
			timer -= Time.deltaTime;
		}
        if (timer < 0)
        {
            timerText.text = "00:00";
            GameOver();
        }
	}

    public void GameOver()
    {
        player.GetComponent<PlayerScript>().canMove = false;
        timerText.text = "GAME OVER";
        SceneManager.LoadScene(2);
    }
	
	
	
}

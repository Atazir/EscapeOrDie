using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Playsound : MonoBehaviour 
{
    public List<AudioClip> myAudioList = new List<AudioClip>();

    public void Start()
    {
        //Add all the button sounds to the list
        myAudioList.Add((AudioClip)Resources.Load("Audio/DTMF/0")); //0
        myAudioList.Add((AudioClip)Resources.Load("Audio/DTMF/1")); //1
        myAudioList.Add((AudioClip)Resources.Load("Audio/DTMF/2")); //2
        myAudioList.Add((AudioClip)Resources.Load("Audio/DTMF/3")); //3
        myAudioList.Add((AudioClip)Resources.Load("Audio/DTMF/4")); //4
        myAudioList.Add((AudioClip)Resources.Load("Audio/DTMF/5")); //5
        myAudioList.Add((AudioClip)Resources.Load("Audio/DTMF/6")); //6
        myAudioList.Add((AudioClip)Resources.Load("Audio/DTMF/7")); //7
        myAudioList.Add((AudioClip)Resources.Load("Audio/DTMF/8")); //8
        myAudioList.Add((AudioClip)Resources.Load("Audio/DTMF/9")); //9
        myAudioList.Add((AudioClip)Resources.Load("Audio/DTMF/Confirm")); //Confirm + 10
        myAudioList.Add((AudioClip)Resources.Load("Audio/DTMF/Cancel")); //Cancel + 11
        
    }

    public void Clicky ()
    {
		//GetComponent<AudioSource>().Play();

        switch(this.name)
        {
            case "Button0":
                transform.GetComponent<AudioSource>().clip = myAudioList[0];
                transform.GetComponent<AudioSource>().Play();
                break;

            case "Button1":
                transform.GetComponent<AudioSource>().clip = myAudioList[1];
                transform.GetComponent<AudioSource>().Play();
                break;

            case "Button2":
                transform.GetComponent<AudioSource>().clip = myAudioList[2];
                transform.GetComponent<AudioSource>().Play();
                break;

            case "Button3":
                transform.GetComponent<AudioSource>().clip = myAudioList[3];
                transform.GetComponent<AudioSource>().Play();
                break;

            case "Button4":
                transform.GetComponent<AudioSource>().clip = myAudioList[4];
                transform.GetComponent<AudioSource>().Play();
                break;

            case "Button5":
                transform.GetComponent<AudioSource>().clip = myAudioList[5];
                transform.GetComponent<AudioSource>().Play();
                break;

            case "Button6":
                transform.GetComponent<AudioSource>().clip = myAudioList[6];
                transform.GetComponent<AudioSource>().Play();
                break;

            case "Button7":
                transform.GetComponent<AudioSource>().clip = myAudioList[7];
                transform.GetComponent<AudioSource>().Play();
                break;

            case "Button8":
                transform.GetComponent<AudioSource>().clip = myAudioList[8];
                transform.GetComponent<AudioSource>().Play();
                break;

            case "Button9":
                transform.GetComponent<AudioSource>().clip = myAudioList[9];
                transform.GetComponent<AudioSource>().Play();
                break;

            case "Confirm":
                transform.GetComponent<AudioSource>().clip = myAudioList[10];
                transform.GetComponent<AudioSource>().Play();
                break;

            case "Cancel":
                transform.GetComponent<AudioSource>().clip = myAudioList[11];
                transform.GetComponent<AudioSource>().Play();
                break;
        }
	}


}

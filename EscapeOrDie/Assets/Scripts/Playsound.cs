using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Playsound : MonoBehaviour 
{
    public List<AudioClip> myAudioList = new List<AudioClip>();

    public RawImage slot1;
    public RawImage slot2;
    public RawImage slot3;

    public List<int> answerSheet = new List<int>();

    public List<int> playerAnswers = new List<int>();

    public void Start()
    {
        //Add all the button sounds to the list
        myAudioList.Add(Resources.Load<AudioClip>("Assets/0")); //0
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

        answerSheet.Add(6);
        answerSheet.Add(3);
        answerSheet.Add(9);
    }

    public void Update()
    {
        if(playerAnswers.Count >= 4)
        {
            Cancel();
        }
    }

    public void Clicky (string Name)
    {Debug.Log("Ding");
        switch(Name)
        {
            case "Button0":
                transform.GetComponent<AudioSource>().clip = myAudioList[0];
                transform.GetComponent<AudioSource>().Play();
                if(slot1.texture == null)
                {
                    slot1 = Resources.Load<RawImage>("Textures/Number0");
                }
                else if(slot2.texture == null)
                {
                    slot2 = Resources.Load<RawImage>("Textures/Number0");
                }
                else
                {
                    slot3 = Resources.Load<RawImage>("Textures/Number0");
                }
                playerAnswers.Add(0);
                break;

            case "Button1":
                transform.GetComponent<AudioSource>().clip = myAudioList[1];
                transform.GetComponent<AudioSource>().Play();
                if (slot1.texture == null)
                {
                    slot1 = Resources.Load<RawImage>("Textures/Number1");
                }
                else if (slot2.texture == null)
                {
                    slot2 = Resources.Load<RawImage>("Textures/Number1");
                }
                else
                {
                    slot3 = Resources.Load<RawImage>("Textures/Number1");
                }
                playerAnswers.Add(1);
                break;

            case "Button2":
                transform.GetComponent<AudioSource>().clip = myAudioList[2];
                transform.GetComponent<AudioSource>().Play();
                if (slot1.texture == null)
                {
                    slot1 = Resources.Load<RawImage>("Textures/Number2");
                }
                else if (slot2.texture == null)
                {
                    slot2 = Resources.Load<RawImage>("Textures/Number2");
                }
                else
                {
                    slot3 = Resources.Load<RawImage>("Textures/Number2");
                }
                playerAnswers.Add(2);
                break;

            case "Button3":
                transform.GetComponent<AudioSource>().clip = myAudioList[3];
                transform.GetComponent<AudioSource>().Play();
                if (slot1.texture == null)
                {
                    slot1 = Resources.Load<RawImage>("Textures/Number3");
                }
                else if (slot2.texture == null)
                {
                    slot2 = Resources.Load<RawImage>("Textures/Number3");
                }
                else
                {
                    slot3 = Resources.Load<RawImage>("Textures/Number3");
                }
                playerAnswers.Add(3);
                break;

            case "Button4":
                transform.GetComponent<AudioSource>().clip = myAudioList[4];
                transform.GetComponent<AudioSource>().Play();
                if (slot1.texture == null)
                {
                    slot1 = Resources.Load<RawImage>("Textures/Number4");
                }
                else if (slot2.texture == null)
                {
                    slot2 = Resources.Load<RawImage>("Textures/Number4");
                }
                else
                {
                    slot3 = Resources.Load<RawImage>("Textures/Number4");
                }
                playerAnswers.Add(4);
                break;

            case "Button5":
                transform.GetComponent<AudioSource>().clip = myAudioList[5];
                transform.GetComponent<AudioSource>().Play();
                if (slot1.texture == null)
                {
                    slot1 = Resources.Load<RawImage>("Textures/Number5");
                }
                else if (slot2.texture == null)
                {
                    slot2 = Resources.Load<RawImage>("Textures/Number5");
                }
                else
                {
                    slot3 = Resources.Load<RawImage>("Textures/Number5");
                }
                playerAnswers.Add(5);
                break;

            case "Button6":
                transform.GetComponent<AudioSource>().clip = myAudioList[6];
                transform.GetComponent<AudioSource>().Play();
                if (slot1 == null)
                {
                    slot1 = Resources.Load<RawImage>("Textures/Number6");
                }
                else if (slot2 == null)
                {
                    slot2 = Resources.Load<RawImage>("Textures/Number6");
                }
                else
                {
                    slot3 = Resources.Load<RawImage>("Textures/Number6");
                }
                playerAnswers.Add(6);
                break;

            case "Button7":
                transform.GetComponent<AudioSource>().clip = myAudioList[7];
                transform.GetComponent<AudioSource>().Play();
                if (slot1 == null)
                {
                    slot1 = Resources.Load<RawImage>("Textures/Number7");
                }
                else if (slot2 == null)
                {
                    slot2 = Resources.Load<RawImage>("Textures/Number7");
                }
                else
                {
                    slot3 = Resources.Load<RawImage>("Textures/Number7");
                }
                playerAnswers.Add(7);
                break;

            case "Button8":
                transform.GetComponent<AudioSource>().clip = myAudioList[8];
                transform.GetComponent<AudioSource>().Play();
                if (slot1.texture == null)
                {
                    slot1 = Resources.Load<RawImage>("Textures/Number8");
                }
                else if (slot2.texture == null)
                {
                    slot2 = Resources.Load<RawImage>("Textures/Number8");
                }
                else
                {
                    slot3 = Resources.Load<RawImage>("Textures/Number8");
                }
                playerAnswers.Add(8);
                break;

            case "Button9":
                transform.GetComponent<AudioSource>().clip = myAudioList[9];
                transform.GetComponent<AudioSource>().Play();
                if (slot1.texture == null)
                {
                    slot1 = Resources.Load<RawImage>("Textures/Number9");
                }
                else if (slot2.texture == null)
                {
                    slot2 = Resources.Load<RawImage>("Textures/Number9");
                }
                else
                {
                    slot3 = Resources.Load<RawImage>("Textures/Number9");
                }
                playerAnswers.Add(9);
                break;

            case "Confirm":
                transform.GetComponent<AudioSource>().clip = myAudioList[10];
                transform.GetComponent<AudioSource>().Play();
                Confirm();
                break;

            case "Cancel":
                transform.GetComponent<AudioSource>().clip = myAudioList[11];
                transform.GetComponent<AudioSource>().Play();
                Cancel();
                break;
        }


	}

    public void Confirm()
    {
        //if code is the same as the answer load next scene
        if(playerAnswers[0] == answerSheet[0] && playerAnswers[1] == answerSheet[1] && playerAnswers[2] == answerSheet[2])
        {
            SceneManager.LoadScene("Win Screen");
        }
        else
        {
            Cancel();
        }
    }

    public void Cancel()
    {
        slot1 = null;
        slot2 = null;
        slot3 = null;

        playerAnswers = null;
    }
}

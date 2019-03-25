using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberRandomization : MonoBehaviour
{
	public GameObject[] spots;
	public Material[] mats;
	ArrayList newSpots = new ArrayList();
	public int randNum;
	
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < spots.Length; i++){
			
			newSpots.Add(spots[i]);
			
		}
		DoTheThing();
    }

    // Update is called once per frame
    void Update()
    {
    }
	
	void DoTheThing(){
		while(newSpots.Count > 3){
		randNum = Random.Range(0,newSpots.Count);
		newSpots.RemoveAt(randNum);
		}
	
		for(int i = 0; i < spots.Length; i++){
			if(spots[i].ToString() != newSpots[0].ToString() && spots[i].ToString() != newSpots[1].ToString() && spots[i].ToString() != newSpots[2].ToString()){
				Destroy(spots[i],0);
			}
			
		}
		for(int i = 0; i < spots.Length; i++){
			randNum = Random.Range(0,10);
			spots[i].GetComponent<Renderer>().material = mats[randNum];
		}
	}
	
}

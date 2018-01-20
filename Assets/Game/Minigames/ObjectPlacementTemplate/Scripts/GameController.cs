using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {


	string[] tagArray =new string[2];
	Vector2 objPos=new Vector2();
	GameObject[] objArray=new GameObject[2];

    public RectTransform ScrollViewRoot;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
/*		if (objArray [1].GetComponent<TargetScript> ().GetFlag() == 1) {
			if (tagArray [1] == tagArray [0]) {
				objPos = objArray [1].transform.position;
				objArray [0].transform.position = objPos;
			}
		}*/
	}

	public void SetTagArray(int i,string objTag)
	{

		tagArray [i] = objTag;
	}

	public void SetObjArray (int i, GameObject obj)
	{
		objArray[i]=obj;
	}
}

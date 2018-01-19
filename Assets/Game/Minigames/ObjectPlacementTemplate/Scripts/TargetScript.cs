using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour {
	public GameObject gameManager;
	int flag;
	// Use this for initialization
	void Start () {
		flag = 0;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown()
	{
		gameManager.GetComponent<GameController> ().SetTagArray (1, this.gameObject.tag);
		gameManager.GetComponent<GameController> ().SetObjArray (1, this.gameObject);
		flag = 1;
	}

	public int GetFlag()
	{
		return flag;
	}
}

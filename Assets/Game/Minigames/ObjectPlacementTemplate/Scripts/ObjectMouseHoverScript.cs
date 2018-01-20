using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMouseHoverScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseEnter()
	{
		gameObject.GetComponent<SpriteRenderer> ().enabled = true;
	}
	void OnMouseExit()
	{
		gameObject.GetComponent<SpriteRenderer> ().enabled = false;
	}

}

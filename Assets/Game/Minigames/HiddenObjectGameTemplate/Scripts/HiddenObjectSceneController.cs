using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiddenObjectSceneController : MonoBehaviour {

	private GameObject[] validArr;
	int n ;

	[SerializeField]private Text leftText;
	[SerializeField]private Text middleText;
	[SerializeField]private Text rightText;

	// Use this for initialization
	void Start () {
		n = 0;



		validArr = GameObject.FindGameObjectsWithTag ("valid");
		ArrUpdate (n);

	

	}
	
	// Update is called once per frame
	void Update () {
		if (n < validArr.Length - 3) {
			if (validArr [n] == null && validArr [n + 1] == null && validArr [n + 2] == null) {
				n = n + 3;
				ArrUpdate (n);
			}
		}

		if (validArr [n] == null) {
			leftText.color = Color.black;
		}

		if (validArr [n+1] == null) {
			middleText.color = Color.black;
		}

		if (validArr [n+2] == null) {
			rightText.color = Color.black;
		}

	}

	void ArrUpdate(int n)
	{
		leftText.text = validArr [n].gameObject.name;
		middleText.text = validArr [n + 1].gameObject.name;
		rightText.text = validArr [n + 2].gameObject.name;
		leftText.color = Color.red;
		rightText.color = Color.red;
		middleText.color = Color.red;
		for (int i = n; i < n + 3; i++) {
			validArr [i].gameObject.GetComponent<ValidObjectsScript> ().enabled = true;

		}
	}


}

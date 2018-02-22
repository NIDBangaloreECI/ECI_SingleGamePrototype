using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour {

    private int mWrongClickCount;
    
	// Use this for initialization
	void Start () {
        mWrongClickCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (mWrongClickCount == 3)
        {
            this.GetComponent<CountdownTimerScript>().setTimeLeft(5);
            mWrongClickCount = 0;
        
        }
	}

    public void setWrongClickCount(int clickIndex)
    {
        mWrongClickCount += clickIndex;
    }
}

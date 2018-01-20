using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintPlayPause : MonoBehaviour {
    public GameObject panel;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Pause()
    {

        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            panel.SetActive(true);
            


        }

    }

    public void Play()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            panel.SetActive(false);
           
        }
    }
}

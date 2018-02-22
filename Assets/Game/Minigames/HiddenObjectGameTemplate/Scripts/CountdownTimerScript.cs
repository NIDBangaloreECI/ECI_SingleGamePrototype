using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimerScript : MonoBehaviour {

	public float timeLeft = 60;
	float min;
	float sec;

	public Text cdTimer;

	void Start()
	{
		
	}


	void Update()
	{
			
		timeLeft -= Time.deltaTime;
		min =Mathf.Floor(timeLeft / 60);
		sec =Mathf.Floor(timeLeft % 60);
		if (sec >= 10) {
			cdTimer.text = "0" + min.ToString () + ":" + sec.ToString ();
		} else {
			cdTimer.text = "0" + min.ToString () + ":" +"0"+ sec.ToString ();
		}
			
		if(timeLeft <1)
		{
            Invoke("SceneLoader", 0.9f);
		}
	}

	public void setTimeLeft(int n)
	{
		timeLeft = timeLeft - n;
	}

    void SceneLoader()
    {
        SceneManager.LoadScene("HiddenObjectGameScene");
    }
}

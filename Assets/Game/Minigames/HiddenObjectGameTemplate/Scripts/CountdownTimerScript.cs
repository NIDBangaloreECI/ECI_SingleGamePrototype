using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace com.nidb.games.hiddenobjectgame
{
    public class CountdownTimerScript : MonoBehaviour
    {
		public delegate void TimerUpdateDelegate(float timeLeft);

		[SerializeField]
		private Text cdTimer;
	
		public float timeLeft = 60;
        float min;
        float sec;

		private TimerUpdateDelegate mOnTimerUpdate;
		private bool mIsTimerRunning = true;
		private float mCurrTimeLeft;

		public event TimerUpdateDelegate pOnTimerUpdate 
		{
			add { mOnTimerUpdate += value; }
			remove { mOnTimerUpdate -= value; }
		}

		public void Start()
		{
			Reset();
		}

		public void Reset()
		{
			mCurrTimeLeft = timeLeft;
			mIsTimerRunning = true;
		}

        void Update()
        {
			if(!mIsTimerRunning)
				return;
            mCurrTimeLeft -= Time.deltaTime;
			if(mCurrTimeLeft >= 0)
			{
				min = Mathf.Floor(mCurrTimeLeft / 60);
				sec = Mathf.Floor(mCurrTimeLeft % 60);
	            if (sec >= 10)
	            {
	                cdTimer.text = "0" + min.ToString() + ":" + sec.ToString();
	            }
	            else
	            {
	                cdTimer.text = "0" + min.ToString() + ":" + "0" + sec.ToString();
	            }
			}
			if(mOnTimerUpdate != null)
				mOnTimerUpdate(mCurrTimeLeft);
			if(timeLeft <= 0)
				mIsTimerRunning = false;
        }

        public void setTimeLeft(int n)
        {
			mCurrTimeLeft = mCurrTimeLeft - n;
        }
    }

}

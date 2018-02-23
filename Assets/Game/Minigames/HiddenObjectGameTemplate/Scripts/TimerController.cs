using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.nidb.games.hiddenobjectgame
{
    public class TimerController : MonoBehaviour
    {

        private int mWrongClickCount;
        [SerializeField]
        private GameObject mPenaltyPopUpPanel;

        // Use this for initialization
        void Start()
        {
            mWrongClickCount = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if (mWrongClickCount == 3)
            {

                this.GetComponent<CountdownTimerScript>().setTimeLeft(5);
                Time.timeScale = 0.5f;
                mPenaltyPopUpPanel.SetActive(true);
                mWrongClickCount = 0;
                Invoke("PanelDeactivator", 0.75f);


            }
        }

        public void setWrongClickCount(int clickIndex)
        {
            mWrongClickCount += clickIndex;
        }

        void PanelDeactivator()
        {
            mPenaltyPopUpPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.nidb.games.hiddenobjectgame
{
	/**
	 * Hidden object game controller
	 */
	public class HiddenObjectSceneController : MonoBehaviour 
	{

		[SerializeField]
		private bool _randomize = false;
		[SerializeField]
		private HoGObjectMenuItem[] _menuSlots;

		private List<ValidObjectsScript> mInactiveObjects = new List<ValidObjectsScript>();
		private List<ValidObjectsScript> mUsedObjects = new List<ValidObjectsScript>();
		private int mCurrentIndex = 0 ;

		[SerializeField]private Text leftText;
		[SerializeField]private Text middleText;
		[SerializeField]private Text rightText;

		// Use this for initialization
		void Start () 
		{
			mCurrentIndex = 0;
			Initialize();
//			ArrUpdate (mCurrentIndex);
		}
		
		// Update is called once per frame
		void Update () {
/*			if (mCurrentIndex < mInactiveObjects.Count - 3) {
				if (mInactiveObjects [mCurrentIndex] == null && mInactiveObjects [mCurrentIndex + 1] == null && mInactiveObjects [mCurrentIndex + 2] == null) {
					mCurrentIndex = mCurrentIndex + 3;
					ArrUpdate (mCurrentIndex);
				}
			}

			if (mInactiveObjects [mCurrentIndex] == null) {
				leftText.color = Color.black;
			}

			if (mInactiveObjects [mCurrentIndex+1] == null) {
				middleText.color = Color.black;
			}

			if (mInactiveObjects [mCurrentIndex+2] == null) {
				rightText.color = Color.black;
			}
*/
		}

		private void Initialize()
		{
			mInactiveObjects.Clear();
			mUsedObjects.Clear();
			GameObject[] hiddenObjects = GameObject.FindGameObjectsWithTag ("valid");
			for(int i = 0; i < hiddenObjects.Length; ++i)
			{
				mInactiveObjects.Add(hiddenObjects[i].GetComponent<ValidObjectsScript>());
				mInactiveObjects[i].enabled = false;
			}

			// Select objects and place into menu slots
			for(int i = 0; i < _menuSlots.Length; ++i)
			{
				ValidObjectsScript obj = GetNextObject();
				_menuSlots[i].SetObject(obj);
			}
		}

/*		void ArrUpdate(int n)
		{
			leftText.text = mInactiveObjects [n].gameObject.name;
			middleText.text = mInactiveObjects [n + 1].gameObject.name;
			rightText.text = mInactiveObjects [n + 2].gameObject.name;
			leftText.color = Color.red;
			rightText.color = Color.red;
			middleText.color = Color.red;
			for (int i = n; i < n + 3; i++) {
				mInactiveObjects [i].gameObject.GetComponent<ValidObjectsScript> ().enabled = true;
			}
		}
*/
		private ValidObjectsScript GetNextObject()
		{
			ValidObjectsScript outObj = null;
			if(_randomize)
			{
				int rndIdx = Random.Range(0, mInactiveObjects.Count);
				outObj = mInactiveObjects[rndIdx];
			}
			else
			{
				if(mCurrentIndex < 0 || mCurrentIndex >= mInactiveObjects.Count)
					mCurrentIndex = 0;
				outObj = mInactiveObjects[mCurrentIndex++];
			}
			if(outObj != null)
			{
				mUsedObjects.Add(outObj);
				mInactiveObjects.Remove(outObj);
			}
			return outObj;
		}
	}
}
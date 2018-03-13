using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using com.nidb.ecigame.ui;

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
		[SerializeField]
		private Transform _gameOverScreen;
		[SerializeField]
		private Button _hintsButton;
		[SerializeField]
		private CountdownTimerScript _countdownTimer;
		[SerializeField]
		private float[] _timeRemainingTargets;
		[SerializeField]
		private Transform _validObjectsRoot;

		private List<ValidObjectsScript> mInactiveObjects = new List<ValidObjectsScript>();
		private List<ValidObjectsScript> mUsedObjects = new List<ValidObjectsScript>();
		private int mCurrentIndex = 0 ;
		private int mTotalObjects = -1;
		private int mObjectsFound = -1;
		private float mCurrentTimeRemaining;
		
		// Use this for initialization
		void Start () 
		{
			mCurrentIndex = 0;
			Initialize();
			_hintsButton.onClick.AddListener(() => ShowHint());
			_countdownTimer.pOnTimerUpdate += ((float timeLeft) => TimerUpdate(timeLeft));
		}
		
		// Update is called once per frame
		void Update () 
		{

		}

		private void Initialize()
		{
			mInactiveObjects.Clear();
			mUsedObjects.Clear();
			for(int i = 0; i < _validObjectsRoot.childCount; ++i)
			{
				mInactiveObjects.Add(_validObjectsRoot.GetChild(i).GetComponent<ValidObjectsScript>());
				mInactiveObjects[i].enabled = false;
			}
			mTotalObjects = _validObjectsRoot.childCount;
			mObjectsFound = 0;

			// Select objects and place into menu slots
			for(int i = 0; i < _menuSlots.Length; ++i)
			{
				ValidObjectsScript obj = GetNextObject();
				if(obj != null)
				{
					_menuSlots[i].SetObject(obj);
					int menuItemId = i;
					_menuSlots[i].pOnMenuObjectRemoved += (HoGObjectMenuItem menuItem) => 
					{
						ValidObjectsScript newObj = GetNextObject();
						if(newObj != null)
							_menuSlots[menuItemId].SetObject(newObj);
						mObjectsFound++;
						CheckGameOver();
					};
				}
			}
		}
		
		private void CheckGameOver()
		{
			bool gameOver = true;
			for(int i = 0; i < _menuSlots.Length; ++i)
			{
				if(_menuSlots[i].pHasObject)
					gameOver = false;
			}
			if(gameOver)
			{
				DoGameOver ();
			}
		}

		private void TimerUpdate(float timeLeft)
		{
			mCurrentTimeRemaining = timeLeft;
			if(timeLeft <= 0) 
				DoGameOver();
		}

		private void DoGameOver()
		{
			if(_gameOverScreen != null)
			{
				_gameOverScreen.gameObject.SetActive(true);
				_gameOverScreen.GetComponent<EndGameScreen>().SetScore(mCurrentTimeRemaining, _timeRemainingTargets);
			}
		}

		private ValidObjectsScript GetNextObject()
		{
			ValidObjectsScript outObj = null;
			if(mInactiveObjects.Count <= 0 || mCurrentIndex >= mInactiveObjects.Count)
				return null;
			if(_randomize)
			{
				int rndIdx = Random.Range(0, mInactiveObjects.Count);
				outObj = mInactiveObjects[rndIdx];
				mUsedObjects.Add(outObj);
				mInactiveObjects.Remove(outObj);
			}
			else
			{
				if(mCurrentIndex < 0 || mCurrentIndex >= mInactiveObjects.Count)
					mCurrentIndex = 0;
				outObj = mInactiveObjects[mCurrentIndex++];
			}
			return outObj;
		}

		private void ShowHint()
		{
			_menuSlots[Random.Range(0, _menuSlots.Length)].ShowHint();
		}
	}
}
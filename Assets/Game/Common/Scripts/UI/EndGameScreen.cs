using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace com.nidb.ecigame.ui
{
	public class EndGameScreen : MonoBehaviour 
	{
		[SerializeField]
		private Button _btnMenu;
		[SerializeField]
		private Button _btnQuit;
		[SerializeField]
		private Button _btnReplay;
		[SerializeField]
		private string _menuScene;
		[SerializeField]
		private string _replayScene;

		[Header("Response Info")]
		[SerializeField]
		private string _successTitle;
		[SerializeField]
		private string _failureTitle;
		[SerializeField]
		private string _successMsg;
		[SerializeField]
		private string _failureMsg;
		[SerializeField]
		private Text _txtTitle;
		[SerializeField]
		private Text _txtMsg;
		[SerializeField]
		private RectTransform[] _stars;

		public void Start()
		{
			if(_btnMenu != null)
				_btnMenu.onClick.AddListener( () => SceneManager.LoadScene(_menuScene) );
			if(_btnQuit != null)
				_btnQuit.onClick.AddListener( () => Application.Quit() );
			if(_btnReplay != null)
				_btnReplay.onClick.AddListener( () => SceneManager.LoadScene(_replayScene) );
		}

		/**
		 * If scored points are less than targetPoints[0] then level is failed.
		 * Otherwise number of stars depends on which level in the array is reached in scoredpoints.
		 */
		public void SetScore(float scoredPoints, float[] targetPoints)
		{
			System.Array.Sort<float>(targetPoints);
			bool isLevelComplete = (scoredPoints > targetPoints[0]);
			_txtTitle.text = (isLevelComplete) ? _successTitle : _failureTitle;
			_txtMsg.text = (isLevelComplete) ? _successMsg : _failureMsg;

			int numStars = 0;
			for(int i = 0; i < targetPoints.Length; ++i)
			{
				if(targetPoints[i] < scoredPoints)
					numStars = i;
			}

			for(int i = 0; i < _stars.Length; ++i)
			{
				_stars[i].gameObject.SetActive((i <= numStars));
			}
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace com.nidb.ecigame.ui
{
	/**
	 * Implements basic game loading functionality
	 */
	public class LoadingScreen : MonoBehaviour 
	{
		[SerializeField]
		private Slider _loadingBarSlider;
		[Tooltip("Scene to load after loading is done")]
		[SerializeField]
		private string _gameStartScene;

		[Tooltip("Temporary Fake delay before loading. To be removed later.")]
		[SerializeField]
		private float _fakeLoadingTime = 1;

		private float mFakeLoadingTimeSpent = 0;

		// Use this for initialization
		void Start () 
		{
			mFakeLoadingTimeSpent = 0;
			_loadingBarSlider.value = 0;
		}
		
		// Update is called once per frame
		void Update () 
		{
			// Fake loading for now
			_loadingBarSlider.value = SimulateLoading();
			if(_loadingBarSlider.value >= 1)
			{
				// Load next scene
				SceneManager.LoadScene(_gameStartScene);
			}
		}

		/**
		 * Returns the amount of loading done
		 */
		private float SimulateLoading()
		{
			mFakeLoadingTimeSpent += Time.deltaTime;
			return (mFakeLoadingTimeSpent / _fakeLoadingTime);
		}
	}
}
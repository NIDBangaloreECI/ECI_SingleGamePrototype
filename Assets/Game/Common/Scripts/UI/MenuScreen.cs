using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using com.nidb.data;

namespace com.nidb.ecigame.ui
{
	/**
	 * Implements the Episodes Menu screen
	 */
	public class MenuScreen : MonoBehaviour 
	{
		[SerializeField]
		private ECIGameEpisodes _episodesDatabase;

		[SerializeField]
		private Button _menuButtonTemplate;
		[SerializeField]
		private float _yOffset;

		[SerializeField]
		private RectTransform _menuContentRoot;

		// Use this for initialization
		void Start () 
		{
			RefreshMenu();
		}
		
		private void RefreshMenu()
		{
			float btnX = 8;
			float btnY = -150;
			for(int i = 0; i < _episodesDatabase.pEpisodeCount; ++i)
			{
				GameObject btnObj = (GameObject)GameObject.Instantiate(_menuButtonTemplate.gameObject);
				RectTransform btnTrans = btnObj.GetComponent<RectTransform>();
				btnTrans.SetParent(_menuContentRoot);
				btnTrans.anchoredPosition = new Vector2(btnX, btnY);
				btnTrans.localScale = new Vector3(1, 1, 1);
				btnX += btnTrans.sizeDelta.x;
				_episodesDatabase.SetupEpisodeButton(btnObj.GetComponent<Button>(), i);
				btnObj.SetActive(true);
				int epIdx = i;
				btnObj.GetComponent<Button>().onClick.AddListener( () => _episodesDatabase.LoadEpisode(epIdx));
			}
		}
	}
}
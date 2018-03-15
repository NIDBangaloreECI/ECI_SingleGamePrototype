using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace com.nidb.games.hiddenobjectgame
{
	/**
	 * Handles HUD events that are not directly related to the game
	 */
	public class HiddenObjectHUDHandler : MonoBehaviour 
	{
		[Header("Home Button")]
		[SerializeField]
		private Button _btnHome;
		[SerializeField]
		private string _homeSceneName;
		[Header("Help Button")]
		[SerializeField]
		private Button _btnHelp;
		[SerializeField]
		private Transform _pnlHelp;

		// Use this for initialization
		void Start () 
		{
			if(_btnHome != null)
				_btnHome.onClick.AddListener(() => SceneManager.LoadScene(_homeSceneName));
			if(_btnHelp != null)
				_btnHelp.onClick.AddListener(() => _pnlHelp.gameObject.SetActive(true));
		}
	}
}
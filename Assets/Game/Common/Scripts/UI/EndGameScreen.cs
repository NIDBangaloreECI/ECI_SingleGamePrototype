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

		public void Start()
		{
			if(_btnMenu != null)
				_btnMenu.onClick.AddListener( () => SceneManager.LoadScene(_menuScene) );
			if(_btnQuit != null)
				_btnQuit.onClick.AddListener( () => Application.Quit() );
			if(_btnReplay != null)
				_btnReplay.onClick.AddListener( () => SceneManager.LoadScene(_replayScene) );
		}
	}
}
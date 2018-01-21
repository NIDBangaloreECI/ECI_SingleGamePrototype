using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.nidb.ecigame.ui
{
	public class HelpScreen : MonoBehaviour 
	{
		[SerializeField]
		private Button _btnClose;

		// Use this for initialization
		void Start () 
		{
			_btnClose.onClick.AddListener( () => gameObject.SetActive(false) );
		}
	}
}
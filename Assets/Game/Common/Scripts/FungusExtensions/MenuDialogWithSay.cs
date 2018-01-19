using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

namespace com.nidb.utils
{
	public class MenuDialogWithSay : MenuDialog 
	{
		[SerializeField]
		private Text _sayText;

		public void SetSayText(string sayText)
		{
			_sayText.text = sayText;
		}
	}
}
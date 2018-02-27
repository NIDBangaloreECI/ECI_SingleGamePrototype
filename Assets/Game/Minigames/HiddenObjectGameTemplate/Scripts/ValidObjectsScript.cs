using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace com.nidb.games.hiddenobjectgame
{
	/**
	 * Handles a hidden object in the game scene
	 */
	public class ValidObjectsScript : MonoBehaviour, IPointerClickHandler
	{
		public delegate void ObjectFoundListener();

		[SerializeField]
		private Sprite _menuIcon;
		[SerializeField]
		private string _name;

		private ObjectFoundListener mOnObjectFound = null;

		public Sprite pMenuIconSprite { get { return _menuIcon; } }
		public string pName { get { return (string.IsNullOrEmpty(_name) ? gameObject.name : _name); } }

		public event ObjectFoundListener pObjectFound
		{
			add { mOnObjectFound += value; }
			remove { mOnObjectFound -= value; }
		}

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		public void OnPointerClick(PointerEventData pEvData)
		{
			if (isActiveAndEnabled) 
			{
				if(mOnObjectFound != null)
					mOnObjectFound();
				enabled = false;
				Destroy (this.gameObject);
			}
		}
	}
}
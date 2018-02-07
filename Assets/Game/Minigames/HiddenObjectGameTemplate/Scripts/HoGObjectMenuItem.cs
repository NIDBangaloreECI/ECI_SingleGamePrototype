using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.nidb.games.hiddenobjectgame
{
	/**
	 * Handles a menu item showing the object to be found.
	 */
	public class HoGObjectMenuItem : MonoBehaviour 
	{
		public delegate void MenuObjectRemovedListener(HoGObjectMenuItem menuItem);

		[SerializeField]
		private Image _iconImage;
		[SerializeField]
		private Text _iconText;

		private ValidObjectsScript mCurrentObject;
		private MenuObjectRemovedListener mOnMenuObjectRemoved = null;

		public bool pHasObject { get { return (mCurrentObject != null); } }
		public event MenuObjectRemovedListener pOnMenuObjectRemoved
		{
			add { mOnMenuObjectRemoved += value; }
			remove { mOnMenuObjectRemoved -= value; }
		}

		public void SetObject(ValidObjectsScript obj)
		{
			if(pHasObject)
				throw new UnityException(gameObject.name + " menu already contains object!");
			mCurrentObject = obj;
			mCurrentObject.pObjectFound += OnObjectFound;
			mCurrentObject.enabled = true;
			if(_iconImage != null)
			{
				_iconImage.enabled = true;
				_iconImage.sprite = mCurrentObject.pMenuIconSprite;
				Color c = _iconImage.color;
				c.a = (_iconImage.sprite == null) ? 0 : 1;
				_iconImage.color = c;
			}
			if(_iconText != null)
				_iconText.text = obj.pName;
		}

		private void OnObjectFound()
		{
			// Maybe play some animation before.
			if(_iconImage != null)
			{
				_iconImage.sprite = null;
				_iconImage.enabled = false;
			}
			if(_iconText != null)
				_iconText.text = string.Empty;
			mCurrentObject.pObjectFound -= OnObjectFound;
			mCurrentObject = null;
			if(mOnMenuObjectRemoved != null)
				mOnMenuObjectRemoved(this);
		}
	}
}
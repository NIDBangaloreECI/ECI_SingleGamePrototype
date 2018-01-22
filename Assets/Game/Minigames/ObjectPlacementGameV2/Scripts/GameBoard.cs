using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.nidb.games.placementgame
{
	/**
	 * Handles the game board for the placement game.
	 * Acts as the game Manager for this game
	 */
	public class GameBoard : MonoBehaviour 
	{
		[System.Serializable]
		public class PlaceableObjectInfo
		{
			[SerializeField]
			private string _name;
			[SerializeField]
			private string _displayName;
			[SerializeField]
			private Sprite _objImage;
			[SerializeField]
			private Sprite _iconImage;

			public string pName { get { return _name; } }
			public string pDisplayName { get { return _displayName; } }
			public Sprite pObjImage { get { return _objImage; } }
			public Sprite pIconImage { get { return _iconImage; } }
		}

		[Tooltip("The root gameobject container for all the placement slots")]
		[SerializeField]
		private Transform _placementSlotsRoot;
		[Tooltip("All placeable objects info")]
		[SerializeField]
		private PlaceableObjectInfo[] _placeableObjects;
		[SerializeField]
		private PlaceableObjectsMenu _menu;
		[SerializeField]
		private Transform _pnlGameOver;
		[SerializeField]
		private Button _btnHelp;
		[SerializeField]
		private Transform _pnlHelp;

		private PlacementSlot[] mPlacementSlots;
		private PlaceableObject mActivePlaceable;
		private int mPlacedObjects = 0;

		public PlaceableObject pActivePlaceable { get { return mActivePlaceable; } }

		public void Start()
		{
			mPlacementSlots = _placementSlotsRoot.GetComponentsInChildren<PlacementSlot>();
			for(int i = 0; i < mPlacementSlots.Length; ++i)
				mPlacementSlots[i].SetGameBoard(this);
			_menu.SetPlaceableObjects(this, _placeableObjects);
			mPlacedObjects = 0;
			_btnHelp.onClick.AddListener ( () => _pnlHelp.gameObject.SetActive(true) );
		}

		public void SetActivePlaceable(PlaceableObject obj)
		{
			mActivePlaceable = obj;
			_menu.SetSelected (obj);
		}

		public void PlacementFailed()
		{
		}

		public void PlacementSucceeded()
		{
			mActivePlaceable.gameObject.SetActive(false);
			_menu.RefreshMenu ();
			mPlacedObjects++;
			if(mPlacedObjects >= _placeableObjects.Length)
				_pnlGameOver.gameObject.SetActive(true);
		}

	}
}
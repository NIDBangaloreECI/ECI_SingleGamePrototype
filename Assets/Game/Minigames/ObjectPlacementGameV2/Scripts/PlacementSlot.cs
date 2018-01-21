using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.nidb.games.placementgame
{
	/**
	 * Manages a placement slot on the game board.
	 */
	[RequireComponent(typeof(Button))]
	public class PlacementSlot : MonoBehaviour 
	{
		[Tooltip("The name of the object that can be placed here. NOTE: this should match the name specified in the object info in the game board")]
		[SerializeField] 
		private string _objectName;
		[Tooltip("The image of the place object.")]
		[SerializeField]
		private Image _mObjectImage;

		private GameBoard _mBoard;
		private bool mIsEmpty = true;
		public void Start()
		{
			GetComponent<Button>().onClick.AddListener( () => TryPlaceObject() );
		}

		public void SetGameBoard(GameBoard brd)
		{
			_mBoard = brd;
		}

		private void TryPlaceObject()
		{
			if(mIsEmpty && _mBoard.pActivePlaceable != null && _mBoard.pActivePlaceable.pInfo.pName == _objectName)
			{
				mIsEmpty = false;
				_mObjectImage.sprite = _mBoard.pActivePlaceable.pInfo.pObjImage;
				_mBoard.PlacementSucceeded();
			}
			else
			{
				_mBoard.PlacementFailed();
			}
		}

	}
}
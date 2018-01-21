using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.nidb.games.placementgame
{
	/**
	 * Manages a placeable object.
	 */
	[RequireComponent(typeof(Button))]
	public class PlaceableObject : MonoBehaviour 
	{
		[SerializeField]
		private Image _iconImage;

		private GameBoard.PlaceableObjectInfo mInfo;
		private GameBoard mBoard;

		public GameBoard.PlaceableObjectInfo pInfo { get { return mInfo; } }

		public void SetupObject(GameBoard board, GameBoard.PlaceableObjectInfo objInfo)
		{
			mBoard = board;
			mInfo = objInfo;

			_iconImage.sprite = mInfo.pIconImage;
			GetComponent<Button>().onClick.AddListener( () => mBoard.SetActivePlaceable(this) );
		}
	}
}
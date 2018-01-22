using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.nidb.games.placementgame
{
	public class PlaceableObjectsMenu : MonoBehaviour 
	{

		[SerializeField]
		private Button _menuButtonTemplate;
		[SerializeField]
		private float _xOffset = 10;
		[SerializeField]
		private float _yOffset = -100;
		[SerializeField]
		private float _xPad = 10;
		[SerializeField]
		private RectTransform _menuContentRoot;

		public void SetPlaceableObjects(GameBoard board, GameBoard.PlaceableObjectInfo[] objects)
		{
			float btnX = _xOffset;
			float btnY = _yOffset;
			for(int i = 0; i < objects.Length; ++i)
			{
				GameObject btnObj = (GameObject)GameObject.Instantiate(_menuButtonTemplate.gameObject);
				RectTransform btnTrans = btnObj.GetComponent<RectTransform>();
				btnTrans.SetParent(_menuContentRoot);
				btnTrans.anchoredPosition = new Vector2(btnX, btnY);
				btnTrans.localScale = new Vector3(1, 1, 1);
				btnX += btnTrans.sizeDelta.x + _xPad;
				int objIdx = i;
				btnObj.GetComponent<PlaceableObject>().SetupObject(board, objects[objIdx]);
				btnObj.SetActive(true);
				Vector2 size = _menuContentRoot.sizeDelta;
				size.x = btnX;
				_menuContentRoot.sizeDelta = size;
			}
		}

		public void RefreshMenu()
		{
			float btnX = _xOffset;
			float btnY = _yOffset;
			RectTransform[] children = new RectTransform[_menuContentRoot.childCount];
			for (int i = 0; i < _menuContentRoot.childCount; ++i) 
			{
				children [i] = _menuContentRoot.GetChild (i) as RectTransform;
			}
			for(int i = 0; i < children.Length; ++i)
			{
				if (children [i] == null || !children [i].gameObject.activeSelf )
					continue;
				RectTransform btnTrans = children[i];
				btnTrans.anchoredPosition = new Vector2(btnX, btnY);
				btnTrans.localScale = new Vector3(1, 1, 1);
				btnX += btnTrans.sizeDelta.x + _xPad;
				Vector2 size = _menuContentRoot.sizeDelta;
				size.x = btnX;
				_menuContentRoot.sizeDelta = size;
			}
		}

		public void SetSelected(PlaceableObject obj)
		{
			for (int i = 0; i < _menuContentRoot.childCount; ++i) 
			{
				PlaceableObject childObj = _menuContentRoot.GetChild (i).GetComponent<PlaceableObject>();
				if (!childObj.gameObject.activeSelf)
					continue;
				if (childObj.pInfo.pName == obj.pInfo.pName)
					childObj.SetHighlight (true);
				else
					childObj.SetHighlight (false);
			}
		}
	}
}
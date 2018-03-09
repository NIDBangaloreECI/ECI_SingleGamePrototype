using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.nidb.utils
{
	public class FloatObject : MonoBehaviour 
	{
		public enum MoveDirection
		{
			UP = 1, 
			DOWN = -1
		}

		[Range(0, 2)]
		[SerializeField]
		private float _floatDistance = 0.5f;

		[Range(0, 10)]
		[SerializeField]
		private float _vibrateSpeed = 1f;

		[SerializeField]
		private MoveDirection _startDirection = MoveDirection.UP;

		private float mStartY;
		private MoveDirection mCurrentDirection;

		// Use this for initialization
		void Start () 
		{
			mStartY = transform.localPosition.y;
			mCurrentDirection = _startDirection;
		}
		
		// Update is called once per frame
		void Update () 
		{
			Vector3 pos = transform.localPosition;
			pos.y += ((int)mCurrentDirection * _vibrateSpeed * Time.deltaTime);
			transform.localPosition = pos;
			if((mCurrentDirection == MoveDirection.DOWN) && (pos.y < (mStartY - _floatDistance)))
				mCurrentDirection = MoveDirection.UP;
			if((mCurrentDirection == MoveDirection.UP) && (pos.y > (mStartY + _floatDistance)))
				mCurrentDirection = MoveDirection.DOWN;
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.nidb.utils
{
	public interface IPooledGameObject 
	{
		//< Called the first time the object is created.
		void OnCreated();
		//< Called when the object is destroyed.
		void OnDestroyed();
		//< Called when the object is requested from the pool.
		void OnSpawned();
		//< Called when the Object is released back to the pool.
		void OnReleased();
	}
}
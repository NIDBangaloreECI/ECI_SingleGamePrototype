using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.nidb.utils
{
	/**
	 * Defines an object that can be collected by the player
	 * Needs a collider setup as trigger.
	 */
	public abstract class CollectableObject : MonoBehaviour 
	{
		public delegate void OnCollectedDelegate(CollectableObject collectedObject);

		[SerializeField]
		private ParticleSystem _idleParticles;
		[SerializeField]
		private ParticleSystem _collectedParticles;

		private const string PLAYER_TAG = "Player";
		private OnCollectedDelegate mOnCollected;

		public event OnCollectedDelegate pOnCollected 
		{ 
			add { mOnCollected += value; } 
			remove { mOnCollected -= value; } 
		}

		public void Start()
		{
			Setup();
		}

		public void Setup()
		{
			if(_idleParticles != null && !_idleParticles.isPlaying)
				_idleParticles.Play();
			if(_collectedParticles != null && _collectedParticles.isPlaying)
				_collectedParticles.Stop();
		}

		public void OnTriggerEnter(Collider c)
		{
			if(c.tag == PLAYER_TAG)
			{
				if(mOnCollected != null)
					mOnCollected(this);
				OnCollectedAction(c.gameObject);
				DoDestroyEffects();
				StartCoroutine(DoDelayedDestroy());
			}
		}

		protected void DoDestroyEffects()
		{
			if(_idleParticles != null && _idleParticles.isPlaying)
				_idleParticles.Stop();
			if(_collectedParticles != null)
				_collectedParticles.Play();
		}

		protected IEnumerator DoDelayedDestroy()
		{
			yield return new WaitForEndOfFrame();
			while(_collectedParticles.isPlaying)
				yield return new WaitForEndOfFrame();
			GameObject.DestroyImmediate(gameObject);
		}

		/** Override in child classes for specific on collected actions */
		protected abstract void OnCollectedAction(GameObject collectedBy);
	}
}
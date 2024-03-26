namespace Games.SinghKage.StateMachine
{
	using UnityEngine;
	using System;
	using System.Collections;

	[System.Serializable]
	public abstract class BaseAbility<T> : MonoBehaviour where T : BaseStateMachine
	{
		protected T owner;
		public void Initialize(T owner)
		{
			this.owner = owner;
		}
		public abstract void Execute();
	}
}
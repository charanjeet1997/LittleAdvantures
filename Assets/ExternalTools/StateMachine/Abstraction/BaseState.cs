namespace Games.SinghKage.StateMachine
{
	using System;
	using UnityEngine;
	public abstract class BaseState<T> : MonoBehaviour where T : BaseStateMachine
	{
		[SerializeField] protected T owner;
		public abstract void Enter();
		public abstract void Exit();
	}
}	
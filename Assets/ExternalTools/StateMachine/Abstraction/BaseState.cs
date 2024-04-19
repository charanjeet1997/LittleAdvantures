namespace Games.SinghKage.StateMachine
{
	using System;
	using UnityEngine;
	public abstract class BaseState : MonoBehaviour
	{
		public abstract void Enter();
		public abstract void Exit();
		public abstract void Transition();
	}
}	
namespace Games.SinghKage.StateMachine
{
	using UnityEngine;
	using System;
	using System.Collections;

	public interface ILateTickable 
	{
		void LateTick();
	}
}
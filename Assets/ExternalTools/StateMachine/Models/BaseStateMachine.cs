using System.Collections.Generic;

namespace Games.SinghKage.StateMachine
{
	using UnityEngine;
	using System;
	using System.Collections;
	
	public class BaseStateMachine : MonoBehaviour
	{

		#region PRIVATE_VARS
		[SerializeField] protected List<BaseAbility> abilities;
		#endregion

		#region PUBLIC_VARS

		[HideInInspector]public BaseState currentState;
		#endregion

		#region UNITY_CALLBACKS
		

		#endregion

		#region PUBLIC_METHODS

		public virtual void Start()
		{
			if (currentState != null)
			{
				currentState.Enter();
			}
		}
		public virtual void Update()
		{
			if (currentState is ITickable tickable)
			{
				tickable.Tick();
			}
		}

		public virtual void FixedUpdate()
		{
			CastAbility();
			if (currentState is IFixedTickable tickable)
			{
				tickable.FixedTick();
			}
		}

		public virtual void LateUpdate()
		{
			if (currentState is ILateTickable tickable)
			{
				tickable.LateTick(); 
			}
		}

		public virtual void ChangeState(BaseState state)
		{
			if (currentState != null)
			{
				currentState.Exit();
			}

			currentState = state;
			currentState.Enter();
		}
		#endregion

		#region PRIVATE_METHODS
		void CastAbility()
		{
			// loop through the abilities
			foreach (var ability in abilities)
			{
				// execute the ability
				ability.Execute();
			}
		}

		#endregion

	}
}
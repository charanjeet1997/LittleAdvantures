using System.Collections.Generic;

namespace Games.SinghKage.StateMachine
{
	using UnityEngine;
	using System;
	using System.Collections;
	
	public class BaseStateMachine : MonoBehaviour
	{

		#region PRIVATE_VARS
		[SerializeField] protected List<BaseAbility<BaseStateMachine>> abilities;
		[SerializeField] protected List<BaseSensor<BaseStateMachine>> sensors;
		#endregion

		#region PUBLIC_VARS

		public BaseState<BaseStateMachine> currentState;
		#endregion

		#region UNITY_CALLBACKS
		

		#endregion

		#region PUBLIC_METHODS

		public virtual void Start()
		{
			foreach (var ability in abilities)
			{
				// execute the ability
				ability.Initialize(this);
			}
			foreach (var sensor in sensors)
			{
				// sense the ability
				sensor.Initialize(this);
			}
		}
		public virtual void Update()
		{
			CastAbility();
			if (currentState is ITickable tickable)
			{
				tickable.Tick();
			}
		}

		public virtual void FixedUpdate()
		{
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

		public virtual void ChangeState(BaseState<BaseStateMachine> state)
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
		
		void Sense()
		{
			// loop through the sensors
			foreach (var sensor in sensors)
			{
				// sense the ability
				sensor.Sense();
			}
		}

		#endregion

	}
}
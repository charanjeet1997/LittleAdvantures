using Games.SinghKage.StateMachine;

namespace Games.SinghKage.LittleAdvantures
{
	using UnityEngine;
	using System;
	using System.Collections;

	public class ApplyGravity : BaseAbility
	{

		#region PRIVATE_VARS
		
		#endregion

		#region PUBLIC_VARS
		public PlayerStateMachine owner;
		#endregion

		#region UNITY_CALLBACKS

		#endregion

		#region PUBLIC_METHODS
		public override void Execute()
		{
			if (!owner.groundCheckData.isGrounded)
			{
				Vector3 gravity = Physics.gravity + owner.characterController.velocity;
				owner.characterController.Move(gravity * Time.deltaTime);
			}
		}

		#endregion

		#region PRIVATE_METHODS

		#endregion

	}
}
namespace Games.SinghKage.StateMachine
{
	using UnityEngine;
	using System;
	using System.Collections;

	[Serializable]
	public class GroundCheck : BaseSensor
	{

		#region PRIVATE_VARS

		[SerializeField] private CharacterController controller;
		#endregion

		#region PUBLIC_VARS
		#endregion

		#region UNITY_CALLBACKS

		#endregion

		#region PUBLIC_METHODS
		public override bool Sense()
		{
			return controller.isGrounded;
		}

		#endregion

		#region PRIVATE_METHODS

		#endregion

	}
}
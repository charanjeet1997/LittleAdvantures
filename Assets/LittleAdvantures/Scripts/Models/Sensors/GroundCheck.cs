using UnityEngine.Serialization;

namespace Games.SinghKage.StateMachine
{
	using Games.SinghKage.LittleAdvantures;
	using System;
	using UnityEngine;

	[Serializable]
	public class GroundCheck : BaseSensor
	{

		#region PRIVATE_VARS

		public PlayerStateMachine owner;
		#endregion

		#region PUBLIC_VARS
		#endregion

		#region UNITY_CALLBACKS

		#endregion

		#region PUBLIC_METHODS
		public override bool Sense()
		{
			int rayHitCount = 0;
			for (int indexOfGroundRay = 0; indexOfGroundRay < owner.groundCheckData.groundRayDirectionOffsets.Length; indexOfGroundRay++)
			{
				//Check if the ray is hitting the ground
				Vector3 rayOffset = owner.groundCheckData.groundRayDirectionOffsets[indexOfGroundRay];
				if (Physics.Raycast(owner.transform.position + rayOffset, Vector3.down,out RaycastHit hit,owner.groundCheckData.groundRayDistance,owner.groundCheckData.groundLayerMask))
				{
					rayHitCount++;
				}
			}
			return rayHitCount > 0;
		}

		#endregion

		#region PRIVATE_METHODS

		#endregion

	}
}
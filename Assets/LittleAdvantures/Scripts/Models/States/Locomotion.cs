namespace Games.SinghKage.LittleAdvantures
{
	using UnityEngine;
	using StateMachine;
	using Games.CameraManager;
	using GameServiceLocator;


	public class Locomotion : BaseState<PlayerStateMachine>,IFixedTickable
	{

		#region PRIVATE_VARS

		private Camera camera;
		#endregion

		#region PUBLIC_VARS

		#endregion

		#region UNITY_CALLBACKS

		#endregion

		#region PUBLIC_METHODS
		public override void Enter()
		{
			camera = ServiceLocator.Current.Get<ICameraManager>().GetCamera();
		}
		public override void Exit()
		{
			
		}
		public void FixedTick()
		{
			CalculatePlayerRotation();
			CalculatePlayerMovement();
			ApplyGravity();
		}
		#endregion

		#region PRIVATE_METHODS
		void CalculatePlayerMovement()
		{
			Quaternion cameraRotation = camera.transform.rotation;
			owner.locomotionData.movementVelocity = new Vector3(owner.movementInput.PlayerInputs().x, 0, owner.movementInput.PlayerInputs().y);
			owner.locomotionData.movementVelocity.Normalize();
			owner.locomotionData.movementVelocity = cameraRotation * owner.locomotionData.movementVelocity;
			owner.locomotionData.movementVelocity *= owner.locomotionData.movementSpeed * Time.deltaTime;
		}
		
		void CalculatePlayerRotation()
		{
			if (Mathf.Abs(owner.movementInput.PlayerInputs().x) > 0 || Mathf.Abs(owner.movementInput.PlayerInputs().y) > 0)
			{
				owner.locomotionData.movementVelocity.y = 0;
				Quaternion targetRotation = Quaternion.LookRotation(owner.locomotionData.movementVelocity);
				transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, owner.locomotionData.rotationSpeed * Time.deltaTime);
			}
		}
		
		void ApplyGravity()
		{
			if (!owner.characterController.isGrounded)
			{
				float gravity = Physics.gravity.y;
				owner.locomotionData.movementVelocity += Vector3.down * gravity * Time.deltaTime;
			}
		}
		#endregion
		
	}
}
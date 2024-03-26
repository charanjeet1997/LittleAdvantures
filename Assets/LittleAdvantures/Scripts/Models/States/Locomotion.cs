namespace Games.SinghKage.LittleAdvantures
{
	using UnityEngine;
	using StateMachine;
	using Games.CameraManager;
	using GameServiceLocator;


	public class Locomotion : BaseState,IFixedTickable,ILateTickable
	{

		#region PRIVATE_VARS
		
		private Camera camera;
		#endregion

		#region PUBLIC_VARS

		public PlayerStateMachine owner;
		#endregion

		#region UNITY_CALLBACKS

		#endregion

		#region PUBLIC_METHODS
		public override void Enter()
		{
			Debug.Log("Enter locomotion state");
			camera = ServiceLocator.Current.Get<ICameraManager>().GetCamera();
		}
		public override void Exit()
		{
			
		}
		public void FixedTick()
		{
			if (owner.movementInput.PlayerInputs().magnitude <= 0)
			{
				owner.ChangeState(owner.idle);
			}
			CalculatePlayerRotation();
			CalculatePlayerMovement();
			owner.characterController.Move(owner.locomotionData.movementVelocity); 
			GroundCheck();
			ApplyGravity();
		}
		public void LateTick()
		{
			Animate();
		}
		#endregion

		#region PRIVATE_METHODS
		void CalculatePlayerMovement()
		{
			Quaternion cameraRotation = camera.transform.rotation;
			owner.locomotionData.movementVelocity = new Vector3(owner.movementInput.PlayerInputs().x, 0, owner.movementInput.PlayerInputs().y);
			owner.locomotionData.movementVelocity = cameraRotation * owner.locomotionData.movementVelocity;
			owner.locomotionData.movementVelocity.y = 0;
			owner.locomotionData.movementVelocity.Normalize();
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
			if (!owner.groundCheckData.isGrounded)
			{
				float gravity = Physics.gravity.y;
				owner.locomotionData.movementVelocity += Vector3.up * gravity * Time.deltaTime;
			}
		}
		
		void Animate()
		{
			owner.animator.SetFloat(owner.animationHashData.locomotionAnimationHash, owner.locomotionData.movementVelocity.normalized.magnitude,0.1f,Time.deltaTime);
		}

		void GroundCheck()
		{
			owner.groundCheckData.isGrounded = owner.groundCheck.Sense();
		}
		#endregion
	}
}
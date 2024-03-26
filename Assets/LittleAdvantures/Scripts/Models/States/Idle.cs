namespace Games.SinghKage.LittleAdvantures
{
	using UnityEngine;
	using StateMachine;
	using Games.CameraManager;
	using GameServiceLocator;


	public class Idle : BaseState,IFixedTickable,ILateTickable
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
			camera = ServiceLocator.Current.Get<ICameraManager>().GetCamera();
		}
		public override void Exit()
		{
			
		}
		public void FixedTick()
		{
			if (owner.movementInput.PlayerInputs().magnitude > 0)
			{
				owner.ChangeState(owner.locomotion);
			}
			ApplyGravity();
			GroundCheck();
			owner.characterController.Move(owner.locomotionData.movementVelocity); 
		}
		public void LateTick()
		{
			Animate();
		}
		#endregion

		#region PRIVATE_METHODS

		void ApplyGravity()
		{
			if (!owner.groundCheckData.isGrounded)
			{
				float gravity = Physics.gravity.y;
				Debug.Log($"Gravity: {gravity}");
				owner.locomotionData.movementVelocity += Vector3.up * gravity * Time.deltaTime;
			}
		}
		
		void Animate()
		{
			owner.animator.SetFloat(owner.animationHashData.locomotionAnimationHash, 0,0.1f,Time.deltaTime);
		}
		
		void GroundCheck()
		{
			owner.groundCheckData.isGrounded = owner.groundCheck.Sense();
		}
		#endregion
	}
}
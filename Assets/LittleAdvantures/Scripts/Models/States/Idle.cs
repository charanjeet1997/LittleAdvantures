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
			Debug.Log("Enter idle state");
			camera = ServiceLocator.Current.Get<ICameraManager>().GetCamera();
		}
		public override void Exit()
		{
			
		}

		public override void Transition()
		{
			if (owner.movementInput.PlayerInputs().magnitude > 0 && owner.groundCheckData.isGrounded)
			{
				owner.ChangeState(owner.locomotion);
			}
			if(!owner.groundCheckData.isGrounded)
			{
				owner.ChangeState(owner.airBorne);
			}
		}

		public void FixedTick()
		{
			GroundCheck();
			owner.characterController.Move(Vector3.zero); 
		}
		public void LateTick()
		{
			Animate();
		}
		#endregion

		#region PRIVATE_METHODS

		void Animate()
		{
			owner.animator.SetFloat(owner.animationHashData.locomotionAnimationHash, 0,0.1f,Time.deltaTime);
			owner.animator.SetBool(owner.animationHashData.AirborneAnimationHash,!owner.groundCheckData.isGrounded);
		}
		
		void GroundCheck()
		{
			owner.groundCheckData.isGrounded = owner.groundCheck.Sense();
		}
		#endregion
	}
}
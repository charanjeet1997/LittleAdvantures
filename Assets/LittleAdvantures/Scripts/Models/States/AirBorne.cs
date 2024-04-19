namespace Games.SinghKage.LittleAdvantures
{
	using UnityEngine;
	using StateMachine;
	using Games.CameraManager;
	using GameServiceLocator;


	public class AirBorne : BaseState,IFixedTickable,ILateTickable
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
			Debug.Log("Enter AirBorne state");
			camera = ServiceLocator.Current.Get<ICameraManager>().GetCamera();
		}
		public override void Exit()
		{
			
		}

		public override void Transition()
		{
			if(owner.groundCheckData.isGrounded)
				owner.ChangeState(owner.locomotion);
		}

		public void FixedTick()
		{
			GroundCheck();
		}
		public void LateTick()
		{
			Animate();
		}
		#endregion

		#region PRIVATE_METHODS
		void Animate()
		{
			owner.animator.SetBool(owner.animationHashData.AirborneAnimationHash,!owner.groundCheckData.isGrounded);
		}
		
		void GroundCheck()
		{
			owner.groundCheckData.isGrounded = owner.groundCheck.Sense();
		}
		#endregion
	}
}

using System;
using Games.SinghKage.StateMachine;

namespace Games.SinghKage.LittleAdvantures
{
	using Games.CameraManager;
	using GameServiceLocator;
	using UnityEngine;
	
	public class PlayerStateMachine : BaseStateMachine
	{
		[System.Serializable]
		public class LocomotionData
		{
			public Vector3 movementVelocity;
			public float movementSpeed;
			public float rotationSpeed;
		}
		
		[Serializable]
		public class AnimationHashData
		{
			public int locomotionAnimationHash = Animator.StringToHash("Locomotion");
		}
		[System.Serializable]
		public class GroundCheckData
		{
			public bool isGrounded;
		}
		#region PRIVATE_VARS
		private Camera camera;
		#endregion

		#region PUBLIC_VARS

		public Animator animator;
		public CharacterController characterController;
		public IPlayerMovementInput movementInput;
		
		[Header("Data")]
		public LocomotionData locomotionData;
		public GroundCheckData groundCheckData;
		public AnimationHashData animationHashData;
		
		[Header("States")]
		public BaseState idle;
		public BaseState locomotion;
		
		[Header("Sensors")]
		public GroundCheck groundCheck;
		#endregion

		#region UNITY_CALLBACKS

		private void Awake()
		{
			movementInput = ServiceLocator.Current.Get<IPlayerMovementInput>();
			movementInput.Init();
		}

		public override void Start()
		{
			base.Start();
			currentState = idle;
			camera = ServiceLocator.Current.Get<ICameraManager>().GetCamera();
			if (characterController == null)
			{
				characterController = GetComponent<CharacterController>();
			}
		}
		

		private void OnDisable()
		{
			movementInput.Destroy();
		}

		#endregion

		#region PUBLIC_METHODS

		#endregion

		#region PRIVATE_METHODS

		#endregion

	}
}
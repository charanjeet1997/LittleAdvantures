
using System;
using CommanTickManager;
using Games.SinghKage.StateMachine;
using UnityEngine.Serialization;

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
			public readonly int locomotionAnimationHash = Animator.StringToHash("Locomotion");
			public readonly int AirborneAnimationHash = Animator.StringToHash("Airborne");
		}
		[System.Serializable]
		public class GroundCheckData
		{
			public bool isGrounded;
			public Vector3[] groundRayDirectionOffsets;
			public float groundRayDistance = 1.1f;
			public LayerMask groundLayerMask;
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
		public BaseState airBorne;
		
		[Header("Sensors")]
		public GroundCheck groundCheck;
		#endregion

		#region UNITY_CALLBACKS
		
		private void Awake()
		{
			movementInput = ServiceLocator.Current.Get<IPlayerMovementInput>();
			movementInput.Init();
		}
		
		//Register tick in on enable
		private void OnEnable()
		{
			ProcessingUpdate.Instance.Add(this);
		}

		public override void Start()
		{
			base.Start();
			Debug.Log("Start");
			ChangeState(idle);
			camera = ServiceLocator.Current.Get<ICameraManager>().GetCamera();
			if (characterController == null)
			{
				characterController = GetComponent<CharacterController>();
			}
		}

		private void OnDisable()
		{
			ProcessingUpdate.Instance.Remove(this);
			movementInput.Destroy();
		}

		private void OnDrawGizmos()
		{
			if (groundCheckData.groundRayDirectionOffsets == null) return;
			foreach (var offset in groundCheckData.groundRayDirectionOffsets)
			{
				Gizmos.DrawRay(transform.position + offset, Vector3.down * groundCheckData.groundRayDistance);
			}
		}

		#endregion

		#region PUBLIC_METHODS

		#endregion

		#region PRIVATE_METHODS

		#endregion

	}
}
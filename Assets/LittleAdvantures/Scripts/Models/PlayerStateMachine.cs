
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
		
		public class GroundCheckData
		{
			public bool isGrounded;
		}
		#region PRIVATE_VARS
		private Camera camera;
		#endregion

		#region PUBLIC_VARS
		public CharacterController characterController;
		public IPlayerMovementInput movementInput;
		public LocomotionData locomotionData;
		public GroundCheckData groundCheckData;
		public BaseState<PlayerStateMachine> locomotionState;
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
			camera = ServiceLocator.Current.Get<ICameraManager>().GetCamera();
			if (characterController == null)
			{
				characterController = GetComponent<CharacterController>();
			}
		}

		public override void FixedUpdate()
		{
			base.FixedUpdate();
			CalculatePlayerMovement();
			ApplyGravity();
			characterController.Move(locomotionData.movementVelocity);
			CalculatePlayerRotation();
		}
		private void OnDisable()
		{
			movementInput.Destroy();
		}

		#endregion

		#region PUBLIC_METHODS
		void CalculatePlayerMovement()
		{
			Quaternion cameraRotation = camera.transform.rotation;
			locomotionData.movementVelocity = new Vector3(movementInput.PlayerInputs().x, 0, movementInput.PlayerInputs().y);
			locomotionData.movementVelocity.Normalize();
			locomotionData.movementVelocity = cameraRotation * locomotionData.movementVelocity;
			locomotionData.movementVelocity *= locomotionData.movementSpeed * Time.deltaTime;
		}
		
		void CalculatePlayerRotation()
		{
			if (Mathf.Abs(movementInput.PlayerInputs().x) > 0 || Mathf.Abs(movementInput.PlayerInputs().y) > 0)
			{
				locomotionData.movementVelocity.y = 0;
				Quaternion targetRotation = Quaternion.LookRotation(locomotionData.movementVelocity);
				transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, locomotionData.rotationSpeed * Time.deltaTime);
			}
		}
		
		void ApplyGravity()
		{
			if (!characterController.isGrounded)
			{
				float gravity = Physics.gravity.y;
				locomotionData.movementVelocity += Vector3.down * gravity * Time.deltaTime;
			}
		}
		
		#endregion

		#region PRIVATE_METHODS

		#endregion

	}
}
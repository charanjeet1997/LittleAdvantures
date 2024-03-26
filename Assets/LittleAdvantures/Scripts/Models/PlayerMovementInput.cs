namespace Games.SinghKage.LittleAdvantures
{
	using UnityEngine.InputSystem;
	using UnityEngine;

	public class PlayerMovementInput : InputAsset.IMovementActions,IPlayerMovementInput
	{

		#region PRIVATE_VARS

		private InputAsset input;
		private float horizontalInput, verticalInput;

		#endregion

		#region PUBLIC_VARS
		
		
		#endregion
		
		#region PUBLIC_METHODS

		public Vector2 PlayerInputs()
		{
			return new Vector2(horizontalInput, verticalInput);
		}

		public void Init()
		{
			input = new InputAsset();
			input.Enable();
			input.Movement.Enable();
			input.Movement.SetCallbacks(this);
		}

		public void Destroy()
		{
			input.Movement.RemoveCallbacks(this);
			input.Movement.Disable();
			input.Disable();
			horizontalInput = 0;
			verticalInput = 0;
		}
		#endregion

		#region PRIVATE_METHODS

		#endregion

		#region PlayerInput
		public void OnLocomotion(InputAction.CallbackContext context)
		{
			Vector2 value = context.ReadValue<Vector2>();
			horizontalInput = value.x;
			verticalInput = value.y;
		}
		#endregion
	}
}
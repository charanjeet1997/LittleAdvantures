using UnityEngine;

namespace Games.SinghKage.LittleAdvantures
{
	public interface IPlayerMovementInput : IInputBindings
	{
		Vector2 PlayerInputs();
	}
}
namespace Games.SinghKage.StateMachine
{
	using UnityEngine;
	[System.Serializable]
	public abstract class BaseSensor<T> : MonoBehaviour where T : BaseStateMachine
	{
		protected T owner;
		public void Initialize(T owner)
		{
			this.owner = owner;
		}
		public abstract void Sense();
	}
}
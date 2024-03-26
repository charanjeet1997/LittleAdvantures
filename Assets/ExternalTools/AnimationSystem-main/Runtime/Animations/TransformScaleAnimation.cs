using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AnimationSystem
{
	public class TransformScaleAnimation : BaseAnimation,IAnimatable<Transform>
	{
		#region PUBLIC_VARS

		public Vector3 fromScale;
		public Vector3 toScale;
		public Vector3 finalScale;
		public Transform AnimatableComponent => animatableComponent;
		public bool PlayOnStart => playOnStart;

		#endregion

		#region PRIVATE_VARS

		private Transform animatableComponent;
		[SerializeField] private bool playOnStart;
		#endregion

		#region UNITY_CALLBACKS
		private void Start()
		{
			animatableComponent = GetComponent<Transform>();
			if(playOnStart)
				StartAnimate();
		}
		#endregion

		#region PUBLIC_METHODS
		public override void OnAnimationStart()
		{
			base.OnAnimationStart();
			if(animatableComponent != null)
				animatableComponent.localScale = fromScale;
		}

		public override void OnAnimationRunning(float percentage)
		{
			base.OnAnimationRunning(percentage);
			if(animatableComponent != null)
				animatableComponent.localScale = Vector3.Lerp(fromScale, toScale, percentage);
		}

		public override void OnAnimationEnd()
		{
			base.OnAnimationEnd();
			if(animatableComponent != null)
				animatableComponent.localScale = finalScale;
		}
		#endregion

		#region PRIVATE_METHODS
		[ContextMenu("Get From Scale")]
		public void GetFromPosition()
		{
			fromScale = transform.localScale;
		}
		
		[ContextMenu("Get To Scale")]
		public void GetToPosition()
		{
			toScale = transform.localScale;
		}
		#endregion

	}
}

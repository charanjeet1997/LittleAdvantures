using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimationSystem
{
	public class TransformTranslateAnimation : BaseAnimation,IAnimatable<Transform>
	{
		#region PUBLIC_VARS

		public Vector3 fromPosition;
		public Vector3 toPosition;
		public Vector3 finalPosition;
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
			animatableComponent.position = fromPosition;
		}

		public override void OnAnimationRunning(float percentage)
		{
			base.OnAnimationRunning(percentage);
			if(animatableComponent != null)
				animatableComponent.position = Vector3.Lerp(fromPosition, toPosition, percentage);
		}

		public override void OnAnimationEnd()
		{
			base.OnAnimationEnd();
			animatableComponent.position = finalPosition;
		}
		#endregion

		#region PRIVATE_METHODS
		[ContextMenu("Get From Position")]
		public void GetFromPosition()
		{
			fromPosition = transform.position;
		}
		
		[ContextMenu("Get To Position")]
		public void GetToPosition()
		{
			toPosition = transform.position;
		}
		#endregion

	}
}

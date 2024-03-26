using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimationSystem
{
	public class UITranslateAnimation : BaseAnimation,IAnimatable<RectTransform>
	{
		#region PUBLIC_VARS

		public Vector3 fromPosition;
		public Vector3 toPosition;
		public Vector3 finalPosition;
		public RectTransform AnimatableComponent => animatableComponent;

		public bool PlayOnStart => playOnStart;

		#endregion

		#region PRIVATE_VARS
		private RectTransform animatableComponent;
		[SerializeField] private bool playOnStart;

		#endregion

		#region UNITY_CALLBACKS
		private void Start()
		{
			animatableComponent = GetComponent<RectTransform>();
			if(playOnStart)
				StartAnimate();
		}
		#endregion

		#region PUBLIC_METHODS
		public override void OnAnimationStart()
		{
			base.OnAnimationStart();
			animatableComponent.anchoredPosition = fromPosition;
		}

		public override void OnAnimationRunning(float percentage)
		{
			base.OnAnimationRunning(percentage);
			if(animatableComponent != null)
				animatableComponent.anchoredPosition =Vector2.LerpUnclamped(fromPosition, toPosition, percentage);
		}

		public override void OnAnimationEnd()
		{
			base.OnAnimationEnd();
			animatableComponent.anchoredPosition = finalPosition;
		}
		#endregion

		#region PRIVATE_METHODS

		#endregion

	}
}

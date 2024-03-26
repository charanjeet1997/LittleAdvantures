using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AnimationSystem
{
	public class ImageFadeAnimation : BaseAnimation,IAnimatable<Image>
	{
		#region PUBLIC_VARS

		public float fromAlpha;
		public float toAlpha;
		public Image AnimatableComponent => animatableComponent;
		public bool PlayOnStart => playOnStart;
	    #endregion

	    #region PRIVATE_VARS
		private int i = 0;
		private Color color;
		private Image animatableComponent;
		[SerializeField]private bool playOnStart;

		#endregion

	    #region UNITY_CALLBACKS
	    private void Start()
	    {
		    animatableComponent = GetComponent<Image>();
		    if(playOnStart)
			    StartAnimate();
	    }
	    #endregion

	    #region PUBLIC_METHODS
	    public override void OnAnimationStart()
	    {
		    if(animatableComponent != null)
				color = animatableComponent.color;
		    base.OnAnimationStart();
	    }

	    public override void OnAnimationRunning(float percentage)
	    {
		    base.OnAnimationRunning(percentage);
		    color.a = Mathf.Lerp(fromAlpha, toAlpha, percentage);
		    if(animatableComponent != null)
				animatableComponent.color = color;
	    }

	    public override void OnAnimationEnd()
	    {
		    base.OnAnimationEnd();
	    }
	    #endregion

	    #region PRIVATE_METHODS
	    
	    #endregion
	}
}
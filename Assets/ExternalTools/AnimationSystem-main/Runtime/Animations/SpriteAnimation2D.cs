using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimationSystem
{
	public class SpriteAnimation2D : BaseAnimation,IAnimatable<SpriteRenderer>
	{
		#region PUBLIC_VARS

		public Sprite[] animationSprites;
		public SpriteRenderer AnimatableComponent => animatableComponent;
		public bool PlayOnStart => playOnStart;
	    #endregion

	    #region PRIVATE_VARS
		private int i = 0;
		private SpriteRenderer animatableComponent;
		[SerializeField]private bool playOnStart;

		#endregion

	    #region UNITY_CALLBACKS
	    private void Start()
	    {
		    animatableComponent = GetComponent<SpriteRenderer>();
		    if(playOnStart)
			    StartAnimate();
	    }
	    #endregion

	    #region PUBLIC_METHODS
	    public override void OnAnimationStart()
	    {
		    base.OnAnimationStart();
	    }

	    public override void OnAnimationRunning(float percentage)
	    {
		    base.OnAnimationRunning(percentage);
		    Sprite sprite = animationSprites[(i + 1) % animationSprites.Length];
		    if (sprite != null && animatableComponent != null)
			    animatableComponent.sprite = sprite;
		    i= (int)((animationSprites.Length - 1)*percentage);
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
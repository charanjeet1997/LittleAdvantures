using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AnimationSystem
{
	public class TextAnimation : BaseAnimation,IAnimatable<Text>
	{
		#region PUBLIC_VARS

		public string[] texts;
		private int stringIndex;
	    public Text AnimatableComponent => animatableComponent;
	    public bool PlayOnStart => playOnStart;
	    #endregion

	    #region PRIVATE_VARS
		int i=0;
		private Text animatableComponent;
		[SerializeField] private bool playOnStart;

		#endregion

	    #region UNITY_CALLBACKS
	    private void Start()
	    {
		    animatableComponent = GetComponent<Text>();
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
		    if(animatableComponent != null)
				animatableComponent.text=texts[(i + 1) % texts.Length];
		    i= (int)((texts.Length - 1)*percentage);
	    }

	    public override void OnAnimationEnd()
	    {
		    base.OnAnimationEnd();
	    }
	    
	    [ContextMenu("AddCounterTillHundered")]
	    public void AddCounterTillHundered()
	    {
		    List<string> test = new List<string>();
		    for (int index = 0; index <= 100; index++)
		    {
			    test.Add(index.ToString()+"%");
		    }

		    texts = test.ToArray();
	    }
	    #endregion

	    #region PRIVATE_METHODS
	    
	    #endregion

	}
}
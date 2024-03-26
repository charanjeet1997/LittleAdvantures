using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace AnimationSystem
{
	public class BaseAnimation : MonoBehaviour
	{
		#region PUBLIC_VARS

		public float duration;
		public float delay;
		public float cyclicDelay;
		public AnimationCurve animationCurve;
		public bool loop;
		[SerializeField] private UnityEvent onAnimationStart, onAnimationStop;
		public Action onAnimationStartAction, onAnimationStopAction;
		#endregion

	    #region PRIVATE_VARS

	    bool isAnimationStarted;
	    private float currentTime;
	    #endregion

	    #region UNITY_CALLBACKS

	    private void OnDisable()
	    {
			StopAnimate();
	    }

	    #endregion

	    #region PUBLIC_METHODS

	    public virtual void OnAnimationStart()
	    {
		    onAnimationStart?.Invoke();
		    onAnimationStartAction?.Invoke();
		    currentTime = 0;
	    }

	    public virtual void OnAnimationRunning(float percentage)
	    {
	    }

	    public virtual void OnAnimationEnd()
	    {
		    onAnimationStop?.Invoke();
		    onAnimationStop?.Invoke();
	    }
	    [ContextMenu("Start Animation")]
	    public void StartAnimate()
	    {
		    OnAnimationStart();
		    
			isAnimationStarted = true;
			StartCoroutine(StartAnimation());
	    }
	    [ContextMenu("Stop Animation")]
	    public void StopAnimate()
	    {
		    if(loop) OnAnimationEnd();
			isAnimationStarted = false;
		    StopCoroutine(RunAnimation());
	    }
	    #endregion

	    #region PRIVATE_METHODS

	    IEnumerator StartAnimation()
	    {
		    yield return new WaitForSeconds(delay);
		    StartCoroutine(RunAnimation());
	    }

	    IEnumerator RunAnimation()
	    {
		    if (isAnimationStarted)
			{
				while (currentTime < duration)
				{
					currentTime += Time.deltaTime;
					float percentage = animationCurve.Evaluate(currentTime / duration);
					OnAnimationRunning(percentage);
					yield return null;
				}
				if (loop)
				{
					currentTime = 0;
					yield return new WaitForSeconds(cyclicDelay);
					StartCoroutine(RunAnimation());
				}
				OnAnimationEnd();
			}
			yield return null;
	    }
	    #endregion
	}
}

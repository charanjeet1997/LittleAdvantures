namespace CinemachineTargetGroupProvider
{
	using UnityEngine;
	using System;
	using System.Collections;

	public interface ITargetGroupObjectProvider 
	{
		TargetGroupObject[] GroupObjects { get; }
		void SetTargetGroup();
	}
}
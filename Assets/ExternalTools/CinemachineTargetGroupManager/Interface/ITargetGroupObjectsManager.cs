using Cinemachine;

namespace CinemachineTargetGroupProvider
{
	using UnityEngine;
	using System;
	using System.Collections;

	public interface ITargetGroupObjectsManager 
	{
		CinemachineTargetGroup TargetGroup { get; }
		void SetTargetGroup(ITargetGroupObjectProvider targetGroupObjects);
		void RemoveAllTargetGroups();
		void RemoveTargetGroupAtIndex(int targetGroupIndex);
	}
}
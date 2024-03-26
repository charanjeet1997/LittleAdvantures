using System.Collections.Generic;
using Cinemachine;
using GameServiceLocator;

namespace CinemachineTargetGroupProvider
{
	using UnityEngine;
	using System;
	using System.Collections;

	public class TargetGroupObjectsManager:MonoBehaviour,ITargetGroupObjectsManager
	{
		[SerializeField]private CinemachineTargetGroup _targetGroup;

		public CinemachineTargetGroup TargetGroup => _targetGroup;
		private ITargetGroupObjectProvider targetGroupObjectProvider;

		private void OnEnable()
		{
			ServiceLocator.Current.Register<ITargetGroupObjectsManager>(this);
		}

		private void OnDisable()
		{
			ServiceLocator.Current.Unregister<ITargetGroupObjectsManager>();
		}

		public void SetTargetGroup(ITargetGroupObjectProvider targetGroupObjectProvider)
		{
			this.targetGroupObjectProvider = targetGroupObjectProvider;
			CinemachineTargetGroup.Target[] targets = new CinemachineTargetGroup.Target[targetGroupObjectProvider.GroupObjects.Length];
			for (int indexOfTargetGroup = 0; indexOfTargetGroup < targets.Length; indexOfTargetGroup++)
			{
				targets[indexOfTargetGroup].target = targetGroupObjectProvider.GroupObjects[indexOfTargetGroup].TargetTransform;
				targets[indexOfTargetGroup].radius = targetGroupObjectProvider.GroupObjects[indexOfTargetGroup].TargetObjectRadius;
				targets[indexOfTargetGroup].weight = targetGroupObjectProvider.GroupObjects[indexOfTargetGroup].TargetObjectWeight;
			}

			_targetGroup.m_Targets = targets;
		}

		public void RemoveAllTargetGroups()
		{
			_targetGroup.m_Targets = null;
		}

		public void RemoveTargetGroupAtIndex(int targetGroupIndex)
		{
			List<TargetGroupObject> targetGroupObjects = new List<TargetGroupObject>(targetGroupObjectProvider.GroupObjects);
			CinemachineTargetGroup.Target[] targets = new CinemachineTargetGroup.Target[targetGroupObjectProvider.GroupObjects.Length];
			for (int indexOfTargetGroup = 0; indexOfTargetGroup < targetGroupObjects.Count; indexOfTargetGroup++)
			{
				targets[indexOfTargetGroup].target = targetGroupObjects[indexOfTargetGroup].TargetTransform;
				targets[indexOfTargetGroup].radius = targetGroupObjects[indexOfTargetGroup].TargetObjectRadius;
				targets[indexOfTargetGroup].weight = targetGroupObjects[indexOfTargetGroup].TargetObjectWeight;
			}
		}
	}
}
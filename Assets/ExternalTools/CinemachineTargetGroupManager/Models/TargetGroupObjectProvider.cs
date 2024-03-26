using GameServiceLocator;

namespace CinemachineTargetGroupProvider
{
	using UnityEngine;
	using System;
	using System.Collections;


	public class TargetGroupObjectProvider:MonoBehaviour,ITargetGroupObjectProvider
	{
		[SerializeField] private TargetGroupObject[] _groupObjects;

		public TargetGroupObject[] GroupObjects => _groupObjects;

		private void Start()
		{
			SetTargetGroup();
		}

		public void SetTargetGroup()
		{
			if(ServiceLocator.Current.Has<ITargetGroupObjectsManager>())
				ServiceLocator.Current.Get<ITargetGroupObjectsManager>().SetTargetGroup(this);
		}
	}
}
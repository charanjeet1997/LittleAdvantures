namespace CinemachineTargetGroupProvider
{
	using UnityEngine;
	using System;
	using System.Collections;


	public class TargetGroupObject:MonoBehaviour
	{
		[SerializeField] private float targetObjectWeight;
		[SerializeField] private float targetObjectRadius;
		[SerializeField] private Transform targetTransform;
		
		public float TargetObjectWeight => targetObjectWeight;

		public float TargetObjectRadius => targetObjectRadius;

		public Transform TargetTransform => targetTransform;
	}
}
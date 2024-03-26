namespace AnimationSystem
{
	using UnityEngine;
	using System;
	using System.Collections;

	public interface IAnimatable<T>
	{
		T AnimatableComponent { get; }
		bool PlayOnStart { get; }
	}
}
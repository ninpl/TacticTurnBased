using UnityEngine;
using System;
using System.Collections;

public static class TransformAnimationExtensions
{
	public static Tweener MoveTo (this Transform t, Vector3 position)
	{
		return MoveTo (t, position, Tweener.DefaultDuration);
	}
	
	public static Tweener MoveTo (this Transform t, Vector3 position, float duration)
	{
		return MoveTo (t, position, duration, Tweener.DefaultEquation);
	}
	
	public static Tweener MoveTo (this Transform t, Vector3 position, float duration, Func<float, float, float, float> equation)
	{
		TransformPositionTweener tweener = t.gameObject.AddComponent<TransformPositionTweener> ();
		tweener.startTweenValue = t.position;
		tweener.endTweenValue = position;
		tweener.duration = duration;
		tweener.equation = equation;
		tweener.Play ();
		return tweener;
	}
	
	public static Tweener MoveToLocal (this Transform t, Vector3 position)
	{
		return MoveToLocal (t, position, Tweener.DefaultDuration);
	}
	
	public static Tweener MoveToLocal (this Transform t, Vector3 position, float duration)
	{
		return MoveToLocal (t, position, duration, Tweener.DefaultEquation);
	}
	
	public static Tweener MoveToLocal (this Transform t, Vector3 position, float duration, Func<float, float, float, float> equation)
	{
		TransformLocalPositionTweener tweener = t.gameObject.AddComponent<TransformLocalPositionTweener> ();
		tweener.startTweenValue = t.localPosition;
		tweener.endTweenValue = position;
		tweener.duration = duration;
		tweener.equation = equation;
		tweener.Play ();
		return tweener;
	}

	public static Tweener RotateToLocal (this Transform t, Vector3 euler, float duration, Func<float, float, float, float> equation)
	{
		TransformLocalEulerTweener tweener = t.gameObject.AddComponent<TransformLocalEulerTweener> ();
		tweener.startTweenValue = t.localEulerAngles;
		tweener.endTweenValue = euler;
		tweener.duration = duration;
		tweener.equation = equation;
		tweener.Play ();
		return tweener;
	}
	
	public static Tweener ScaleTo (this Transform t, Vector3 scale)
	{
		return ScaleTo (t, scale, Tweener.DefaultDuration);
	}
	
	public static Tweener ScaleTo (this Transform t, Vector3 scale, float duration)
	{
		return ScaleTo (t, scale, duration, Tweener.DefaultEquation);
	}
	
	public static Tweener ScaleTo (this Transform t, Vector3 scale, float duration, Func<float, float, float, float> equation)
	{
		TransformScaleTweener tweener = t.gameObject.AddComponent<TransformScaleTweener> ();
		tweener.startTweenValue = t.localScale;
		tweener.endTweenValue = scale;
		tweener.duration = duration;
		tweener.equation = equation;
		tweener.Play ();
		return tweener;
	}
}

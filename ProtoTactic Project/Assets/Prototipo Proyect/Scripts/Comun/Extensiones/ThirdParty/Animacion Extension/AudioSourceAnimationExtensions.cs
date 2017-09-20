using UnityEngine;
using System;
using System.Collections;

public static class AudioSourceAnimationExtensions 
{
	public static Tweener VolumeTo (this AudioSource s, float volume)
	{
		return VolumeTo(s, volume, Tweener.DefaultDuration);
	}

	public static Tweener VolumeTo (this AudioSource s, float volume, float duration)
	{
		return VolumeTo(s, volume, duration, Tweener.DefaultEquation);
	}

	public static Tweener VolumeTo (this AudioSource s, float volume, float duration, Func<float, float, float, float> equation)
	{
		AudioSourceVolumeTweener tweener = s.gameObject.AddComponent<AudioSourceVolumeTweener>();
		tweener.source = s;
		tweener.startValue = s.volume;
		tweener.endValue = volume;
		tweener.duration = duration;
		tweener.equation = equation;
		tweener.Play ();
		return tweener;
	}
}
using UnityEngine;
using System.Collections;

public class RectTransformAnchorPositionTweener : Vector3Tweener 
{
	RectTransform rt;
	
	void Awake ()
	{
		rt = transform as RectTransform;
	}

	protected override void OnUpdate ()
	{
		base.OnUpdate ();
		rt.anchoredPosition = currentTweenValue;
	}
}
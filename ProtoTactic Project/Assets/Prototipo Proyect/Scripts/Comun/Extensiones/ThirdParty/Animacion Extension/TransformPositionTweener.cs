using UnityEngine;
using System.Collections;

public class TransformPositionTweener : Vector3Tweener 
{
	protected override void OnUpdate ()
	{
		base.OnUpdate ();
		transform.position = currentTweenValue;
	}
}

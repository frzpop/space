using System.Collections;
using UnityEngine;
using DG.Tweening;
using System;

[RequireComponent( typeof( MeshRenderer ) )]
public class BackgroundGradient : MonoBehaviour {

	public Color top;
	public Color bot;

	MeshRenderer meshRend;

	void Start()
	{
		Time.timeScale = 0.4f;
		meshRend = GetComponent<MeshRenderer>();

		meshRend.enabled = true;

		InitializeGradient();
	}

	void InitializeGradient()
	{
		meshRend.material.SetColor( "_Color1", top );
		meshRend.material.SetColor( "_Color2", bot );


		StartCoroutine( MiddleAnim() );
	}

	float middleValue = 1;
	IEnumerator MiddleAnim()
	{
		float target;
		bool toggle = false;

		const float duration = 6f;
		while ( true )
		{
			if ( toggle )
				target = 0.5f;
			else
				target = 1.5f;

			DOTween.To(()=> middleValue, x=> middleValue = x, target, duration)
				.SetEase( Ease.InOutSine )
				.OnUpdate( SetMiddle );

			toggle = !toggle;

			yield return new WaitForSeconds( duration );
		}
	}

	void SetMiddle()
	{
		meshRend.material.SetFloat( "_Center", middleValue );
	}
}
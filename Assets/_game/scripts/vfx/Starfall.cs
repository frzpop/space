using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Starfall : MonoBehaviour {
	
	float minInterval = 2f;
	float maxInterval = 6f;

	public ParticleSystem[] stars;

	void Start()
	{
		StartCoroutine( StarfallFX() );
	}
	
	Vector3 GetStartPos()
	{
		var bounds = GetComponent<BoxCollider>().bounds;
		float x = Random.Range( bounds.min.x, bounds.max.x );
		float y = Random.Range( bounds.min.y, bounds.max.y );
		float z = Random.Range( bounds.min.z, bounds.max.z );
		return new Vector3( x, y, z );
	}

	int index;
	IEnumerator StarfallFX()
	{
		while ( gameObject.activeSelf )
		{
			if ( index > stars.Length - 1 )
				index = 0;

			FallAnim( stars[index] );
			index++;

			float interval = Random.Range( 0f, 1f );
			yield return new WaitForSeconds( interval );
		}
	}

	void FallAnim( ParticleSystem star )
	{
		const float dur = 0.5f;

		star.transform.localPosition = GetStartPos();
		star.Play();
		Vector3 localPos = star.transform.localPosition;
		Vector3 endPos = new Vector3( localPos.x - 5, localPos.y - 5, localPos.z );
		star.transform.DOLocalMove( endPos, dur )
			.SetEase( Ease.OutCirc )
			.OnComplete( star.Stop );
	}
}

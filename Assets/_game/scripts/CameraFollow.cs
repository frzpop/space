using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	Vector3 currentPos;
	Vector3 targetPos;
	Vector3 offset = new Vector3( 0f, 0f, -10f );

	void Follow(){
		
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 0.125f );
		transform.position = smoothedPosition;

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Follow( ); 
		
	}

	void FixedUpdate()
	{
		Follow( ); 
	}


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimientoCamara : MonoBehaviour {

	public Transform target;
	public float smoothing = 5f;

	Vector3 offset;

	void Start()
	{
		offset = transform.position - target.transform.position;
	}

	void Update()
	{
		Vector3 targetCamPos = target.transform.position + offset;
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing + Time.deltaTime);
	}

}

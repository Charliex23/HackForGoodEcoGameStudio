using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;


public class MovimientoAlternativo : MonoBehaviour
{
	public float Speed = 6f;

	Vector3 Movement;
	Quaternion Rotacion;
	Animator Anim;

	int FloorMask;

	void Awake()
	{
		FloorMask = LayerMask.GetMask ("Floor");
		Anim = GetComponent<Animator> ();
	}

	void FixedUpdate()
	{

		float h = CnInputManager.GetAxis ("Horizontal");
		float v = CnInputManager.GetAxis ("Vertical");

		Rotacion = Quaternion.Euler (0f, h, h);

		transform.rotation = Rotacion;

		Move (h, v);
		Animating (h, v);

	}

	void Move (float h, float v)
	{
		Movement.Set (h, 0f, v);

		Movement = Movement.normalized * Speed * Time.deltaTime;

		transform.position = transform.position + Movement;

	}
		
		
	void Animating (float h, float v)
	{
		bool Walking = h != 0f || v != 0f;
		Anim.SetBool ("IsWalking", Walking);
	}

}

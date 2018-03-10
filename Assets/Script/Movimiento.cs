using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movimiento : MonoBehaviour {

	NavMeshAgent nv;

	public Animator anim;
	private double distance;
	bool correr;
	bool andar;

	Vector3 Objetivo;


	void Start()
	{
		nv = GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animator> ();


	}
		

	void Update()
	{
		
		andar = false;
		correr = false;

		distance = nv.remainingDistance;

		if (Input.GetMouseButton (0)) {

			andar = true;
			correr = false;
			Ray r = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit h;
			anim.SetBool ("IsWalking", true);

			if (Physics.Raycast (r, out h)) {

				nv.speed = 1.6f;
				nv.acceleration = 1f;
				nv.angularSpeed = 65;
				Objetivo = h.point;
				setPosition ();

			}
		}

		if (Input.GetMouseButton (1)) {

			andar = false;
			correr = true;
			Ray r = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit h;
			anim.SetBool ("IsWalking", true);

			if (Physics.Raycast (r, out h)) {

				nv.speed = 3.2f;
				nv.acceleration = 4.5f;
				nv.angularSpeed = 1500;
				Objetivo = h.point;
				setPosition ();

			}
		}

		if (distance == 0) {
		
			andar = false;
			correr = false;
		}
			
			
	}

	void FixedUpdate()
	{
		LanzarAnimacion ();
	}

	void setPosition ()
	{

		nv.SetDestination (Objetivo);

	}

	void LanzarAnimacion()
	{

		if (distance != 0 && andar==true) {
			
			anim.SetBool ("IsWalking", true);
			anim.SetBool ("IsRuning", false);
		}

		if (distance != 0 && correr==true)
		{
			anim.SetBool ("IsWalking", false);
			anim.SetBool ("IsRuning", true);
		}

		if (distance == 0 )
		{
			andar = false;
			correr = false;
			anim.SetBool ("IsWalking", false);
			anim.SetBool ("IsRuning", false);
		}
			
	}
				
}
	
		



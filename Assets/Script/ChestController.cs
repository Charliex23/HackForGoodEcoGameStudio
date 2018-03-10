using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class ChestController : MonoBehaviour, UsableInterface {

	Animator ChestAnim;
	public bool OpenChest;

	public float Distance;

	public GameObject Player;
	public GameObject Usableobject;

	public GameObject Button1;


	void Start () {

		Button1 = GameObject.FindWithTag ("Button1");
		Player = GameObject.FindWithTag ("Player");

		OpenChest = false;
		ChestAnim = GetComponent<Animator> ();

	}
	

	void Update () {


		Distance = Vector3.Distance (Player.GetComponent<Transform> ().position, Usableobject.GetComponent<Transform> ().position);

		if (Distance < 2f) {

			Button1.SetActive (true);

		} 

		else {

			OpenChest = false;
			Button1.SetActive (false);


		}

		if (CnInputManager.GetButtonDown("Use")) {
		
			OpenChest = true;

		
		}
		
	}

	void FixedUpdate(){
	
		Anim ();

		if (OpenChest == true) {
		
			Button1.SetActive (false);
		
		}
	
	}

	void Anim() {

		ChestAnim.SetBool ("Abrir", OpenChest);
	}

	public void Use () {

		Anim ();

	}
		
}

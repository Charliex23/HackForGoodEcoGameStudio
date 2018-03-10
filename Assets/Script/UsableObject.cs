using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableObject : MonoBehaviour {

	//  public GameObject Player;
	//  public GameObject Usableobject;

	//	public float Distance;

	public GameObject Button1;

	public UsableInterface usableObject;


	void Start () {

		Button1.SetActive (false);

	}
		
	void OnTriggerEnter (Collider other) {

		if (other.CompareTag ("UsableObject")) {
		
			usableObject = other.gameObject.GetComponent<UsableInterface> ();

			if (usableObject != null)
				Button1.SetActive (true);
		
		}

	
	}

	void OnTriggerExit (Collider other) {
	
		Button1.SetActive (false);

	
	}

	public void UseObject () {
	
		usableObject.Use ();
	
	}


}



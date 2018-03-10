using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class GameController : MonoBehaviour {

	public GameObject Button1;
	public GameObject Player;
	public bool ActivateButton1;

	// Use this for initialization
	void Start () {
		
		Button1.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		

		if (ActivateButton1 == true) {
			
			Button1.SetActive (true);

		} 

		else {
		
			Button1.SetActive (false);
		
		}
			
	}

	void OnTriggerEnter(Collider other){

		if (other.CompareTag ("Player") && other.CompareTag ("UsableObject")) {

			ActivateButton1 = true;
		} 

		else {
			
			ActivateButton1 = false;

		}
	}
}

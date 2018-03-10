using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectoCamara : MonoBehaviour {




	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Techo")){
			other.gameObject.GetComponent<Renderer> ().enabled = false;
		}
			
			
	}
	void OnTriggerExit(Collider other){
		if(other.CompareTag("Techo")){
			other.gameObject.GetComponent<Renderer> ().enabled = true;
		}


	}

}

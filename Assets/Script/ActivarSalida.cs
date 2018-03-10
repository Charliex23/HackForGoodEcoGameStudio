using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarSalida : MonoBehaviour {

	public GameObject salida;

	public void OnTriggerEnter(){
	
		salida.SetActive (true);
	
	}
		

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

	public string ClaveAcceso;

	public string ClaveIntroducida;

	public Text Clave;


	void Start (){

		ClaveAcceso = ("HackForGood");


	
	}

	public void acceder() {
		
		ClaveIntroducida = Clave.text;

		if (ClaveAcceso == ClaveIntroducida) {

			Application.LoadLevel ("Menu2");
		}
	}
}
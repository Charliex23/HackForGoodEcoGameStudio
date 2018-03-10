using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour {


	public static DialogSystem Instance { get; set; }

	public string linea;

	public Idialog Interacting;
	public GameObject cuadro;
	public Text txt;

	void Awake(){

		if (Instance != null && Instance != this)
			Destroy (gameObject);
		else {
			Instance = this;
		}
	}
		

	public void Interact(Idialog diag){
		Interacting = diag;
		next ();
	}

	public void ShowMsg(){
		if (!cuadro.activeInHierarchy) {
			cuadro.SetActive (true);
		}
		txt.text = Interacting.SelectMsg();
	}


	public void next(){
		if (Interacting.msgs <= 0 || !Interacting.ownMax) {
			closeMsg ();
		}else
			ShowMsg ();
	}

	public void closeMsg(){
		cuadro.SetActive (false);
	}

}

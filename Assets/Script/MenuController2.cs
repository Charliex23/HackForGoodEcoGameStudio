using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController2 : MonoBehaviour {

	public void Continuar (){
	
		Application.LoadLevel ("Scene3- pruebas");
	
	}

	public void SeleccionarCapitulo (){
	
		Application.LoadLevel ("Menu3");
	
	}

	public void Volver(){
	
		Application.LoadLevel ("Menu");
	
	}
}


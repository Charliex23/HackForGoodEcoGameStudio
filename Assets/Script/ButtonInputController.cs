using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class ButtonInputController : MonoBehaviour {

	public UsableObject UO;

	void Update () {
		if (CnInputManager.GetButtonDown("Jump")) {
			UO.UseObject ();
		}

		
	}
}

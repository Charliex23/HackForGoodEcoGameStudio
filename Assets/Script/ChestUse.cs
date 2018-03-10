using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestUse : MonoBehaviour, UsableInterface, Idialog{

	public Animator anim;

	public int numItems;
	public bool full;


	public int msgs{
		get{return numItems; }
		set{numItems = value; }
	}

	public bool ownMax{ 
		get{return full; } 
		set{full = value; }
	}

	void Awake(){
		ownMax = true;
	}
	void Start () {
	
		anim = GetComponent<Animator> ();
	
	}

	void Anim() {

		anim.SetBool ("Abrir", true);
	}

	public void Use () { // añadir función a desarrollar por el cofre
		
		DialogSystem.Instance.Interact (this);
		Anim ();

	}


	public string SelectMsg(){
		string msg = "";
		if (!ownMax) {
			msg = "Chest is empty";
		} else {
			switch (msgs) {
			case 2:
				msg = "and do not forget to awake the middle one until the other two are awaken.";
				break;
			case 1:
				msg = "You found an old scroll. It says: In order to summon Merlin, do not awake the left tree in first place, and do not forget to awake the middle one until the other two are awaken.";
				break;
			}
			msgs--;
		}
		if (msgs<=0)
			ownMax = false;
		return msg;
	}
	
}

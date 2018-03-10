using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estanteria : MonoBehaviour, UsableInterface, Idialog{

	static int nmsg=3;


	public int msgs{
		get{ return nmsg; }
		set{ nmsg = value; }
	}
			
	public bool read;

	public bool ownMax{
		get{ return read; }
		set{ read = value; }
	}


	public static string msg1= "Merlin is a strange Entity… you wont find him in battlefields or goberments because he hates politics and War. He is above that. You must know something, Merlin always is where he is needed";
	public static string msg2= "Merlin is one of more powerful sorcerers in the World, but nobody can find him, he always finds who he want to find";
	public static string msg3= "If you want to meet him, you should be prepared, go to the Rogues cave and open de Red chest. But be careful, there is some dangers inside";

	void Awake(){
		ownMax = true;
	}
	public void Use(){
		DialogSystem.Instance.Interact (this);
	}

	public string SelectMsg(){
		string next = " ";
		switch (msgs) {
		case 3:
			next = msg1;
			break;
		case 2:
			next = msg2;
			break;
		case 1:
			next = msg3;
			break;
		}
		msgs--;
		Debug.Log (read);
		ownMax= false;
		return next;
	}

}

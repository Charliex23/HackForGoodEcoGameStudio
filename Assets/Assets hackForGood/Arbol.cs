using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbol : MonoBehaviour, UsableInterface, Idialog {

	int numMsg=1;
	bool oMax;
	static string correct= "The tree whistles back";
	static string incorrect= ".....Nothing happens......";
	static string MerlinMessage= "If you want to take out Excalibur from the stone you mus...";


	public static int followingT=-1;
	public int idT;

	void Awake(){
		oMax = true;
	}

	public bool ownMax {
		get{ return oMax; }
		set{ oMax = value; }
	}

	public int msgs{ 
		get{ return numMsg; } 
		set{ numMsg = value; }
	}

	public void Use(){
		DialogSystem.Instance.Interact (this);

	}

	public string SelectMsg(){
		string next = " ";
		if (idT == followingT) {
			next = correct;
			oMax=false;
			followingT++;
		}
		else
			next = incorrect;
		if (followingT == 1) {
		
			next = MerlinMessage;
		
		}
		return next;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Idialog{


	int msgs{ get; set; }

	bool ownMax{ get; set; }

	string SelectMsg();
}

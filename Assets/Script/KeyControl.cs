using UnityEngine;
using System.Collections;

public class KeyControl : MonoBehaviour {

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Z))
		{
			KeyObjManager.GetInstance().NearKeyOK("Z");
		} else if(Input.GetKeyDown(KeyCode.X))
		{
			KeyObjManager.GetInstance().NearKeyOK("X");
		} else if(Input.GetKeyDown(KeyCode.C))
		{
			KeyObjManager.GetInstance().NearKeyOK("C");
		}
	}
}
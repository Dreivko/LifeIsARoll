using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Save (){
		GameController.control.Save ();
	}

	public void Load (){
		GameController.control.Load ();

	}
}

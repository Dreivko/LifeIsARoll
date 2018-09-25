using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resistance : MonoBehaviour {


	public int resistance;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void shooted(){
		resistance--;

		if (resistance <= 0) {
			Destroy (transform.gameObject);
		}

	}
}

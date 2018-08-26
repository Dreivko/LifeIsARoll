using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotator : MonoBehaviour {

	public GameObject rCube;

	// Use this for initialization
	void Start () {
		
	}
	

	public void RotateCube () {
		rCube.transform.Rotate(new Vector3 (45,45,45) );
	}
}

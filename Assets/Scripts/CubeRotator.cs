using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeRotator : MonoBehaviour {

	public GameObject rCube;

	Material material;

	Vector3 pos;
	float x;
	float y;
	float z;

	public Slider posx;
	public Slider posy;
	public Slider posz;

	// Use this for initialization
	void Start () {
		pos = rCube.transform.position;
		x = rCube.transform.position.x;
		y = rCube.transform.position.y;
		z = rCube.transform.position.z;
		material = rCube.GetComponent<Renderer> ().material;
		material.color = Color.black;
	}
	

	public void RotateCube () {
		rCube.transform.Rotate(new Vector3 (45,45,45) );
	}

	public void ScaleCube(float value){
		rCube.transform.localScale = new Vector3 (value,value,value);
	}

	public void ChangeMaterial(int value){
		switch (value) {
		case 0:
			material.color = Color.black;
			break;
		case 1:
			material.color = Color.red;
			break;
		case 2:
			material.color = Color.yellow;
			break;
		}
	}

	public void PosX(float value){
		rCube.transform.position = new Vector3 (value,y,z);
		x = value;
	}

	public void PosY(float value){
		rCube.transform.position = new Vector3 (x,value,z);
		y = value;
	}

	public void PosZ(float value){
		rCube.transform.position = new Vector3 (x,y,value);
		z = value;
	}

	public void Reset(){
		posx.value = 0;
		posy.value = 0;
		posz.value = 0;
		x = 0f;
		y = 1f;
		z = 0f;
		rCube.transform.position = new Vector3 (x,y,z);
	}

}

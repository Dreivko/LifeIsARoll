using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resistance : MonoBehaviour {


	public int resistance;

	//Audio
	private AudioSource audioRecollector;

	// Use this for initialization
	void Start () {
		//Audio
		audioRecollector = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void shooted(Vector3 ImpactDot){
		resistance--;

		if (resistance <= 0) {
			audioRecollector.Play ();
			Destroy (transform.gameObject);
		}

	}


	void OnParticleCollision(){
		Debug.Log ("Shooted");
		Destroy (transform.gameObject);
	}


}

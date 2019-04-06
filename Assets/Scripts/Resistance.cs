using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resistance : MonoBehaviour {


	public int resistance;

	//Audio
	private AudioSource audioRecollector;

	public Rigidbody rb;

	ParticleSystem ps;

	// Use this for initialization
	void Start () {
		//Audio
		audioRecollector = GetComponent<AudioSource> ();
		rb = GetComponent<Rigidbody>();
		rb.isKinematic = true;
		ps = GetComponentInChildren<ParticleSystem> ();

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
		if(gameObject.CompareTag("GreenCube")){
			/*transform.position = new Vector3 (transform.position.x - 1,
				transform.position.y,
				transform.position.z);*/
			Debug.Log ("Green");
		}
		if(gameObject.CompareTag("RedCube")){
			rb.isKinematic = false;
			StartCoroutine (WaitToAction());
			for (int i = 0; i <= 7; i++) {
				transform.position = new Vector3 (transform.position.x,
					transform.position.y + i,
					transform.position.z);
			}
			if (transform.position.y < 0.5) {
				ps.transform.position = transform.position;
				ps.Play ();
			}
			Debug.Log ("Red");
		}
		if(gameObject.CompareTag("YellowCube")){
			
			Debug.Log ("Yellow");
		}
		if(gameObject.CompareTag("BlueCube")){
			GameObject GC = GameObject.Find ("GreenCube");
			transform.position = GC.transform.position;
			Debug.Log ("Blue");
		}
		//Destroy (transform.gameObject);
	}

	public IEnumerator WaitToAction(){
		yield return new WaitForSecondsRealtime (2);
	}


}

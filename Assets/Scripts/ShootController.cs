using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour {

	public GameObject player;
	public float timebetweenshoots = 1f;
	public float range = 100f;

	float timer;
	Ray shootRay;
	RaycastHit shootHit;
	int shootableMask;
	LineRenderer gunLine;
	Light gunLight;
	float effectsDisplayTime = 1.2f;
	bool isRot = false;

	ParticleSystem ps;



	void Awake (){
		shootableMask = LayerMask.GetMask ("shootable");
		gunLine = GetComponent <LineRenderer> ();
		gunLight = GetComponent<Light> ();
	}

	// Use this for initialization
	void Start () {
		ps = GetComponentInChildren<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= timebetweenshoots * effectsDisplayTime) {
		
			DisableEffects ();

		}
		/*if (isRot == true){
			StartCoroutine(Rotate(GameObject.Find("YellowCube")));
		}
		if (isRot == false) {
			StartCoroutine(StopRotate(GameObject.Find("YellowCube")));
		}*/

	}

	void Shoot (){
		Vector3 ubication = new Vector3 (player.transform.position.x, 
			player.transform.position.y + 1.1f, 
			player.transform.position.z);

		timer = 0f;

		gunLine.enabled = true;
		gunLight.enabled = true;
		shootRay.origin = ubication;
		shootRay.direction = transform.forward;
		gunLine.SetPosition (0, ubication);



		if (Physics.Raycast (shootRay, out shootHit, range, shootableMask)) {
			//Destroy (shootHit.collider.gameObject);
			gunLine.SetPosition (1, shootHit.point);
			Resistance resist = shootHit.collider.gameObject.GetComponent<Resistance> ();
			if (resist != null) {
				ps.transform.position = shootHit.point;
				ps.Play ();
				resist.shooted (shootHit.point);
			}

			if (shootHit.collider.gameObject.CompareTag ("GreenCube")) {
				GameObject GCube = shootHit.collider.gameObject;
				GCube.transform.position = Vector3.Lerp (GCube.transform.position, 
						new Vector3 (Random.Range (-10.0f, 10.0f), 0.5f, Random.Range (-10.0f, 10.0f)), 
						10.0f * Time.deltaTime);

				Debug.Log ("Green Cube");
			}

			if (shootHit.collider.gameObject.CompareTag ("RedCube")) {
				shootHit.collider.gameObject.transform.position = 
					new Vector3 (shootHit.collider.gameObject.transform.position.x,
						shootHit.collider.gameObject.transform.position.y - 1,
						shootHit.collider.gameObject.transform.position.z);
				Debug.Log ("Red Cube");
			}

			if (shootHit.collider.gameObject.CompareTag ("YellowCube")) {
				//GameObject YCube = shootHit.collider.gameObject;

				//YCube.transform.Rotate (new Vector3 (15, 30, 45));
				//YCube.transform.Rotate (new Vector3 (15, 30, 45));

				//StartCoroutine( Rotate (YCube));

				if (isRot == false) {
					isRot = true;
					Debug.Log (isRot);
				} else {
					isRot = false;
					Debug.Log (isRot);
				}

				Debug.Log ("Yellow Cube");
			}



		} else {
			Debug.Log ("No hit");
			gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
		}
		
	}

	void DisableEffects (){
		gunLine.enabled = false;
		gunLight.enabled = false;
	}

	public IEnumerator Rotate (GameObject YCube){
		
		YCube.transform.Rotate (new Vector3 (15, 30, 45)*Time.deltaTime);
		yield return new WaitForSecondsRealtime(3);
	}
	/*
	public IEnumerator StopRotate (GameObject YCube){

		YCube.transform.Rotate (new Vector3 (0,0,0));
		yield return new WaitForSecondsRealtime(1);
	}*/

}

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


	// Particules
	public Transform particles;
	private ParticleSystem ps;
	private Vector3 position;



	void Awake (){
		shootableMask = LayerMask.GetMask ("shootable");
		gunLine = GetComponent <LineRenderer> ();
		gunLight = GetComponent<Light> ();
	}

	// Use this for initialization
	void Start () {
		ps = particles.GetComponent<ParticleSystem>();
		ps.Stop();
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= timebetweenshoots * effectsDisplayTime) {
		
			DisableEffects ();

		}

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
			ActiveParticles (shootHit.collider);
			StartCoroutine (StopParticles (ps));
			Destroy (shootHit.collider.gameObject);
			gunLine.SetPosition (1, shootHit.point);

		} else {
			Debug.Log ("No hit");
			gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
		}
		
	}

	void DisableEffects (){
		gunLine.enabled = false;
		gunLight.enabled = false;
	}
		

	void ActiveParticles(Collider other){
		position = other.gameObject.transform.position;
		particles.position = position;
		ps = particles.GetComponent<ParticleSystem> ();
		ps.Play ();
	}

	public IEnumerator StopParticles(ParticleSystem pasys){
		yield return new WaitForSecondsRealtime (5);

		pasys.Stop ();
	}

}
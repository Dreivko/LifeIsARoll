using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	//Text 
	public Text countText;
	public Text winText;

	//Player
	private Rigidbody rb;
	private int count;
	public float speed;

	//Timer
	private Timer t;

	//Particles
	public Transform particles;
	private ParticleSystem ps;
	private Vector3 position;

	//Audio
	private AudioSource audioRecollector;

	void Awake (){
		//Timer
		t = GetComponent<Timer>();
	}

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText();
		winText.text = "";

		//Particles
		ps = particles.GetComponent<ParticleSystem>();
		ps.Stop();


		//Audio
		audioRecollector = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate (){

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("PickUp")){
			ActiveParticles (other);
			audioRecollector.Play ();
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText ();
		}
		if(other.gameObject.CompareTag("CPickUp")){
			ActiveParticles (other);
			audioRecollector.Play ();
			other.gameObject.SetActive(false);
			count = count + 5;
			SetCountText ();
		}

	}

	void SetCountText () {
		countText.text = "Count: " + count.ToString ();
		if (count >= 16) {
			winText.text = "You Win!";
			t.Finnish ();
		}
	}

	void ActiveParticles(Collider other){
		position = other.gameObject.transform.position;
		particles.position = position;
		ps = particles.GetComponent<ParticleSystem> ();
		ps.Play ();
	}


}
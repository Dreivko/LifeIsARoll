﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControllerLvL2 : MonoBehaviour {

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
	public Transform particles2;
	private ParticleSystem ps2;
	private Vector3 position2;

	//win particles
	public Transform particles3;
	private ParticleSystem ps3;
	private Vector3 position3;

	//Audio
	private AudioSource audioRecollector;



	// Time Cube
	public GameObject TCube;
	bool TCubeStat = true;

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
		ps2 = particles2.GetComponent<ParticleSystem>();
		ps2.Stop();
		//Win Particules
		ps3 = particles3.GetComponent<ParticleSystem>();
		ps3.Stop();

		//Audio
		audioRecollector = GetComponent<AudioSource> ();

		// Time Cube
		StartCoroutine(HideUnhide());
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
			StartCoroutine (StopParticles (ps));
		}
		if(other.gameObject.CompareTag("CPickUp")){
			ActiveParticles2 (other);
			audioRecollector.Play ();
			other.gameObject.SetActive(false);
			count = count + 5;
			SetCountText ();
			StartCoroutine (StopParticles (ps2));
		}
		if (other.gameObject.CompareTag ("DeathCube")) {
			YouDied ();
		}
		if(other.gameObject.CompareTag("TimePickup")){
			ActiveParticles (other);
			audioRecollector.Play ();
			StopCoroutine (HideUnhide ());
			other.gameObject.SetActive(false);
			TCubeStat = false;
			string m = t.getMinutes();
			string s = t.getSeconds();
			Debug.Log ("Minute " + m + " : " + "Second " + s  );
			//t.timer.text = (System.Int32.Parse(t.getSeconds()) - 1).ToString();
			t.setSeconds("5");
			StartCoroutine (StopParticles (ps));
		}

	}



	void SetCountText () {
		countText.text = "Count: " + count.ToString ();
		if (count >= 21) {
			winText.text = "You Win!";
			ps3 = particles3.GetComponent<ParticleSystem> ();
			ps3.Play ();
			t.Finnish ();
		}
	}

	void YouDied(){
		rb.transform.position = new Vector3(0f,0.5f,0f);
		speed = 0;
		winText.text = "You Died";
		t.Finnish ();
	}

	void ActiveParticles(Collider other){
		position = other.gameObject.transform.position;
		particles.position = position;
		ps = particles.GetComponent<ParticleSystem> ();
		ps.Play ();
	}

	void ActiveParticles2(Collider other){
		position2 = other.gameObject.transform.position;
		particles2.position = position2;
		ps2 = particles2.GetComponent<ParticleSystem> ();
		ps2.Play ();
	}

	public IEnumerator StopParticles(ParticleSystem pasys){
		yield return new WaitForSecondsRealtime (5);

		pasys.Stop ();
	}

	public IEnumerator HideUnhide(){	
		while (true) {
			if (TCubeStat == true) {
				yield return (new WaitForSeconds (2));
				TCube.transform.gameObject.SetActive (false);
			} else {
				break;
			}
			if(TCubeStat == true){
				yield return (new WaitForSeconds (2));
				TCube.transform.gameObject.SetActive (true);
			} else {
				break;
			}
		}

	}

}
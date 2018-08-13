﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	//Text 
	public Text countText;
	public Text winText;

	private Rigidbody rb;

	private int count;
	public float speed;

	private Timer t;

	void Awake (){
		t = GetComponent<Timer>();
	}

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText();
		winText.text = "";
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
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText ();
		}
		if(other.gameObject.CompareTag("CPickUp")){
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


}
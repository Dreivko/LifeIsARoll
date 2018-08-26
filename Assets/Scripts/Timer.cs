using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour {

	public Text timer;
	private bool finnished = false;
	private float startTime;


	// Use this for initialization
	void Start () {
		startTime = Time.time;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (finnished)
			return;

		float t = Time.time - startTime; 
		string minutes = ((int) t / 60).ToString();
		string seconds = (t % 60).ToString("f2");
		timer.text = minutes + ":" + seconds;
	}

	public void Finnish () {			
		finnished = true;
		timer.color = Color.yellow;
	}

}

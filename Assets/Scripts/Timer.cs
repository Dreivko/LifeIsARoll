using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour {

	public Text timer;
	public string minutes = "0";
	public string seconds = "0";
	private bool finnished = false;
	private float startTime;
	private string penalty = "0";

	// Use this for initialization
	void Start () {
		startTime = Time.time;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (finnished)
			return;

		float t = Time.time - startTime; 
		minutes = (((int) t / 60)).ToString();
		seconds = ((t % 60) - int.Parse(penalty) ).ToString("f2");
		timer.text = minutes + ":" + seconds;
	}

	public void Finnish () {			
		finnished = true;
		timer.color = Color.yellow;
	}

	public string getMinutes(){
		return minutes;
	}
	public string getSeconds(){
		return seconds;
	}
	public void setMinutes(string m){
		minutes = m;
		//Continue here
	}
	public void setSeconds(string s){
		Debug.Log ("Recibio s = " + s );
		penalty = int.Parse (s).ToString();
	}

}

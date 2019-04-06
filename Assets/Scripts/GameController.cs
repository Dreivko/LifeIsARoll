using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {

	public static GameController control ;

	void Awake () {
		if(control == null){
			DontDestroyOnLoad (gameObject);
			control = this;
		}else if (control != this){
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Save (){
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/persistance.dat");

		GameData data = new GameData ();
		data.posx = GameObject.Find ("ThirdPersonController").transform.position.x; 
		data.posy = GameObject.Find ("ThirdPersonController").transform.position.y;
		data.posz = GameObject.Find ("ThirdPersonController").transform.position.z;

		bf.Serialize (file, data);
		file.Close(); 
	}

	public void Load (){
		if (File.Exists(Application.persistentDataPath + "/persistance.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/persistance.dat", FileMode.Open);

			GameData data = (GameData)bf.Deserialize (file);
			file.Close ();

			Vector3 position = new Vector3 (data.posx, data.posy,data.posz);
			GameObject.Find ("ThirdPersonController").transform.position = position;

		}
	}

	public void LoadScene(){
		SceneManager.LoadScene (1);
	}

}

[Serializable]
class GameData{
	public float posx;
	public float posy;
	public float posz;

}
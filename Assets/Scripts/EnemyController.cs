using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

	Transform playerPosition;
	NavMeshAgent agent;

	void Start () {
		playerPosition = GameObject.FindGameObjectWithTag ("Player").transform;
		agent = GetComponent<NavMeshAgent> ();


	}
	
	// Update is called once per frame
	void Update () {
		agent.SetDestination (playerPosition.position);
	}
}

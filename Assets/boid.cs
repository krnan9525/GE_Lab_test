using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boid : MonoBehaviour {

	public Vector3 force;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position += force;
	}

	void calculate(){
		
	}
}

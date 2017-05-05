using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(boid))]
public abstract class steering : MonoBehaviour {

	public abstract Vector3 Calculate ();
	public boid boid;
	public Vector3 force;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

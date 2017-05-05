using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boid : MonoBehaviour {

	public Vector3 force;
	private steering[] behievers;
	// Use this for initialization
	void Start () {
		behievers = GetComponentsInChildren<steering> ();
	}

	void FixedUpdate () {
		foreach (steering b in behievers) {
			transform.position += b.Calculate();
		}

	}


}
